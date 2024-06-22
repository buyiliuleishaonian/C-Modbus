using ConfigLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.KYJControlLib;
using Wen.ModbucCommunicationLib.Helper;
using Wen.ModbucCommunicationLib.Library;
using Wen.ModbucCommunicationLib.StoreArea;


namespace AIR_CompressorModbusRTU
{
    public partial class FraMain : Form
    {

        public FraMain()
        {
            InitializeComponent();
            this.Load+=FraMain_Load;
            OpenForm(FormNames.控制流程);
        }


        #region 1、读取配置文件，获得通信对象 2、进行多线程读取数据
        private string devicePath = Application.StartupPath+@"\Device\Device.json";
        /// <summary>
        /// 启动窗体触发，读取配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void FraMain_Load(object sender, EventArgs e)
        {
            this.lbl_UserName.Text=CommonMethod.SysAdmin.LoginName;

            var result = GetDeviceByPath(devicePath);

            CommonMethod.PLCDevice=result.Content;
            //手动停止多线程源
            CommonMethod.PLCDevice.Cts=new CancellationTokenSource();
            CommonMethod.PLCDevice.DataFormat=(int)DataFormat.CDAB;

            //给定变量初始值
            CommonMethod.PLCDevice.Init();

            //配置PLC通信对象
            CommonMethod.PLC.DataFormat=DataFormat.CDAB;

            //多线程，进行连接读取
            Task.Run(() =>
            {
                PLCCommunication(CommonMethod.PLCDevice);
            }, CommonMethod.PLCDevice.Cts.Token);
        }

        //1、通过公共端 设定Device，Connect对象，设定手动关闭多线程
        //2、进行多线程读取
        //2.1判断是否连接，连接直接开始多线程读取，循环遍历每一个通信组
        //2.2没连接，判断是否是第一次连接,第一次连接，就进行连接
        //2.3不是第一次连接，进行延迟时间，判断连接是否关闭，没关闭，关闭，进行连接
        //2.4验证连接是否成功，更改通信状态，进行多线程数据读取
        //3、进行数据读取，读取成功，清除读取失败的次数，读取失败，读取失败次数+1，判断是否是实体串口线断开
        //3.1、读取设备上所有串口，验证是否包含PLC的串口号

        /// <summary>
        /// PLC通信读取
        /// </summary>
        /// <param name="device"></param>
        public void PLCCommunication(ModbusRTUDevice device)
        {
            while (!device.Cts.IsCancellationRequested)
            {
                //连接
                if (device.IsConnected)
                {
                    foreach (var group in device.GroupList)
                    {
                        if (group.IsActive)
                        {
                            //读取
                            var result = GetGroupValue(device, group);

                            //读取成功
                            if (result.IsSuccess)
                            {
                                //更改通信状态
                                SetConnectState(true);

                                //清空读取错误次数
                                device.ErrorTimes=0;
                            }
                            //读取失败
                            else
                            {
                                //写入日志，更改通信状态，读取失败次数+1
                                SetConnectState(false);
                                device.ErrorTimes++;
                                if (device.ErrorTimes>=device.AllowErrorTimes)
                                {
                                    //判断是串口通信线断了
                                    //串口通信线断了，就不存在串口号
                                    //没断就重连
                                    if (IsComExits(device.PortName))
                                    {
                                        Thread.Sleep(10);
                                        continue;
                                    }
                                    else
                                    {
                                        device.IsConnected = false;
                                        break;
                                    }
                                }
                                CommonMethod.AddLog(false, "读取失败"+result.Message);
                            }
                        }
                    }

                }
                //未连接
                else
                {
                    //判断是否是第一次连接,否断开连接
                    if (device.IsFirstConnect==false)
                    {
                        Thread.Sleep(device.SleepTime);
                        CommonMethod.PLC?.DisConnect();
                    }
                    var result = CommonMethod.PLC.Connect(device.PortName, device.Baudrate, device.Databits, device.Stopbits, device.Parity);
                    if (result)
                    {
                        //添加日志，通信状态
                        device.IsConnected=true;
                        SetConnectState(true);
                        CommonMethod.AddLog(true, device.IsFirstConnect ? "第一次连接成功" : "重新连接成功");
                    }
                    else
                    {
                        //添加日志，通信状态
                        device.IsConnected = false;
                        SetConnectState(true);
                        CommonMethod.AddLog(true, device.IsFirstConnect ? "第一次连接失败" : "重新连接失败");
                    }

                    //清楚第一次连接状态
                    if (device.IsFirstConnect)
                    {
                        device.IsFirstConnect=false;
                    }
                }
            }
        }

        /// <summary>
        /// 设置通信状态
        /// </summary>
        /// <param name="state"></param>
        private void SetConnectState(bool state)
        {
            //1、判断是否是多线程 修改 led_ConnState属性
            if (this.led_ConnState.InvokeRequired)
            {
                this.led_ConnState.State = state;
            }
            //如果不是多线程访问，但是在多线程里面修改控件属性是不可以的
            //调用系统委托，系统多线程，改变控件属性
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.led_ConnState.State=state;
                }));
            }
        }

        /// <summary>
        /// 读取通信组
        /// </summary>
        /// <param name="device"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public OperateResult GetGroupValue(ModbusRTUDevice device, ModbusRTUGroup group)
        {
            //1、对通信组地址进行解析，因为是Modbus通信，需要明确是那个功能区
            var addRess = ModbusHelper.ModbusAddressAnalysis(group.Start, 0, device.IsShortAddress);
            if (!addRess.IsSuccess) return OperateResult.CreateFailResult("读取通信组失败"+addRess.Message);
            //判断是进行线圈/寄存器读取
            if (addRess.Content1==ModbusStoreArea.x3||addRess.Content1==ModbusStoreArea.x4)
            {
                //进行读取
                var result = CommonMethod.PLC.ReadByteArray(group.Start, (ushort)group.Length);
                if (result.IsSuccess)
                {
                    if (result.Content.Length==group.Length*2)
                    {
                        foreach (var variable in group.VarList)
                        {
                            OperateResult<int, int> operate = AnalysisAddRess(variable.Start);
                            if (operate.IsSuccess)
                            {
                                //sart 相对地址（ModbusRTU通信长度是寄存器数量，表示是寄存器位置
                                //但是寄存器的起始地址不一定为0，所以通信组的第一个寄存器地址，也就是通信组起始地址
                                //但是读取出来的数据是从0——最后，所以为了对应的数据，需要
                                //进行  （读取寄存器地址-通信组起始寄存器地址）×2
                                int start = operate.Content1;
                                int offsetOrLength = operate.Content2;

                                start=(start-addRess.Content3)*2;
                                switch (variable.VarType.ToLower())
                                {
                                    case "bool":
                                        variable.VarValue= BitLib.GetBitFrom2BytesArray(result.Content, start, offsetOrLength,
                                            (DataFormat)device.DataFormat==DataFormat.ABCD||(DataFormat)device.DataFormat==DataFormat.CDAB);
                                        break;
                                    case "byte":
                                        variable.VarValue=   ByteLib.GetByteFromByteArray(result.Content, start);
                                        break;
                                    case "short":
                                        variable.VarValue= ShortLib.GetShortFromByteArray(result.Content, start);
                                        break;
                                    case "ushort":
                                        variable.VarValue= UShortLib.GetUShortFromByteArray(result.Content, start);
                                        break;
                                    case "int":
                                        variable.VarValue= IntLib.GetIntFromByteArray(result.Content, start, CommonMethod.PLC.DataFormat);
                                        break;
                                    case "uint":
                                        variable.VarValue=UIntLib.GetUIntFromByteArray(result.Content, start, CommonMethod.PLC.DataFormat);
                                        break;
                                    case "long":
                                        variable.VarValue=LongLib.GetLongFromByteArray(result.Content, start, CommonMethod.PLC.DataFormat);
                                        break;
                                    case "ulong":
                                        variable.VarValue=ULongLib.GetULongFromByteArray(result.Content, start, CommonMethod.PLC.DataFormat);
                                        break;
                                    case "string":
                                        //需要将字符串解码为Encoding.ASCII
                                        variable.VarValue=StringLib.GetStringFromByteArrayByEncoding(result.Content, start, offsetOrLength, Encoding.ASCII);
                                        break;
                                    case "double":
                                        variable.VarValue= DoubleLib.GetDoubleFromByteArray(result.Content, start, CommonMethod.PLC.DataFormat);
                                        break;
                                    case "float":
                                        variable.VarValue= FloatLib.GetFloatFromByteArray(result.Content, start, CommonMethod.PLC.DataFormat);
                                        break;
                                    case "bytearray":
                                        break;
                                    case "hexstring":
                                        break;
                                    default:
                                        break;
                                }

                                //还需要进行线性转换
                                var actualValue = MigrationLib.GetMigrationValue(variable.VarValue, variable.Scale.ToString(), variable.Offset.ToString());
                                if (actualValue.IsSuccess)
                                {
                                    variable.VarValue=actualValue.Content;
                                }
                                else
                                {
                                    return OperateResult.CreateFailResult("线性转换失败");
                                }

                                //更改 变量的值
                                device.Update(variable);
                            }
                            else
                            {
                                return OperateResult.CreateFailResult(operate.Message);
                            }
                        }
                    }
                    else
                    {
                        return OperateResult.CreateFailResult($"读取长度{result.Content.Length}和通信组长度{group.Length*2}不一致");
                    }
                }
                else
                {
                    return OperateResult.CreateFailResult(result.Message);
                }
            }
            //读取输入输出线圈
            else if (addRess.Content1==ModbusStoreArea.x0||addRess.Content1==ModbusStoreArea.x1)
            {
                var result = CommonMethod.PLC.ReadBoolArray(group.Start, (ushort)group.Length);
                if (result.IsSuccess)
                {
                    if (result.Content.Length==group.Length)
                    {
                        foreach (var variable in group.VarList)
                        {
                            OperateResult<int, int> operate = AnalysisAddRess(variable.Start);
                            if (operate.IsSuccess)
                            {
                                //sart 相对地址（ModbusRTU通信长度是寄存器数量，表示是寄存器位置
                                //但是寄存器的起始地址不一定为0，所以通信组的第一个寄存器地址，也就是通信组起始地址
                                //但是读取出来的数据是从0——最后，所以为了对应的数据，需要
                                //进行  （读取寄存器地址-通信组起始寄存器地址）×2
                                int start = operate.Content1;

                                start=(start-addRess.Content3);

                                switch (variable.VarType.ToLower())
                                {
                                    case "bool":
                                        variable.VarValue =result.Content[start];
                                        break;
                                    default:
                                        break;
                                }
                                device.Update(variable);
                            }
                            else
                            {
                                return OperateResult.CreateFailResult(operate.Message);
                            }
                        }
                    }
                    else
                    {
                        return OperateResult.CreateFailResult($"读取长度{result.Content.Length}和通信组长度{group.Length*2}不一致");
                    }
                }
                else
                {
                    return OperateResult.CreateFailResult(result.Message);
                }
            }

            return OperateResult.CreateSuccessResult(group);
        }

        /// <summary>
        /// 通用的变量地址转换
        /// </summary>
        /// <param name="address">变量起始地址</param>
        /// <param name="fromBase">变量进制</param>
        /// <returns>返回OperateResult<int,int>
        /// <remark>第一个值：地址</remark>
        /// <remark> 第二个值：偏移量/长度</remark>>
        /// </remark>>
        /// </returns>
        private OperateResult<int, int> AnalysisAddRess(string address, int fromBase = 10)
        {
            try
            {
                if (address.Contains("."))
                {
                    var result = address.Split('.');
                    if (result.Length==2)
                    {
                        return OperateResult.CreateSuccessResult(Convert.ToInt32(result[0], fromBase), Convert.ToInt32(result[1]));
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<int, int>(new OperateResult("变量的地址错误"+address));
                    }
                }
                else if (address.Contains("|"))
                {
                    var result = address.Split('|');
                    if (result.Length==2)
                    {
                        return OperateResult.CreateSuccessResult(Convert.ToInt32(result[0], fromBase), Convert.ToInt32(result[1]));
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<int, int>(new OperateResult("变量的地址错误"+address));
                    }
                }
                else
                {
                    return OperateResult.CreateSuccessResult(Convert.ToInt32(address, fromBase), 0);
                }
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<int, int>(new OperateResult($"起始地址{address}转换出错"+ex.Message));
            }
        }

        /// <summary>
        /// 查询设备所有串口号是否包含指定的
        /// </summary>
        /// <param name="portName">指定串口号</param>
        /// <returns></returns>
        public bool IsComExits(string portName)
        {
            List<string> result = new List<string>();
            try
            {
                //搜索所有的串口号
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity"))
                {
                    var hardInfos = searcher.Get();
                    foreach (var item in hardInfos)
                    {
                        if (item.Properties["Name"].Value!=null)
                        {
                            string name = item.Properties["Name"].Value.ToString();
                            if (name.Contains("(COM")&&name.EndsWith(")"))
                            {
                                if (name.Contains("->"))
                                {
                                    result.Add(name.Substring(name.IndexOf('(')+1, name.IndexOf(')')-name.IndexOf('-')-2));
                                }
                                else
                                {
                                    result.Add(name.Substring(name.IndexOf('(')+1, name.IndexOf(')')-name.IndexOf('-')-1));
                                }
                            }
                        }
                    }
                    searcher.Dispose();
                }
            }
            catch
            {
                result=new List<string>();
            }
            return result.Contains(portName);
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public OperateResult<ModbusRTUDevice> GetDeviceByPath(string xmlPath)
        {
            var result = new ConfigManage().LoadProjects(xmlPath);
            //判断是否存在项目
            if (result!=null&&result.Count>0)
            {
                //判断是否存在ModbusRTU设备
                if (result[0].ModbusRTUList!=null&&result[0].ModbusRTUList.Count>0)
                {
                    var device = result[0].ModbusRTUList[0];
                    if (device.IsActive)
                    {
                        return OperateResult.CreateSuccessResult(device);
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<ModbusRTUDevice>("请检查配置文件是否激活");
                    }
                }
                else
                {
                    return OperateResult.CreateFailResult<ModbusRTUDevice>("请检查配置文件是否存在ModbusRTU配置");
                }
            }
            else
            {
                return OperateResult.CreateFailResult<ModbusRTUDevice>("请检查配置文件是否正确");
            }

        }
        #endregion


        #region 窗体切换
        /// <summary>
        /// 窗体切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool naviControl1_SelectButtonForm(object sender, EventArgs e)
        {
            FormNames frm = (FormNames)Enum.Parse(typeof(FormNames), sender.ToString());
            //等待用户的权限来选择可以开启那些窗体
            switch (frm)
            {
                case FormNames.日志查询:
                    if (!CommonMethod.SysAdmin.HistoryLog)
                    {
                        MessageBox.Show("无日志查询权限,请切换用户", "窗体切换", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    break;
                case FormNames.参数设置:
                    if (!CommonMethod.SysAdmin.ParamSet)
                    {
                        MessageBox.Show("无参数设置权限,请切换用户", "窗体切换", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    break;
                case FormNames.实时趋势:
                    if (!CommonMethod.SysAdmin.ActualTrend)
                    {
                        MessageBox.Show("无实时趋势权限,请切换用户", "窗体切换", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    break;
                case FormNames.历史趋势:
                    if (!CommonMethod.SysAdmin.HistoryTrend)
                    {
                        MessageBox.Show("无历史趋势权限,请切换用户", "窗体切换", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    break;
                case FormNames.数据报表:
                    if (!CommonMethod.SysAdmin.Report)
                    {
                        MessageBox.Show("无数据报表权限,请切换用户", "窗体切换", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    break;
                case FormNames.用户管理:
                    if (!CommonMethod.SysAdmin.UserManage)
                    {
                        MessageBox.Show("无用户管理权限,请切换用户", "窗体切换", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    break;
                case FormNames.退出系统:
                    this.Close();
                    return false;
                default:
                    break;
            }
            OpenForm(frm);

            return true;
        }

        /// <summary>
        /// 窗体切换通用方法
        /// </summary>
        /// <param name="formName"></param>
        private void OpenForm(FormNames formName)
        {
            //首先判读Mainpanel控件，容纳了多少窗体
            int total = this.MainPanel.Controls.Count;
            //用于记录关闭了窗体数量
            int closeNumber = 0;
            //判断是否是没有创建的窗体
            bool isFinde = false;

            //遍历控件中所存在的窗体控件
            for (int i = 0; i < total; i++)
            {
                Control ct = this.MainPanel.Controls[i-closeNumber];
                //如果在窗体集合中存在，所选择的窗体
                if (ct is Form frm)
                {
                    if (frm.Text==formName.ToString())
                    {
                        frm.BringToFront();
                        isFinde = true;
                    }
                    //当不是我们所寻找的窗体，并且不是固定窗体时，关闭窗体
                    else if ((FormNames)(Enum.Parse(typeof(FormNames), frm.Text))>=FormNames.临时界面)
                    {
                        frm.Close();
                        closeNumber++;
                    }
                }
            }

            //当寻找完MainPanel.Control的窗体控件不存在，我们所需要的控件时
            if (isFinde==false)
            {
                Form frm = null;
                switch (formName)
                {
                    case FormNames.控制流程:
                        frm=new FrmMonitor();
                        break;
                    case FormNames.日志报警:
                        frm=new FrmAlarmLog();
                        break;
                    case FormNames.日志查询:
                        frm=new FrmHistoryLog();
                        break;
                    case FormNames.参数设置:
                        frm=new FrmParamSet();
                        break;
                    case FormNames.实时趋势:
                        frm=new FrmActualTrend();
                        break;
                    case FormNames.历史趋势:
                        frm=new FrmHistoryTrend();
                        break;
                    case FormNames.数据报表:
                        frm=new FrmReport();
                        break;
                    case FormNames.用户管理:
                        frm=new FrmUserManage();
                        break;
                    default:
                        break;
                }
                if (frm!=null)
                {
                    //置顶窗体
                    frm.TopLevel=false;
                    //父控件
                    frm.Parent=this.MainPanel;
                    //窗体样式
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock= DockStyle.Fill;
                    //在父控件中置顶
                    frm.BringToFront();

                    frm.Show();
                }
            }
        }
        #endregion

        #region 无边框移动
        private Point point;
        /// <summary>
        /// 得到鼠标左键的坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FraMain_MouseDown(object sender, MouseEventArgs e)
        {
            point=new Point(e.X, e.Y);
        }

        /// <summary>
        /// 通过鼠标移动的距离，加上窗体左上角坐标，减去鼠标坐标就是同步移动了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FraMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                this.Location=new Point(this.Location.X+e.X-point.X, this.Location.Y+e.Y-point.Y);
            }
        }
        #endregion
    }
}
