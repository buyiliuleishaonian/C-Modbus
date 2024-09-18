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
    public partial class Title : UserControl
    {
        public Title()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            this.SetStyle(ControlStyles.DoubleBuffer,true);
            this.SetStyle(ControlStyles.ResizeRedraw,true);
            this.SetStyle(ControlStyles.Selectable,true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor,true);
        }

        private string titleName;
        [Browsable(true)]
        [Category("自定义")]
        [Description("设置或或者")]

        public string TitleName
        {
            get { return titleName; }
            set { titleName = value;
                this.lbl_Title.Text=value;
            }
        }

    }
}
