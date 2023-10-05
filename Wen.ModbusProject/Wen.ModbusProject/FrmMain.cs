using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.ModbusRTUib;

namespace Wen.ModbusProject
{
    //自己构建存储区的枚举 enum

    /// <summary>
    /// 存储区的枚举类型
    /// </summary>
    public enum StoreArea
    {
        输入线圈1X,
        输出线圈0X,
        输入寄存器3X,
        输出寄存器4X
    }
    public partial class FrmMain : Form
    {
        /// <summary>
        /// ModbusRTU通信对象
        /// </summary>
        private ModbusRTU modbusRTU=new ModbusRTU();

        /// <summary>
        ///判断是否连接
        /// </summary>
        private bool IsConnect = false;

        public FrmMain()
        {
            InitializeComponent();
            InitParam();
        }

        #region  参数初始化
        private void InitParam()
        {
            //获得本机上的端口号
            string[] portName = SerialPort.GetPortNames();
            this.cmbPortName.Items.AddRange(portName);
            this.cmbPortName.SelectedIndex = 0;

            //添加波特率
            this.cmbBaudRate.Items.AddRange(new string[] { "2400","4800","9600","19200","38400"});
            this.cmbBaudRate.SelectedIndex=2;

            //获取所有校验位，枚举类型
            this.cmbParity.DataSource=Enum.GetNames(typeof(Parity));
            this.cmbParity.SelectedIndex=0;

            //停止位 枚举类型
            this.cmbStopBits.DataSource=Enum.GetNames(typeof(StopBits));
            this.cmbStopBits.SelectedIndex=1;

            //数据位  
            this.cmbDataBits.Items.AddRange(new string[] { "7","8"});
            this.cmbDataBits.SelectedIndex=1;

            //大小端  枚举类型DataFormat,
            //它是一种关于多字节数据类型中字节排列顺序的表示方式
            this.cmbDataFormat.DataSource=Enum.GetNames(typeof(DataFormat));
            this.cmbDataFormat.SelectedIndex=0;

            //存储区 输入线圈1X，输出线圈0X，输入寄存器3X，输出寄存器4X
            this.cmbStoreArea.DataSource=Enum.GetNames(typeof(StoreArea));
            this.cmbStoreArea.SelectedIndex=0;

            //数据类型 枚举类型
            this.cmbDataType.DataSource=Enum.GetNames(typeof(DataType));
            this.cmbDataType.SelectedIndex=0;

            //动态修改ListView的Coulmns某列的宽度
            this.list_Info.Columns[1].Width=this.list_Info.Width-this.list_Info.Columns[0].Width-48;
        }
        #endregion

        #region  连接，关闭连接，写入日志

        /// <summary>
        /// 连接从站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (IsConnect)
            {
                Add_Log(1,"ModbusRTU已连接");
                return;
            }
            //得到选定的校验
            Parity parity = (Parity)Enum.Parse(typeof(Parity),this.cmbParity.Text,true);
            StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits),this.cmbStopBits.Text,true);
            IsConnect= modbusRTU.Connect(this.cmbPortName.Text, Convert.ToInt32(this.cmbBaudRate.Text), parity, Convert.ToInt32(this.cmbDataBits.Text),stopBits);
            if (IsConnect)
            {
                Add_Log(0, "ModbusRTU连接成功");
                return;
            }
            else
            {
                Add_Log(1, "ModbusRTU连接失败");
                return;
            }
        }

        /// <summary>
        /// 通用写入日志的方法 给ListView显示最新连接信息
        /// </summary>
        /// <param name="level"></param>
        /// <param name="info"></param>
        private void Add_Log(int level,string info)
        {
            ListViewItem list = new ListViewItem(DateTime.Now.ToShortDateString(),level);
            list.SubItems.Add(info);

            this.list_Info.Items.Insert(0,list);
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            modbusRTU.Disconnect();
            IsConnect=false;
            Add_Log(0,"ModbusRTU连接关闭");
        }
        #endregion
    }
}
