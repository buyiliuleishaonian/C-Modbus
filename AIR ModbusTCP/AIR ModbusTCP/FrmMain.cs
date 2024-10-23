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
using System.Collections.ObjectModel;
using Model;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using AIR_BLL;

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
            //读取plc参数数据，建立通信
            Initial();

            //解锁锁屏标志位
            islock=CommonMethod.Config.AutoLock;

            //锁屏定时器
            LockTime=new System.Timers.Timer();
            LockTime.Interval=200;
            LockTime.Elapsed+=LockTime_Elapsed;
            LockTime.Start();
            //消息筛选
            message= new MessageFilter();
            Application.AddMessageFilter(message);

            //解锁事件
            SystemEvents.SessionSwitch+=SystemEvents_SessionSwitch;

            this.FormClosing+=FrmMain_FormClosing;
        }


        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
        }


        /// <summary>
        /// 锁屏定期器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LockTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (CommonMethod.Config.AutoLock&&islock)
            {
                CommonMethod.tickCount++;
                if (CommonMethod.tickCount>=CommonMethod.Config.LockyPeriod*60*1000/LockTime.Interval)
                {
                    //锁屏
                    LockWorkStation();
                }
            }
        }

        /// <summary>
        /// 锁屏，解锁的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                OnUserUnlock();
            }
        }

        /// <summary>
        /// 配置文件路径
        /// </summary>
        private string path = Application.StartupPath+@"\Config\Device.json";


        /// <summary>
        /// 变量属性的动态集合
        /// </summary>
        private ObservableCollection<string> observableCollection { get; set; } = new ObservableCollection<string>();

        /// <summary>
        ///参数报警系统委托 属性
        /// </summary>
        private Action<SysLogModel> AddAlarmLog { get; set; }

        /// <summary>
        /// 当前时间
        /// </summary>
        private DateTime CurrentTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 锁屏定时器
        /// </summary>
        private static System.Timers.Timer LockTime { get; set; }

        /// <summary>
        /// 消息筛选器
        /// </summary>
        private MessageFilter message { get; set; }

        /// <summary>
        /// 锁屏标志位
        /// </summary>
        private static bool islock { get; set; } = false;
        
        /// <summary>
        /// 数据管理
        /// </summary>
        private DataManage DataManage { get; set; } = new DataManage();

        private string Inserttime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");



        #region 读取Device文件，初始化所有变量，添加变量报警事件，通信PLC，读取数据
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
            this.lbl_UserName.Text=CommonMethod.SysAdminModel.LoginName;
            this.lbl_CurrentTime.Text= DateTime.Now.ToString("yyyy.MM.dd HH:mm ").ToString();
            OpenForm(FormNames.日志报警);
            OpenForm(FormNames.控制流程);

            //读取变量文件
            CommonMethod.PLCDevice=ReadDevice(path).Content;

            //初始化所有变量的值
            CommonMethod.PLCDevice.Init();
            ///长短地址
            CommonMethod.PLC.IsShortAddress=CommonMethod.PLCDevice.IsShortAddress;
            //大小端
            DataFormat df = (DataFormat)CommonMethod.PLCDevice.DataFormat;


            //设定多线程手动取消
            CommonMethod.PLCDevice.CancellationTokenSource=new CancellationTokenSource();

            //变量参数报警
            CommonMethod.PLCDevice.AlarmTriggerEvent+=PLCDevice_AlarmTriggerEvent;


            observableCollection.CollectionChanged+=ObservableCollection_CollectionChanged;


            //从站地址
            CommonMethod.PLC.DevAddress=Convert.ToByte("1");


            Task.Run(() =>
            {
                Connect(CommonMethod.PLCDevice);
            }, CommonMethod.PLCDevice.CancellationTokenSource.Token);

        }

        /// <summary>
        /// 动态集合发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObservableCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //需要根据 actualAlarmList 集合  数量判断
            //为0，没有报警，不显示报警滚动条
            //为1，显示唯一的滚动条，但是不滚动
            //超过1，显示所有报警，滚动显示条
            switch (this.observableCollection.Count)
            {
                case 0:
                    this.AlarmPanel.Visible = false;
                    break;
                case 1:
                    this.AlarmPanel.Visible = true;
                    this.SystemSct.TextScroll=this.observableCollection[0];
                    break;
                default:
                    this.AlarmPanel.Visible = true;
                    this.SystemSct.TextScroll=string.Join("   ", observableCollection);
                    break;
            }
        }

        /// <summary>
        /// 参数报警 委托 方法
        /// </summary>
        /// <param name="model"></param>
        private void AddAlarm(SysLogModel model)
        {
            if (AddAlarmLog!=null)
            {
                AddAlarmLog(model);

            }
        }

        /// <summary>
        /// 报警触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void PLCDevice_AlarmTriggerEvent(object sender, AlarmEventArgs e)
        {
            AddAlarm(new SysLogModel
            {
                InsertTime=CurrentTime.ToString("yyyy-MM-dd HH:mm:ss"),
                LogType="系统报警",
                AlarmSet=e.SetValue,
                AlarmValue=e.CurrentValue,
                Note=e.AlarmNote,
                AlarmType=e.IsTrigger ? "触发" : "消除",
                VarName=e.Name,
                Operator=CommonMethod.SysAdminModel.LoginName,
            });

            if (e.IsTrigger)
            {
                if (!this.observableCollection.Contains(e.AlarmNote))
                {
                    this.observableCollection.Add(e.AlarmNote);
                }
            }
            else
            {
                if (this.observableCollection.Contains(e.AlarmNote))
                {
                    this.observableCollection.Remove(e.AlarmNote);
                }
            }
        }

        #region 读取参数文件，进行通信，读取数据

        /// <summary>
        /// 读取参数文件
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
                        CommonMethod.Addsystemlog(false, "通信成功");
                    }
                    else
                    {
                        if (device.ErrorTimes<=device.AllowErrorTimes)
                        {
                            device.IsConnected = false;
                            SetConnectLed(result);
                            device.ErrorTimes++;
                            CommonMethod.Addsystemlog(true, "通信失败");
                        }
                        else
                        {
                            device.CancellationTokenSource.Cancel();
                        }
                        //new FrmMessageBoxWithOutAck("通信PLC","通信失败，请检查ip地址和端口号").Show();
                    }
                }
                //连接
                else
                {
                    var result = ReadGroup(device);
                    if (result.IsSuccess)
                    {
                        SetConnectLed(true);
                        //清空错误连接次数
                        device.ErrorTimes=0;
                        DataManage.AddData(CommonMethod.PLCDevice.StoreVarList.Select(c=>c.VarName).ToList(),CommonMethod.PLCDevice.StoreVarList.Select(c=>c.VarValue.ToString()).ToList(),Inserttime);
                    }
                    else
                    {
                        SetConnectLed(false);
                        CommonMethod.Addsystemlog(true, "通信失败");
                        device.ErrorTimes++;
                        if (device.ErrorTimes>=device.AllowErrorTimes)
                        {
                            //停止连接通信
                            CommonMethod.PLCDevice.CancellationTokenSource.Cancel();
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


        #endregion

        private System.Timers.Timer lockTime = new System.Timers.Timer();





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
                        CommonMethod.AddSystemLog+=((FrmAlarmLog)frm).AddLog;
                        CommonMethod.AddOperateLog+=((FrmAlarmLog)(frm)).AddOperateLog;
                        AddAlarmLog+=((FrmAlarmLog)(frm)).AddAlarmLog;
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

        #region 锁屏,解锁
        //调用window32的
        [DllImport("user32")]
        private static extern bool LockWorkStation();

        /// <summary>
        /// 消息过滤类
        /// </summary>
        internal class MessageFilter : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                //如果检查到鼠标或者键盘的消息，则基数为0
                if (m.Msg==0x2000||m.Msg==0x201||m.Msg==0x207)
                {
                    CommonMethod.tickCount=0;
                }
                return false;
            }
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnUserUnlock()
        {
            islock =true;

            LockTime.Stop();
            CommonMethod.tickCount=0;
            LockTime.Start();
        }
        #endregion

    }
}
