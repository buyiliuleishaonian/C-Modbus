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
    public partial class DeviceState : UserControl
    {
        public DeviceState()
        {
            InitializeComponent();
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

        private int state;

        /// <summary>
        /// 控制阀状态
        /// </summary>
        [Browsable(true)]
        [Category("自定义")]
        [Description("控制阀状态,0,停止，1，运行，2，故障，3，备用")]
        public int  StaTe
        {
            get { return state; }
            set
            {
                state = value;
                switch (state)
                {
                    case 0:
                        this.BackgroundImage=Properties.Resources.Stop;
                        break;
                    case 1:
                        this.BackgroundImage=Properties.Resources.Run;
                        break;
                    case 2:
                        this.BackgroundImage=Properties.Resources.Fault;
                        break;
                    default:
                        this.BackgroundImage=Properties.Resources.Spare;
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
