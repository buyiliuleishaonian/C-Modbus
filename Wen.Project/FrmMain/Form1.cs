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
using Wen.ModbusRTUib;

namespace FrmMain
{
    public partial class Form1 : Form
    {
        private ModbusRTU mdr=new ModbusRTU();
        public Form1()
        {
            InitializeComponent();
            //下拉框绑定波特率和端口号
            Init();
        }

        /// <summary>
        /// 初始化窗体中的端口号和波特率下拉列表
        /// </summary>
        private void Init()
        {
            //绑定波特率和当前电脑端口号
            string[] BaudRate ={ "2400","4800","9600"," 19200","38400","57600","115200"};
            this.cboBudRate.Items.AddRange(BaudRate);
            this.cboBudRate.SelectedIndex=2;//默认为9600

            this.cboPortName.DataSource=SerialPort.GetPortNames();
            this.cboPortName.SelectedIndex=-1;
        }


        private bool _isConnect = false;
        /// <summary>
        /// 判断是否连接，并且保存连接状态
        /// </summary>
        private bool IsConnect 
        {
            get { return _isConnect; } 
            set {
                _isConnect = value;
                if (value)
                {
                    this.btnCommit.Text="断开连接";
                    this.btnCommit.BackColor=Color.Red;
                }
                else
                {
                    this.btnCommit.Text="连接设备";
                    this.btnCommit.BackColor=Color.Green;
                }
            }
        }

        /// <summary>
        /// 打开连接，关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommit_Click(object sender, EventArgs e)
        {
            //在连接之间需要判断是否选择了COM端口号，从站地址，初始寄存器地址，寄存器数量
            if (this.cboPortName.Text==null||this.cboPortName.Text.Trim().Length==0)
            {
                MessageBox.Show("请选择串口号");
                this.cboPortName.Text= null;
                this.cboPortName.Focus();
                return;
            }
            //判断是否输入了设备地址，以及需要判断是否输入的是正整数
            if (this.nudSlaveID.Value<0)
            {
                MessageBox.Show("请输入正确的设备地址");
                this.nudSlaveID.Value=0;
                this.nudSlaveID.Focus();    
                return;
            }
            if (!DataValidate.IsInteger(this.nudSlaveID.Value.ToString()))
            {
                MessageBox.Show("请输入正整数");
                this.nudSlaveID.Value=0;
                this.nudSlaveID.Focus();
                return;
            }
            if (this.txtRegister.Text==null||this.txtRegister.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入初始寄存器的地址，十进制");
                this.txtRegister.Text=null;
                this.txtRegister.Focus();
                return;
            }

            if (!DataValidate.IsInteger( this.txtRegister.Text)&&Convert.ToInt32( this.txtRegister.Text)<0)
            {
                MessageBox.Show("请输入包含0的正整数初始寄存器");
                this.txtRegisterNumbers.Text=null;
                this.txtRegisterNumbers.Focus();
                return;
            }
            if (this.txtRegisterNumbers.Text==null||this.txtRegisterNumbers.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入寄存器数量");
                this.txtRegisterNumbers.Text=null;
                this.txtRegisterNumbers.Focus();
                return;
            }

            if (!DataValidate.IsInteger(this.txtRegisterNumbers.Text.ToString()))
            {
                MessageBox.Show("寄存器地址请输入正整数");
                this.txtRegisterNumbers.Text=null;
                this.txtRegisterNumbers.Focus();
                return;
            }

            if (!IsConnect)
            {
                try
                {
                    IsConnect=true;
                    mdr.Connect(this.cboPortName.Text, Convert.ToInt32(this.cboBudRate.Text));
                    this.timer_Read. Enabled = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message+"错误提示");
                }
            }
            else
            {
                //关闭连接

                IsConnect = false;
                this.timer_Read.Enabled = false;
                mdr.Disconnect();
            }
        }

        /// <summary>
        /// 每隔1秒就查询一次从站信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] receiveData= mdr.ReadHoldingRegister((byte)this.nudSlaveID.Value,Convert.ToInt32( this.txtRegister.Text),Convert.ToInt32(this.txtRegisterNumbers.Text));

            this.lblWen.Text=((receiveData[0]*256+receiveData[1])*0.1).ToString();
            this.lblShi.Text=((receiveData[2]*256+receiveData[3])*0.1).ToString();
        }

        /// <summary>
        /// 如果当前，没有关闭连接，但是已经关闭窗体
        /// 所以提前关闭连接和Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mdr.Disconnect();
            this.timer_Read.Stop();
        }
    }
}
