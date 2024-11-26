using CommonHelper;
using ConfigLib;
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

using System.Timers;

namespace AIR_ModbusTCP
{
    public partial class FrmMonitor : Form
    {
        /// <summary>
        /// 修改控件动画时间
        /// </summary>
        private System.Timers.Timer UpdateTimer = null;
        public FrmMonitor()
        {
            InitializeComponent();
            UpdateTimer=new System.Timers.Timer();
            UpdateTimer.Interval=200;
            UpdateTimer.Elapsed+=UpdateTimer_Elapsed;
            UpdateTimer.Start();


            this.FormClosing+=(send, e) =>
            {
                this.UpdateTimer?.Stop();
            };


        }

        /// <summary>
        /// 时间间隔所发生的事情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (CommonMethod.PLCDevice.IsConnected)
                {
                    foreach (var item in this.panelEnhanced3.Controls)
                    {
                        if (item is TextShow txt)
                        {
                            if (txt.BindVarName!=null&&txt.BindVarName.Length>0)
                            {
                                var result = CommonMethod.PLCDevice.VarList.First(c => c.VarName==txt.BindVarName);
                                txt.CurrentValue=result.VarValue==null ? "0.0" : result.VarValue.ToString();
                            }
                        }
                        else if (item is PumpControl pump)
                        {
                            var result = CommonMethod.PLCDevice.VarList.First(c => c.VarName==pump.BindVarName).VarValue;
                            this.Invoke(new Action(() =>
                            {
                                pump.PumpState=Convert.ToByte(result);
                            }));
                        }
                        else if (item is TapControl tap)
                        {
                            var result = CommonMethod.PLCDevice.VarList.First(c => c.VarName==tap.BindVarName).VarValue;
                            this.Invoke(new Action(() =>
                            {
                                tap.TapStaTe=Convert.ToInt32(result);
                            }));
                        }
                    }
                }
            }));

        }

        
        /// <summary>
        /// 显示控制阀
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tapCommon_DoubleClick(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                if (sender is TapControl tap)
                {
                    if (tap.BindVarName.ToString().Trim().Length>0&&tap.BindVarName!=null)
                    {
                        FrmTapControl frm = new FrmTapControl();
                        frm.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// 冷却泵参数，状态显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pumpCommon_PumpDoubleClick(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                if (sender is PumpControl pump)
                {
                    var variable = CommonMethod.PLCDevice.VarList.Where(c => c.VarName==pump.BindVarName).First();
                    FrmPump frm = new FrmPump(pump.BindVarName);
                    frm.ShowDialog();
                }
            }
        }


    }
}
