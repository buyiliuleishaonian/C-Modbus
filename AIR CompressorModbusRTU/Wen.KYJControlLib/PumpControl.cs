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
    [DefaultEvent("PumpDoubleClick")]
    public partial class PumpControl : UserControl
    {
        public PumpControl()
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

        private byte pumpState;
        [Browsable(true)]
        [Category("自定义")]
        [Description("循环泵状态：0,停止，1，运行，2，故障，3，备用")]

        public byte PumpState
        {
            get { return pumpState; }
            set
            {
                pumpState = value;
                switch (pumpState)
                {
                    case 0:
                        this.MainPic.BackgroundImage=Properties.Resources.PumpStop;
                        break;
                    case 1:
                        this.MainPic.BackgroundImage=Properties.Resources.PumpRun;
                        break;
                    case 2:
                        this.MainPic.BackgroundImage=Properties.Resources.PumpFault;
                        break;
                    default:
                        this.MainPic.BackgroundImage=Properties.Resources.PumpSpare;
                        break;
                }
            }
        }

        [Browsable(true)]
        [Category("自定义")]
        [Description("绑定变量名")]
        public string BindVarName { get; set; }

        [Browsable(true)]
        [Category("自定义")]
        [Description("编号")]
        public int PumpIndex { get; set; } = 1;

        [Browsable(true)]
        [Category("自定义事件")]
        [Description("泵的双击触发事件")]
        /// <summary>
        /// 控件双击事件
        /// </summary>
        public event EventHandler PumpDoubleClick;

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPic_DoubleClick(object sender, EventArgs e)
        {
            if (PumpDoubleClick!=null)
            {
                PumpDoubleClick.Invoke(this,e);
            }
        }
    }
}
