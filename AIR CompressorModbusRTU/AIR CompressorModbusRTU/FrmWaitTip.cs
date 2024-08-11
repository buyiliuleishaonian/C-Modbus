using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIR_CompressorModbusRTU
{
    public partial class FrmWaitTip : Form
    {
        public FrmWaitTip()
        {
            InitializeComponent();
        }

        private Point newPoint=new Point(); 
        /// <summary>
        /// 获得鼠标点动的坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelEnhanced1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button is MouseButtons.Left)
            {
                newPoint.X=e.X;
                newPoint.Y=e.Y; 
            }
        }

        /// <summary>
        /// 移动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelEnhanced1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button is MouseButtons.Left)
            {
               this.Location=new Point( this.Location.X+ e.Location.X-newPoint.X,this.Location.Y+e.Location.Y-newPoint.Y);

            }
        }
    }
}
