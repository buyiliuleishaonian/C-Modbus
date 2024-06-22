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

namespace AIR_CompressorModbusRTU
{
    public partial class FrmMonitor : Form
    {
        public FrmMonitor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示冷却循环泵参数，状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pumpControl1_PumpDoubleClick(object sender, EventArgs e)
        {
            if (sender is PumpControl pump)
            {
                int pumpIndex = pump.PumpIndex;
                if (pumpIndex>0)
                {
                    FrmPumpControl frm =new FrmPumpControl(pumpIndex);
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
