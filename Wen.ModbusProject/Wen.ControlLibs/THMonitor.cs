using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wen.ControlLibs
{
    public partial class THMonitor : UserControl
    {
        public THMonitor()
        {
            InitializeComponent();
        }

        //首先定义对应groupBox的name的属性
        private string _initialName;
        [Browsable(true)]//显示可见
        [Category("自定义")]//对应的类别
        [Description("对应温湿度模块地址")]//其控件的含义
        public string InitialName
        {
            get { return _initialName; }
            set
            {
                _initialName = value;
                this.gb_Control.Text=$"温湿度模块{_initialName}";
            }
        }


        //创建对应温度，湿度的属性
        private string _tem = "0";
        [Browsable(true)]
        [Category("自定义")]
        [Description("读取对应的温度")]
        public string Tem
        {
            get { return _tem; }
            set
            {
                if (_tem != value)
                {
                    _tem= value;
                    //InvokeRequired表示调用控件方法的时候是否需要跨线程访问
                    if (this.gb_Control.InvokeRequired)
                    {
                        this.Invoke(new Action(() => { this.lblTem.Text=value; }));
                    }
                }
            }
        }

        private string _hum = "0";
        [Browsable(true)]
        [Category("自定义")]
        [Description("读取对应的湿度")]
        public string Hum
        {
            get { return _hum; }
            set
            {
                if (_hum != value)
                {
                    _hum= value;
                    //InvokeRequired表示调用控件方法的时候是否需要跨线程访问
                    if (this.gb_Control.InvokeRequired)
                    {
                        this.Invoke(new Action(() => { this.lblHum.Text=value; }));
                    }
                }
            }
        }
    }
}
