using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;
using Wen.ModbusRTUib;
using static System.Windows.Forms.AxHost;

namespace Wen.ModbusProject
{

    public partial class FrmTHMonitor : Form
    {
        /// <summary>
        /// ModbusRTU通信对象
        /// </summary>
        private ModbusRTU modbusRTU = new ModbusRTU();

        /// <summary>
        /// 申请取消请求的多线程
        /// </summary>
        private CancellationTokenSource cts;


        /// <summary>
        ///判断是否连接
        /// </summary>
        private bool IsConnect { get; set; } = false;

        private DataFormat dataFormat = DataFormat.ABCD;

        public FrmTHMonitor()
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
            this.cmbBaudRate.Items.AddRange(new string[] { "2400", "4800", "9600", "19200", "38400" });
            this.cmbBaudRate.SelectedIndex=2;


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
                Add_Log(1, "ModbusRTU已连接");
                return;
            }

            //得到选定的校验,此时的温湿度传感器是固定好的modbus通信
            //默认是9600，无校验位，8位数据，1个停止位
            //判断选择的串口号，波特率，校验，数据位，停止位，是否会连接成功
            IsConnect= modbusRTU.Connect(this.cmbPortName.Text, Convert.ToInt32(this.cmbBaudRate.Text), Parity.None, 8, StopBits.One);

            if (IsConnect)
            {
                Add_Log(0, "温湿度模块连接成功");
                //开启多线程，通过多线程来进行读取，因为这个温湿度传感器只能读取，是无法进行写入的
                //在Task线程中一直检查CanCellationTokenSource这个线程对象，判断这个对象的IsCancellationRequested属性
                //判断是否申请取消，安全的取消某些方法
                cts=new CancellationTokenSource();
                Task.Run(() => { Communication(); }, cts.Token);
            }
            else
            {
                Add_Log(1, "温湿度模块连接失败");
            }
        }

        /// <summary>
        /// 通用写入日志的方法 给ListView显示最新连接信息
        /// </summary>\
        /// <param name="level"></param>
        /// <param name="info"></param>
        private void Add_Log(int level, string info)
        {
            //指定显示初始化ListView的项的文本，以及图片索引
            ListViewItem list = new ListViewItem(DateTime.Now.ToShortDateString(), level);
            list.SubItems.Add(info);

            this.list_Info.Items.Insert(0, list);
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            //?表示条件运算符，当cts为null，则不执行Canel，不为null，则执行Canel
            cts?.Cancel();
            modbusRTU.Disconnect();
            IsConnect=false;
            Add_Log(0, "温湿度模块连接关闭");
        }
        #endregion

        /// <summary>
        /// =实时读取，因为线程Task。RUn一直在检查是否有申请取消，不点中断连接就一直没有申请取消，一直读取
        /// </summary>
        private void Communication()
        {
            try
            {
                //只有当线程cts，请求取消操作的时候
                while (!cts.IsCancellationRequested)
                {

                    byte[] result = modbusRTU.ReadOutPutRegisters(1, 0, 2);
                    if (result!=null&&result.Length==4)
                    {

                        this.Invoke(new Action(() =>
                        {
                            this.lblHum1.Text=((result[0]*256+result[1])*0.1f).ToString();
                            this.lblTem1.Text=((result[2]*256+result[3])*0.1f).ToString();
                        }));
                    }

                    result = modbusRTU.ReadOutPutRegisters(2, 0, 2);
                    if (result!=null&&result.Length==4)
                    {

                        this.Invoke(new Action(() =>
                        {
                            this.lblHum2.Text=((result[0]*256+result[1])*0.1f).ToString();
                            this.lblTem2.Text=((result[2]*256+result[3])*0.1f).ToString();
                        }));
                    }

                     result = modbusRTU.ReadOutPutRegisters(3, 0, 2);
                    if (result!=null&&result.Length==4)
                    {

                        this.Invoke(new Action(() =>
                        {
                            this.lblHum3.Text=((result[0]*256+result[1])*0.1f).ToString();
                            this.lblTem3.Text=((result[2]*256+result[3])*0.1f).ToString();
                        }));
                    }

                     result = modbusRTU.ReadOutPutRegisters(4, 0, 2);
                    if (result!=null&&result.Length==4)
                    {

                        this.Invoke(new Action(() =>
                        {
                            this.lblHum4.Text=((result[0]*256+result[1])*0.1f).ToString();
                            this.lblTem4.Text=((result[2]*256+result[3])*0.1f).ToString();
                        }));
                    }
                }
            }
            //在关闭之时，还在读取，但是它改变控件的属性，控件的窗体已经关闭了，百分百报错
            catch 
            {

            }
        }

        private void FrmTHMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
    }
}
