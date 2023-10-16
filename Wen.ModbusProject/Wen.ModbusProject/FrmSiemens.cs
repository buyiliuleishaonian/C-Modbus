using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wen.ModbusTCPLib;

namespace Wen.ModbusProject
{
    public partial class FrmSiemens : Form
    {
        public FrmSiemens()
        {
            InitializeComponent();
        }
        //创建一个ModbusTCP通信对象
        private ModbusTCP modbusTCP=new  ModbusTCP();

        //创建一个当前连接状态
        private bool IsConnect = false;

        //取消线程源
        private CancellationTokenSource cts=null;

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //在连接之后，要一直读取，所以通过线程，之后委托中ladam委托一个方法，进行一直读取
            if (IsConnect)
            {
                MessageBox.Show("西门子PLC已连接");
                return;
            }
            IsConnect=modbusTCP.Connect(this.txtIP.Text,Convert.ToInt32( this.txtPort.Text));
            if (IsConnect)
            {
                MessageBox.Show("西门子PLC已连接");
                cts=new CancellationTokenSource();
                Task.Run(
                    new Action(()=>{ PLCCommuniAction() }),cts.Token);
            }
        }

        /// <summary>
        /// 多线程循环执行方法
        /// </summary>
        private void PLCCommuniAction()
        {
            while (!this.cts.IsCancellationRequested)
            {
                modbusTCP.ReadOutPutRegisters(0, 172);
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            if (IsConnect)
            {
                this.cts?.Cancel();
                modbusTCP.DisConnect();
                MessageBox.Show("西门子PLC连接已关闭");
                return;
            }
        }

        
    }
}
