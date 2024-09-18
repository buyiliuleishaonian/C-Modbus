using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wen.KYJControlLib;
using thinger.ControlLib;
using thinger.DataConvertLib;
using ConfigLib;
using System.Threading;
using static System.Windows.Forms.AxHost;
using Wen.ModbucCommunicationLib.Library;
using Wen.ModbucCommunicationLib.Helper;
using Wen.ModbucCommunicationLib.StoreArea;
using NPOI.SS.Util;

namespace AIR_ModbusTCP
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            this.Load+=FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Initial();
        }

        /// <summary>
        /// 配置文件路径
        /// </summary>
        private string path = Application.StartupPath+@"\Config\Device.json";


        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
            this.lbl_UserName.Text=CommonMethod.SysAdminModel.LoginName;
            this.lbl_CurrentTime.Text= DateTime.Now.ToString("yyyy.MM.dd HH:mm ").ToString();
            OpenForm(FormNames.日志报警);
            OpenForm(FormNames.控制流程);

            CommonMethod.PLCDevice=ReadDevice(path).Content;
            CommonMethod.PLC.IsShortAddress=CommonMethod.PLCDevice.IsShortAddress;
            DataFormat df=(DataFormat)CommonMethod.PLCDevice.DataFormat;

            //设定多线程手动取消
            CommonMethod.PLCDevice.CancellationTokenSource=new CancellationTokenSource();

            Task.Run(() =>
            {
                Connect(CommonMethod.PLCDevice);
            }, CommonMethod.PLCDevice.CancellationTokenSource.Token);

        }

        #region 读取配置文件，进行通信，读取数据

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private OperateResult<ModbusTCPDevice> ReadDevice(string path)
        {
            var result = new ConfigManage().LoadProjects(path);

            if (result!=null&&result.Count>0)
            {
                if (result[0].ModbusTCPList.Count>0&&result[0].ModbusTCPList[0]!=null)
                {
                    if (result[0].ModbusTCPList[0].IsActive)
                    {
                        return OperateResult.CreateSuccessResult(result[0].ModbusTCPList[0]);
                    }
                    else
                    {
                        new FrmMessageBoxWithOutAck("读取配置文件", "项目没有激活").Show();
                        return null;
                    }
                }
                else
                {
                    new FrmMessageBoxWithOutAck("读取配置文件", "项目不存在设备配置").Show();
                    return null;
                }
            }
            else
            {
                new FrmMessageBoxWithOutAck("读取配置文件", "配置文件路径不正确").Show();
                return null;
            }
        }

        /// <summary>
        /// 进行通信，读取
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        private void Connect(ModbusTCPDevice device)
        {
            while (!device.CancellationTokenSource.IsCancellationRequested)
            {
                //判断是否连接
                if (!CommonMethod.PLCDevice.IsConnected)
                {
                    //判断是否是第一次连接
                    if (CommonMethod.PLCDevice.IsFirstConnect==false)
                    {
                        Thread.Sleep(10000);
                        CommonMethod.PLC?.DisConnect();
                    }
                    var result = CommonMethod.PLC.Connect(device.Ipaddress, device.Port);
                    if (result)
                    {
                        SetConnectLed(result);
                        device.IsConnected = true;
                        Console.WriteLine("通信成功");
                    }
                    else
                    {
                        device.IsConnected = false;
                        SetConnectLed(result);
                        //new FrmMessageBoxWithOutAck("通信PLC","通信失败，请检查ip地址和端口号").Show();
                    }
                }
                else
                {
                    var result = ReadGroup(device);
                    if (result.IsSuccess)
                    {
                        SetConnectLed(true);
                        //清空错误连接次数
                        device.ErrorTimes=0;
                    }
                    else
                    {
                        SetConnectLed(false);
                        device.ErrorTimes++;
                        if (device.ErrorTimes>=device.AllowErrorTimes)
                        {
                            //暂时等待
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 更改通信LED灯状态
        /// </summary>
        /// <param name="state"></param>
        private void SetConnectLed(bool state)
        {
            if (this.led_ConnState.InvokeRequired)
            {
                this.led_ConnState.State = state;   
            }
            else
            {
                while (!this.IsHandleCreated)
                {
                    ;
                }
                this.Invoke(new Action(() =>
                {
                    this.led_ConnState.State=state;
                }));
            }
        }

        /// <summary>
        /// 解析变量的地址,得到起始地址，以及偏移量或者长度
        /// </summary>
        /// <param name="startAddress"></param>
        /// <returns></returns>
        private OperateResult<int, int> AlansisAddress(string startAddress)
        {
            try
            {
                if (startAddress.Contains('.'))
                {
                    var result = startAddress.Split('.');
                    if (result.Length==2)
                    {
                        return OperateResult.CreateSuccessResult(Convert.ToInt32(result[0], 10), Convert.ToInt32(result[1], 10));
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<int, int>("请检查变量地址是否正确");
                    }
                }
                else if (startAddress.Contains('|'))
                {
                    var result = startAddress.Split('|');
                    if (result.Length==2)
                    {
                        return OperateResult.CreateSuccessResult(Convert.ToInt32(result[0], 10), Convert.ToInt32(result[1], 10));
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<int, int>("请检查变量地址是否正确");
                    }
                }
                else
                {
                    return OperateResult.CreateSuccessResult(Convert.ToInt32(startAddress, 10), 0);
                }
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<int, int>("转换错误原因"+ex.Message);
            }
        }

        /// <summary>
        /// 读取配置的通信组
        /// </summary>
        /// <param name="device">PLC配置对象</param>
        /// <returns></returns>
        private OperateResult ReadGroup(ModbusTCPDevice device)
        {
            //读取数据
            for (int i = 0; i < device.GroupList.Count; i++)
            {

                var groupAddress = ModbusHelper.ModbusAddressAnalysis(device.GroupList[i].Start, 0, device.IsShortAddress);
                if (!groupAddress.IsSuccess) return OperateResult.CreateFailResult("读取数据失败：通信组地址错误");
                //起始地址，从站地址，功能码
                ushort start = groupAddress.Content3;

                if (groupAddress.Content1==ModbusStoreArea.x3||groupAddress.Content1==ModbusStoreArea.x4)
                {
                    var data = CommonMethod.PLC.ReadByteArray(device.GroupList[i].Start, Convert.ToUInt16(device.GroupList[i].Length));

                    //读取数据成功
                    if (data.IsSuccess)
                    {
                        if (data.Content.Length==device.GroupList[i].Length*2)
                        {
                            //因Modbus的寄存器存储区
                            foreach (var variable in device.GroupList[i].VarList)
                            {
                                var result = AlansisAddress(variable.Start);
                                result.Content1=(result.Content1-start)*2;
                                switch (variable.VarType.ToLower())
                                {
                                    case "bool":
                                        variable.VarValue=BitLib.GetBitFrom2BytesArray(data.Content, result.Content1, result.Content2, ((DataFormat)device.DataFormat==DataFormat.ABCD||(DataFormat)device.DataFormat==DataFormat.CDAB));
                                        break;
                                    case "byte":
                                        variable.VarValue=ByteLib.GetByteFromByteArray(data.Content, result.Content1);
                                        break;
                                    case "short":
                                        variable.VarValue=ShortLib.GetShortFromByteArray(data.Content, result.Content1);
                                        break;
                                    case "ushort":
                                        variable.VarValue=UShortLib.GetUShortFromByteArray(data.Content, result.Content1);
                                        break;
                                    case "int":
                                        variable.VarValue=IntLib.GetIntFromByteArray(data.Content, result.Content1, (DataFormat)device.DataFormat);
                                        break;
                                    case "uint":
                                        variable.VarValue=UIntLib.GetUIntFromByteArray(data.Content, result.Content1, (DataFormat)device.DataFormat);
                                        break;
                                    case "float":
                                        variable.VarValue=FloatLib.GetFloatFromByteArray(data.Content, result.Content1, (DataFormat)device.DataFormat);
                                        break;
                                    case "double":
                                        variable.VarValue=DoubleLib.GetDoubleFromByteArray(data.Content, result.Content1, (DataFormat)device.DataFormat);
                                        break;
                                    case "long":
                                        variable.VarValue=LongLib.GetLongFromByteArray(data.Content, result.Content1, (DataFormat)device.DataFormat);
                                        break;
                                    case "ulong":
                                        variable.VarValue=ULongLib.GetULongFromByteArray(data.Content, result.Content1, (DataFormat)device.DataFormat);
                                        break;
                                    case "string":
                                        variable.VarValue=StringLib.GetStringFromByteArrayByEncoding(data.Content, result.Content1, result.Content2, Encoding.ASCII);
                                        break;
                                    default:
                                        break;
                                }
                                //进行线性转换
                                var varValue = MigrationLib.GetMigrationValue(variable.VarValue, variable.Scale.ToString(), variable.Offset.ToString());
                                if (varValue.IsSuccess)
                                {
                                    variable.VarValue = varValue.Content;
                                }
                                else
                                {
                                    return OperateResult.CreateFailResult("数据线性转换失败");
                                }
                                device.Update(variable);
                            }
                        }
                        else
                        {
                            return OperateResult.CreateFailResult("读取失败"+"返回字节长度与通信组乘2长度不一致");
                        }
                    }
                    else
                    {
                        return OperateResult.CreateFailResult("读取失败："+groupAddress.Message);
                    }
                }
                //输入输出线圈
                else if (groupAddress.Content1==ModbusStoreArea.x1||groupAddress.Content1==ModbusStoreArea.x0)
                {
                    var data = CommonMethod.PLC.ReadBoolArray(device.GroupList[i].Start, Convert.ToUInt16(device.GroupList[i].Length));
                    if (data.IsSuccess)
                    {
                        if (data.Content.Length==device.GroupList[i].Length)
                        {
                            foreach (var variable in device.GroupList[i].VarList)
                            {
                                switch (variable.VarType.ToLower())
                                {
                                    case "bool":
                                        variable.VarValue=data.Content[Convert.ToInt32(variable.Start)];
                                        break;
                                }
                                device.Update(variable);
                            }
                        }
                        else
                        {
                            return OperateResult.CreateFailResult("读取失败"+"返回字节长度与通信组乘2长度不一致");
                        }
                    }
                    else
                    {
                        return OperateResult.CreateFailResult("读取失败："+groupAddress.Message);
                    }
                }
            }
            return OperateResult.CreateSuccessResult();
        }
        #endregion

        #region 窗体切换

        private bool naviControl1_SelectButtonForm(object sender, EventArgs e)
        {
            FormNames frmName = (FormNames)Enum.Parse(typeof(FormNames), sender.ToString());
            switch (frmName)
            {
                case FormNames.日志查询:
                    if (!CommonMethod.SysAdminModel.HistoryLog)
                    {
                        new FrmMessageBoxWithOutAck("页面切换", $"用户{CommonMethod.SysAdminModel.LoginName}没有日志查询权限").ShowDialog();
                        return false;
                    }
                    break;
                case FormNames.参数设置:
                    if (!CommonMethod.SysAdminModel.ParamSet)
                    {
                        new FrmMessageBoxWithOutAck("页面切换", $"用户{CommonMethod.SysAdminModel.LoginName}没有参数修改权限").ShowDialog();
                        return false;
                    }
                    break;
                case FormNames.实时趋势:
                    if (!CommonMethod.SysAdminModel.ActualTrend)
                    {
                        new FrmMessageBoxWithOutAck("页面切换", $"用户{CommonMethod.SysAdminModel.LoginName}没有查看实时趋势权限").ShowDialog();
                        return false;
                    }
                    break;
                case FormNames.历史趋势:
                    if (!CommonMethod.SysAdminModel.HistoryTrend)
                    {
                        new FrmMessageBoxWithOutAck("页面切换", $"用户{CommonMethod.SysAdminModel.LoginName}没有查看历史趋势权限").ShowDialog();
                        return false;
                    }
                    break;
                case FormNames.数据报表:
                    if (!CommonMethod.SysAdminModel.Report)
                    {
                        new FrmMessageBoxWithOutAck("页面切换", $"用户{CommonMethod.SysAdminModel.LoginName}没有查看数据报表权限").ShowDialog();
                        return false;
                    }
                    break;
                case FormNames.用户管理:
                    if (!CommonMethod.SysAdminModel.UserManage)
                    {
                        new FrmMessageBoxWithOutAck("页面切换", $"用户{CommonMethod.SysAdminModel.LoginName}没有查看实时趋势权限").ShowDialog();
                        return false;
                    }
                    break;
                case FormNames.退出系统:
                    this.Close();
                    break;
            }
            OpenForm(frmName);
            return true;
        }

        public void OpenForm(FormNames frmName)
        {
            //存在了多少窗体
            int total = this.MainPanel.Controls.Count;
            //删除的窗体数量
            int closeNumber = 0;
            //判断进行窗体切换时，先查询长期窗体中是否存在了
            bool isFind = false;

            //在MainPanel的控件寻找是否长期窗体中的一个
            for (int i = 0; i < total; i++)
            {
                Control ct = this.MainPanel.Controls[i-closeNumber];
                if (ct is Form frm)
                {
                    if (frm.Text==frmName.ToString())
                    {
                        frm.BringToFront();
                        isFind = true;
                    }
                    else if ((FormNames)Enum.Parse(typeof(FormNames), frm.Text)>FormNames.临时界面)
                    {
                        this.MainPanel.Controls.Remove(ct);
                        closeNumber++;
                        isFind = false;
                    }
                }
            }
            if (isFind==false)
            {
                Form frm = null;
                switch (frmName)
                {
                    case FormNames.控制流程:
                        frm = new FrmMonitor();
                        break;
                    case FormNames.日志报警:
                        frm = new FrmAlarmLog();
                        break;
                    case FormNames.日志查询:
                        frm = new FrmHistoryLog();
                        break;
                    case FormNames.参数设置:
                        frm = new FrmParamSet();
                        break;
                    case FormNames.实时趋势:
                        frm = new FrmActualTrend();
                        break;
                    case FormNames.历史趋势:
                        frm= new FrmHistroyTrend();
                        break;
                    case FormNames.数据报表:
                        frm=new FrmReport();
                        break;
                    case FormNames.用户管理:
                        frm=new FrmUserManage();
                        break;
                    case FormNames.退出系统:
                        this.Close();
                        return;
                }
                //让控件不在是顶级控件，就可以存放在Panel容器中
                frm.TopLevel=false;
                frm.Parent=this.MainPanel;
                //置顶窗体
                frm.BringToFront();
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
        }



        #endregion

        #region 窗体移动
        private Point size;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                size=new Point(e.X, e.Y);
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                this.Location=new Point(this.Location.X+e.X-size.X, this.Location.Y+e.Y-size.Y);
            }
        }
        #endregion

    }
}
