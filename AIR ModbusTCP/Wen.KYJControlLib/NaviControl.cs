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

    /// <summary>
    /// 窗体枚举
    /// </summary>
    /// <remark>
    /// 选择窗体枚举
    /// </remark>
    public enum FormNames
    {
        控制流程,
        日志报警,
        临时界面,
        日志查询,
        参数设置,
        实时趋势,
        历史趋势,
        数据报表,
        用户管理,
        退出系统
    }
    public partial class NaviControl : UserControl
    {
        public NaviControl()
        {
            InitializeComponent();
            //减少闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            this.SetStyle(ControlStyles.DoubleBuffer,true);
            //是否可以被选中
            this.SetStyle(ControlStyles.Selectable,true);
            //是否可以绘制控件大小
            this.SetStyle(ControlStyles.ResizeRedraw,true);
            //控件背景
            this.SetStyle(ControlStyles.SupportsTransparentBackColor,true);
            BindClick();
        }

        
        [Browsable(true)]
        [Category("自定义")]
        [Description("选择按钮切换事件")]
        public event Func<object, EventArgs, bool> SelectButtonForm;

        /// <summary>
        /// 窗体通用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CommonClick(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (Enum.IsDefined(typeof(FormNames),button.Text))
                {
                    FormNames formNames=(FormNames)Enum.Parse(typeof(FormNames),button.Text);
                    if (SelectButtonForm!=null&&SelectButtonForm(formNames,e)==true)
                    {
                        SetButton(formNames);
                    }
                }
            }
        }

        /// <summary>
        /// 绑定Button共同的事件
        /// </summary>
        public void BindClick()
        {
            foreach (var item in this.panelEnhanced1.Controls)
            {
                if (item is Button button)
                {
                    if (Enum.IsDefined(typeof(FormNames),button.Text))
                    {
                        button.Click+=btn_CommonClick;
                    }
                }
            }
        }

        /// <summary>
        /// 更到对应的按钮显示样式
        /// </summary>
        /// <param name="formNames"></param>
        public void SetButton(FormNames formNames)
        {
            foreach (var item in this.panelEnhanced1.Controls)
            {
                if (item is Button button)
                {
                    if (button.Text==formNames.ToString())
                    {
                        button.Font = new System.Drawing.Font("微软雅黑", 12.5F, System.Drawing.FontStyle.Bold);
                        button.ForeColor=System.Drawing.Color.Cyan;
                    }
                    else
                    {
                        button.Font =new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                       button.ForeColor= System.Drawing.Color.White;
                    }
                }
            }  
        }
    }
}
