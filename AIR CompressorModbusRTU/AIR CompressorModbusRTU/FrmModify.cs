using ConfigLib;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.ControlLib;

namespace AIR_CompressorModbusRTU
{
    public partial class FrmModify : Form
    {
        public FrmModify(VariableBase variable)
        {
            InitializeComponent();
            this.lbl_VarName.Text= variable.VarName;
            this.lbl_CurrentValue.Text=variable.VarValue==null ? "0.0" : variable.VarValue.ToString();

            Variable=variable;
        }

        private VariableBase Variable = new VariableBase();

        #region 无边框移动
        private Point point;
        /// <summary>
        /// 得到鼠标左键的坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FraMain_MouseDown(object sender, MouseEventArgs e)
        {
            point=new Point(e.X, e.Y);
        }

        /// <summary>
        /// 通过鼠标移动的距离，加上窗体左上角坐标，减去鼠标坐标就是同步移动了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FraMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                this.Location=new Point(this.Location.X+e.X-point.X, this.Location.Y+e.Y-point.Y);
            }
        }
        #endregion

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            var result = CommonMethod.CommonWrite(Variable.VarName, this.txt_VarValueSet.Text);
            if (result.IsSuccess)
            {
                CommonMethod.AddOpLog(false, $"修改{this.lbl_VarName.Text}数据成功为{this.txt_VarValueSet.Text}"+"  "+$"源原数据为{this.lbl_CurrentValue.Text}");
            }
            else
            {
                CommonMethod.AddOpLog(true, "修改数据失败"+$"失败原因是{result.Message}");
            }
        }

        /// <summary>
        /// 返回值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumKeyboard_EnterClick(object sender, EventArgs e)
        {
            if (sender is NumKeyboard num)
            {
                this.txt_VarValueSet.Text=num.InitialValue;
                this.Controls.Remove(num);
            }
        }

        /// <summary>
        /// 取消设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumKeyboard_ESCClick(object sender, EventArgs e)
        {
            if (sender is NumKeyboard num)
            {
                this.Controls.Remove(num);
            }
        }

        private void txt_VarValueSet_Click(object sender, EventArgs e)
        {

            if (this.Controls["numKey"]!=null)
            {
                this.Controls["numKey"].BringToFront();
            }
            else
            {
                NumKeyboard numKeyboard = new NumKeyboard();
                numKeyboard.Name="numKey";
                numKeyboard.Location=new Point((this.Width-numKeyboard.Width)/2, (this.Height-numKeyboard.Width)/2);
                numKeyboard.MaxValue=100.0f;
                numKeyboard.MinValue=-100.0f;
                numKeyboard.InitialValue=this.lbl_CurrentValue.Text;

                //添加事件
                numKeyboard.ESCClick+=NumKeyboard_ESCClick;
                numKeyboard.EnterClick+=NumKeyboard_EnterClick;
                //添加到窗体控件中，并置顶
                this.Controls.Add(numKeyboard);
                numKeyboard.BringToFront();
            }
        }
    }
}
