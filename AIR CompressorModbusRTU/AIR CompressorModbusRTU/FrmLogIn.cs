using kYJBLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIR_CompressorModbusRTU
{
    public partial class FrmLogIn : Form
    {
        /// <summary>
        /// 用户逻辑类
        /// </summary>
        public SysAdminManage SysAdminManage { get; set; } = new SysAdminManage();
        /// <summary>
        /// 用户类
        /// </summary>
        public SysAdmin SysAdmin { get; set; } = new SysAdmin();

        /// <summary>
        /// 公用配置
        /// </summary>
        public CommonMethod CommonMethod { get; set; }

        public FrmLogIn()
        {
            InitializeComponent();

            CommonMethod.GetConfig();

            this.Load+=FrmLogIn_Load;

        }

        /// <summary>
        /// 绘制窗体前读取配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            if (CommonMethod.config!=null)
            {
                if (CommonMethod.config.AutoLogin)
                {
                    btn_LogIn_Click(null, null);
                }
            }
        }

        /// <summary>
        ///  登入程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            string userName = this.txt_UserName.Text;
            string pwd = this.txt_PassWord.Text;
            //验证数据
            if (userName.Trim().Length<=0)
            {
                new FrmMessageBoxWithOutAck("登入提示", "用户名错误/为空").ShowDialog();
                return;
            }
            if (pwd.Trim().Length<=0)
            {
                new FrmMessageBoxWithOutAck("登入提示", "密码错误/为空").ShowDialog();
                return;
            }
            //封装数据
            SysAdmin.LoginName=userName;
            SysAdmin.LoginPwd=pwd;
            //提交数据
            SysAdmin= SysAdminManage.QuerySysAdmin(SysAdmin);
            if (SysAdmin.LoginId>0&&SysAdmin!=null)
            {
                CommonMethod.SysAdmin=SysAdmin;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                new FrmMessageBoxWithOutAck("登入提示", "用户不存在").ShowDialog();
                return;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region 移动无框窗体
        private Point point;
        /// <summary>
        /// 得到鼠标左键的坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            point=new Point(e.X, e.Y);
        }
        /// <summary>
        /// 移动到鼠标左键拖动的地方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                //修改窗体的位置，得到移动
                this.Location=new Point(this.Location.X+e.X-point.X, this.Location.Y+e.Y-point.Y);
            }
        }
        #endregion


        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txt_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue==13)
            {
                btn_LogIn_Click(null, null);
            }
        }
    }
}
