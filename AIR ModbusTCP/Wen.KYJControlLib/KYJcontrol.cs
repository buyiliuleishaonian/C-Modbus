using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wen.KYJControlLib
{
    public partial class KYJcontrol : UserControl
    {
        public KYJcontrol()
        {
            InitializeComponent();
            //减少闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //是否可以被选中
            this.SetStyle(ControlStyles.Selectable, true);
            //是否可以绘制控件大小
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //控件背景
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private byte kyjState;
        [Browsable(true)]
        [Category("自定义")]
        [Description("空压机状态,0,停止，1，运行，2，故障，3，备用")]

        public byte KYJState
        {
            get { return kyjState; }
            set
            {
                kyjState = value;
                switch (kyjState)
                {
                    case 0:
                        this.KYJpic.BackgroundImage=Properties.Resources.KYJStop;
                        break;
                    case 1:
                        this.KYJpic.BackgroundImage=Properties.Resources.KYJRun;
                        break;
                    case 2:
                        this.KYJpic.BackgroundImage=Properties.Resources.KYJFault;
                        break;
                    default:
                        this.KYJpic.BackgroundImage=Properties.Resources.KYJSpare;
                        break;
                }
            }
        }
    }
}
