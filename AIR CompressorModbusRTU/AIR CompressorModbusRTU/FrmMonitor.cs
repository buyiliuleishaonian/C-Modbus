using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.ControlLib;
using Wen.KYJControlLib;

namespace AIR_CompressorModbusRTU
{
    public partial class FrmMonitor : Form
    {
        public FrmMonitor()
        {
            InitializeComponent();
            UpdateTimer=new Timer();
            UpdateTimer.Interval=200;
            UpdateTimer.Tick+=UpdateTimer_Tick;
            UpdateTimer.Start();    

            this.FormClosing+=(send, e) =>
            {
                this.UpdateTimer?.Stop();
            };
        }

        /// <summary>
        /// 更新实时数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateControlValue(this.panelEnhanced3);
        }

        /// <summary>
        /// 更改实际值
        /// </summary>
        private void UpdateControlValue(Control panelControl)
        {
            if (CommonMethod.PLCDevice!=null&&CommonMethod.PLCDevice.IsConnected)
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
                    else if ( control is PumpControl pump)
                    {
                        if (pump.BindVarName.Length>0)
                        {
                            byte value = 0;
                            if (byte.TryParse(CommonMethod.PLCDevice.CurrentValue[pump.BindVarName].ToString(), out value))
                            {
                                pump.PumpState=value;
                            }
                        }
                    }
                    else if (control is TapControl tap)
                    {
                        if (tap.BindVarName.Length>0 )
                        {
                            byte value = 0;
                            if (byte.TryParse(CommonMethod.PLCDevice.CurrentValue[tap.BindVarName].ToString(), out value))
                            {
                                tap.TapStaTe=value;
                            }
                        }
                    }
                }
            }
        }

        private Timer UpdateTimer;

        /// <summary>
        /// 显示冷却循环泵参数，状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pumpCommon_PumpDoubleClick(object sender, EventArgs e)
        {
            if (sender is PumpControl pump)
            {
                int pumpIndex = pump.PumpIndex;
                if (pumpIndex>0)
                {
                    FrmPumpControl frm = new FrmPumpControl(pumpIndex);
                    frm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 显示控制阀
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tapCommon_DoubleClick(object sender, EventArgs e)
        {
            if (sender is TapControl tap)
            {
                FrmTapControl frm = new FrmTapControl();
                frm.ShowDialog();
            }
        }
    }
}
