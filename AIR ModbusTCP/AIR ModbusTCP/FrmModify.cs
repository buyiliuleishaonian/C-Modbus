using ConfigLib;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.ControlLib;

namespace AIR_ModbusTCP
{
    public partial class FrmModify : Form
    {
        public FrmModify(string varname)
        {
            InitializeComponent();

            var=CommonMethod.PLCDevice.VarList.Where(c=>c.VarName==varname).First();    
            this.lbl_CurrentValue.Text = var.VarValue.ToString();
            this.lbl_VarName.Text = var.VarName.ToString();
        }

        private VariableBase var=new VariableBase();
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.txt_VarValueSet.Text!=null&&this.txt_VarValueSet.Text.Trim().Length>0)
            {
               var result=  CommonMethod.WritePLC(var.VarAddress,this.txt_VarValueSet.Text);
                if (result.IsSuccess)
                {
                    CommonMethod.Addoperatelog(false, $"修改{var.Comments}的值为{this.txt_VarValueSet.Text}");
                    this.DialogResult=DialogResult.OK;
                }
                else
                {
                    CommonMethod.Addoperatelog(true, $"修改{var.Comments}的值失败，原因为{result.Message}");
                }
            }
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.No;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.No;
        }


        #region 窗体移动
        private Point size;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                size=new Point(e.X, e.Y);
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                this.Location=new Point(this.Location.X+e.X-size.X, this.Location.Y+e.Y-size.Y);
            }
        }
        #endregion

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

        private void NumKeyboard_EnterClick(object sender, EventArgs e)
        {
            if (sender is NumKeyboard num)
            {
                this.txt_VarValueSet.Text=num.ResultValue;
                this.Controls.Remove(num);
            }
        }

        private void NumKeyboard_ESCClick(object sender, EventArgs e)
        {
            if (sender is NumKeyboard num)
            {
                this.Controls.Remove(num);
            }
        }
    }
}

