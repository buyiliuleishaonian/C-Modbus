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
            this.Load+=FrmLogin_Load;
        }

        /// <summary>
        /// 自动登入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ReadConfig();
            if (CommonMethod.Config.AutoLogin)
            {
                btn_LogIn_Click(null, null); 
            }
        }

        /// <summary>
        /// 用户逻辑层
        /// </summary>
        private SysAdminManage SysAdminManage { get; set; } = new SysAdminManage(); 

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this?.Close();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                if (this.txt_UserName.Text==CommonMethod.SysAdminModel.LoginName&&this.txt_PassWord.Text==CommonMethod.SysAdminModel.LoginPwd)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("登入详情", "用户名或密码错误");
                    frm.ShowDialog();
                }
            }
        }


        #region 读取配置文件
        private void ReadConfig()
        {
            if (CommonMethod.configPath==null||CommonMethod.configPath.Trim().Length<=0)
            {
                CommonMethod.configPath=Application.StartupPath+@"\Config\config.ini";
                CommonMethod.CreateConfig(CommonMethod.configPath);
            }
            CommonMethod.ReadConfig();
        }
        #endregion

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

    }
}
