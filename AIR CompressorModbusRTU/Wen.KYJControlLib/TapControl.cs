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
    [DefaultEvent("DoubleClick")]
    public partial class TapControl : UserControl
    {
        public TapControl()
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


        private int TapState;

        /// <summary>
        /// 控制阀状态
        /// </summary>
        [Browsable(true)]
        [Category("自定义")]
        [Description("控制阀状态,0,停止，1，运行，2，故障，3，备用")]
        public int TapStaTe
        {
            get { return TapState; }
            set { TapState = value;
                switch (TapState)
                {
                    case 0:
                        this.BackgroundImage=Properties.Resources.TapStop;
                        break;
                        case 1:
                        this.BackgroundImage=Properties.Resources.TapRun;
                        break;
                        case 2:
                        this.BackgroundImage=Properties.Resources.TapFault;
                        break;
                    default:
                        this.BackgroundImage=Properties.Resources.TapSpare;
                        break;
                }
            }
        }

        /// <summary>
        /// 绑定变量名
        /// </summary>
        [Browsable(true)]
        [Category("自定义")]
        [Description("绑定变量名")]
        public string BindVarName { get; set; }

    }
}
