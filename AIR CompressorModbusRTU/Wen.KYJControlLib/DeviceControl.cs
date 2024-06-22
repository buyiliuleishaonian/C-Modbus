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
    public partial class DeviceControl : UserControl
    {
        public DeviceControl()
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
    }
}
