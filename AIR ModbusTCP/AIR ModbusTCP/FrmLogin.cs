using AIR_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIR_ModbusTCP
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 用户逻辑层
        /// </summary>
        private SysAdminManage SysAdminManage { get; set; } = new SysAdminManage(); 

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this?.Close();
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            if (this.txt_UserName.Text==null&&txt_UserName.Text.Trim().Length<=0)
            {
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("登入详情","没有输入用户名");
                frm.ShowDialog();
                return;
            }
            if (this.txt_PassWord.Text==null&&txt_PassWord.Text.Trim().Length<=0)
            {
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("登入详情", "没有输入密码");
                frm.ShowDialog();
                return;
            }
              CommonMethod.SysAdminModel=   SysAdminManage.SelectUser(this.txt_UserName.Text,this.txt_PassWord.Text);
            if (CommonMethod.SysAdminModel==null)
            {
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("登入详情", $"不存在此用户{this.txt_UserName.Text}");
                frm.ShowDialog();

                return;
            }
            else
            {
                
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
