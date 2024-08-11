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


namespace AIR_CompressorModbusRTU
{
    public partial class FrmPumpControl : Form
    {
        public FrmPumpControl(int pumpIndex)
        {
            InitializeComponent();
            this.lbl_Title.Text = pumpIndex.ToString()+"#冷却循环泵监控";
            this.textShow1.BindVarName=$"LQB{pumpIndex}_Current";
            this.textShow2.BindVarName=$"LQB{pumpIndex}_Speed";
            this.textShow3.BindVarName=$"LQB{pumpIndex}_TotalPower";
            this.textShow4.BindVarName=$"LQB{pumpIndex}_HeaterTemp";
            this.textShow5.BindVarName=$"LQB{pumpIndex}_Fre";
            this.textShow6.BindVarName=$"LQB{pumpIndex}_Power";
            this.textShow7.BindVarName=$"LQB{pumpIndex}_RunHour";

            this.simpleLed1.BindVarName=$"LQB{pumpIndex}_RunState";
            this.simpleLed2.BindVarName=$"LQB{pumpIndex}_FaultState";

            this.btn_Mode.Tag=$"LQB{pumpIndex}_Mode";
            this.btn_Run.Tag=$"LQB{pumpIndex}_Start";
            this.btn_Stop.Tag=$"LQB{pumpIndex}_Stop";

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
        /// 控件属性刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateControl(this.panelEnhanced1);

            bool value = false;
            if (bool.TryParse(CommonMethod.PLCDevice.CurrentValue[ this.btn_Mode.Tag.ToString()].ToString(),out value))
            {
                this.btn_Mode.Text=value ? "自动模式" : "手动模式";
                this.btn_Stop.Enabled=this.btn_Run.Enabled=!value;
            }
        }

        /// <summary>
        /// 改变控件属性
        /// </summary>
        /// <param name="panelControl"></param>
        private void UpdateControl(Control panelControl)
        {
            foreach (Control control in panelControl.Controls) 
            {
                if (control is TextShow textShow)
                {
                    if (textShow.BindVarName.Length>0)
                    {
                        float value = 0.0f;
                        if (float.TryParse(CommonMethod.PLCDevice.CurrentValue[textShow.BindVarName].ToString(), out value))
                        {
                            textShow.CurrentValue=value.ToString("f1");
                        }
                    }
                }
                else if (control is SimpleLed led)
                {
                    if (led.BindVarName.Length>0)
                    {
                        bool value = false;
                        if (bool.TryParse(CommonMethod.PLCDevice.CurrentValue[led.BindVarName].ToString(), out value))
                        {
                            led.State = value;
                        }
                    }
                }
            }
        }

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
        /// 模式取反
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Mode_Click(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                if (btn.Tag!=null&&btn.Tag.ToString().Length>0)
                {
                    CommonMethod.CommonWrite(btn.Tag.ToString(), (btn.Text!="自动模式").ToString());
                }
            }
        }


        /// <summary>
        /// 手动模式下启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OP_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Tag!=null&&btn.Tag.ToString().Length>0)
                {
                    CommonMethod.CommonWrite(btn.Tag.ToString(),"true");

                    Thread.Sleep(100);
                   CommonMethod.CommonWrite(btn.Tag.ToString(), "false");
                }
            }
        }
    }
}
