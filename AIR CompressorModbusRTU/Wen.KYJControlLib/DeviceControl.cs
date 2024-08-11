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
    [DefaultEvent("DeviceControlClick")] 
    public partial class DeviceControl : UserControl
    {
        public DeviceControl()
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


        private string  closeAddress;
        [Browsable(true)]
        [Category("自定义")]
        [Description("关闭地址")]


        public string CloseAddress
        {
            get { return closeAddress; }
            set { closeAddress = value;
                this.btn_Close.Tag=value;
            }
        }

        private string openAddress;
        [Browsable(true)]
        [Category("自定义")]
        [Description("启动地址")]

        public string OpenAddress
        {
            get { return openAddress; }
            set { openAddress = value;
                this.btn_Open.Tag=value;
            }
        }

        private string deviceState;
        [Browsable(true)]
        [Category("自定义")]
        [Description("状态地址")]

        public string DeviceState
        {
            get { return deviceState; }
            set { deviceState = value; }
        }

        private byte state;
        [Browsable(true)]
        [Category("自定义")]
        [Description("状态值")]

        public byte State
        {
            get { return state; }
            set { state = value;
                this.deviceState1.StaTe=state;
            }
        }

        private string bindVarName;
        [Browsable(true)]
        [Category("自定义")]
        [Description("绑定设备名称")]

        public string BindVarName
        {
            get { return bindVarName; }
            set { bindVarName = value;
                this.lbl_Title.Text=bindVarName;
            }
        }

        [Browsable(true)]
        [Category("自定义")]
        [Description("单击触发事件")]
        public event EventHandler DeviceControlClick;

        /// <summary>
        /// 给控件默认事件传 触发值和数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (DeviceControlClick!=null)
            {
                DeviceControlClick.Invoke(this.OpenAddress,e);
            }
        }

        /// <summary>
        /// 给控件默认事件传 触发值和数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (DeviceControlClick!=null)
            {
                DeviceControlClick.Invoke(this.CloseAddress, e);
            }
        }
    }
}
