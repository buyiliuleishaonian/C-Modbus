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

namespace AIR_ModbusTCP
{
    public partial class FrmTapControl : Form
    {
        public FrmTapControl()
        {
            InitializeComponent();

            Initial();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                foreach (var item in this.panelEnhanced1.Controls)
                {
                    if (item is DeviceControl dev)
                    {
                        var result1 = CommonMethod.PLCDevice.GroupList[0].VarList.First(c => c.VarName==dev.DeviceState).VarValue;
                        dev.State=Convert.ToByte(result1);
                    }
                }
            }
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this?.Close();
        }

        /// <summary>
        /// 控制阀的开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceCommon_DeviceControlClick(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                if (sender.ToString().ToLower().Contains("close"))
                {
                    foreach (var item in this.panelEnhanced1.Controls)
                    {
                        if (item is DeviceControl dev)
                        {
                            if (dev.CloseAddress==sender.ToString())
                            {
                                dev.State =Convert.ToByte("0");

                            }
                        }
                    }
                }
                else if (sender.ToString().ToLower().Contains("open"))
                {
                    foreach (var item in this.panelEnhanced1.Controls)
                    {
                        if (item is DeviceControl dev)
                        {
                            if (dev.OpenAddress==sender.ToString())
                            {
                                dev.State =Convert.ToByte("1");
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }

    }
}
