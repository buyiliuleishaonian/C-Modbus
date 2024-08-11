using ConfigLib;
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
using thinger.ControlLib;
using Wen.KYJControlLib;

namespace AIR_CompressorModbusRTU
{
    public partial class FrmTapControl : Form
    {
        public FrmTapControl()
        {
            InitializeComponent();

            Timer=new System.Windows.Forms.Timer();
            Timer.Interval=200;
            Timer.Tick+=Timer_Tick;
            Timer.Start();

            this.FormClosing+=(send, e) =>
            {
                this.Timer.Stop();
            };
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateControl(this.panelEnhanced1);
        }

        /// <summary>
        /// 更新控件属性
        /// </summary>
        /// <param name="panelControl"></param>
        private void UpdateControl(Control panelControl)
        {
            foreach (Control control in panelControl.Controls)
            {
                if (control is DeviceControl deviceControl)
                {
                    if (deviceControl.DeviceState.Length>0)
                    {
                        byte value = 0;
                        if (Byte.TryParse(CommonMethod.PLCDevice.CurrentValue[deviceControl.DeviceState].ToString(),out value))
                        {
                            deviceControl.State = value;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 定时器
        /// </summary>
        private System.Windows.Forms.Timer Timer;
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


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

        /// <summary>
        /// 单击触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonDevice_DeviceControlClick(object sender, EventArgs e)
        {
            if (CommonMethod.CommonWrite(sender.ToString(), "True").IsSuccess)
            {
                CommonMethod.AddLog(true, $"写入成功");
                VariableBase varible= CommonMethod.PLCDevice.VarList.Find(c => c.VarName==sender.ToString());
                Thread.Sleep(100);
                if (!CommonMethod.CommonWrite(sender.ToString(), "false").IsSuccess)
                {
                    CommonMethod.AddLog(true, $"变量{sender.ToString()}不存在");
                }
                else
                {
                    CommonMethod.AddLog(true, $"写入成功");
                }
            }
            else
            {
                 CommonMethod.AddLog(true, $"变量{sender.ToString()}不存在"); ;
            }
        }
    }
}