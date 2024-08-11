using kYJBLL;
using Model;
using NPOI.OpenXmlFormats.Dml;
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

namespace AIR_CompressorModbusRTU
{
    public partial class FrmUserManage : Form
    {

        private SysAdminManage SysAdminManage = new SysAdminManage();

        private DataTable dt = new DataTable();



        BindingList<SysAdmin> adminlist = new BindingList<SysAdmin>();

        public FrmUserManage()
        {
            InitializeComponent();
            this.dgv_SystemAdmin.AutoGenerateColumns=false;
            this.dgv_SystemAdmin.MultiSelect=false;

            Initial();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
            this.txt_UserName.Text=CommonMethod.SysAdmin.LoginName;
            this.txt_Pwd.Text=CommonMethod.SysAdmin.LoginPwd;
            this.txt_AgainPwd.Text=CommonMethod.SysAdmin.LoginPwd;

            this.chk_ActualThrend.Checked=CommonMethod.SysAdmin.ActualTrend;
            this.chk_Log.Checked=CommonMethod.SysAdmin.LogAlarm;
            this.chk_HistoryThrend.Checked=CommonMethod.SysAdmin.HistoryTrend;
            this.chk_ParamSet.Checked=CommonMethod.SysAdmin.ParamSet;
            this.chk_Report.Checked=CommonMethod.SysAdmin.Report;
            this.chk_HistoryLog.Checked=CommonMethod.SysAdmin.HistoryLog;
            this.chk_UserManage.Checked=CommonMethod.SysAdmin.UserManage;

            adminlist=  SysAdminManage.Query();

            //修改DataGridView控件
            UpdateDataGridView();
            //修改按钮
            UpdateBtn();
        }

        /// <summary>
        /// 修改DataGridView
        /// </summary>
        public void UpdateDataGridView()
        {
            adminlist= SysAdminManage.Query();
            if (adminlist.Count>0)
            {
                this.dgv_SystemAdmin.DataSource=null;
                this.dgv_SystemAdmin.DataSource=adminlist;
            }
        }

        public void UpdateBtn()
        {
            foreach (var item in this.grb_UserMenage.Controls)
            {
                if (item is CheckBox chk)
                {
                    if (!chk.Checked)
                    {
                        this.btn_QueryOrNoQuery.Text="全选";
                        return;
                    }
                }
            }
            this.btn_QueryOrNoQuery.Text="不选";
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            #region 验证信息
            if (this.txt_UserName.Text==null||this.txt_UserName.Text.ToString().Trim().Length<=0)
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：没有新的用户名");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "没有新的用户名");
                frm.ShowDialog();
                return;
            }
            if (this.txt_Pwd.Text==null||this.txt_Pwd.Text.Trim().Length<=0)
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：没有密码");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "没有输入密码");
                frm.ShowDialog();
                return;
            }
            if (this.txt_AgainPwd.Text==null||this.txt_AgainPwd.Text.Trim().Length<=0)
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：没有输入确定密码");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "没有输入确定密码");
                frm.ShowDialog();
                return;
            }
            if (this.txt_Pwd.Text!=this.txt_AgainPwd.Text)
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：确认密码与密码不服");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "确认密码与密码不服");
                frm.ShowDialog();
                return;
            }
            if (SysAdminManage.QueryNameOrPwd(this.txt_Pwd.Text, this.txt_UserName.Text))
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：用户名或密码重复");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "用户名或密码重复");
                frm.ShowDialog();
                return;
            }
            #endregion

            //封装对象
            SysAdmin admin = new SysAdmin()
            {
                LoginName=this.txt_UserName.Text,
                LoginPwd=this.txt_Pwd.Text,
                LogAlarm=this.chk_Log.Checked,
                ParamSet=this.chk_ParamSet.Checked, 
                HistoryLog=this.chk_HistoryLog.Checked,
                ActualTrend=this.chk_ActualThrend.Checked,
                HistoryTrend=this.chk_HistoryThrend.Checked,
                Report=this.chk_Report.Checked,
                UserManage=this.chk_UserManage.Checked,
            };

            //添加对象
            int result = SysAdminManage.AddUser(admin);
            if (result>0)
            {
                CommonMethod.AddOpLog(true, $"添加新的用户{this.txt_UserName.Text}成功");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", $"添加新用户{this.txt_UserName.Text}成功");
                this.adminlist.Add(admin);
                UpdateBtn();
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteUser_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.dgv_SystemAdmin.CurrentRow.Cells["LoginId"].Value)==10001)
            {
                CommonMethod.AddOpLog(false, "删除用户错误原因：管理员用户无法删除");
                FrmMessageBoxWithOutAck frmmess = new FrmMessageBoxWithOutAck("用户管理", "删除用户失败，失败原因：管理员用户无法删除");
                frmmess.ShowDialog();
                return;
            }
            FrmMessageBoxWithAck frm = new FrmMessageBoxWithAck("用户管理", $"是否确认删除用户{this.dgv_SystemAdmin.CurrentRow.Cells["LoginName"].Value}");
            if (frm.ShowDialog()==DialogResult.OK)
            {
                var resulit = SysAdminManage.DeleteUser(Convert.ToInt32(this.dgv_SystemAdmin.CurrentRow.Cells["Loginid"].Value));
                if (resulit>0)
                {
                    CommonMethod.AddOpLog(true, $"删除用户：用户{this.dgv_SystemAdmin.CurrentRow.Cells["LoginName"].Value}删除成功");
                    FrmMessageBoxWithOutAck frmmess = new FrmMessageBoxWithOutAck("用户管理", $"用户{this.dgv_SystemAdmin.CurrentRow.Cells["LoginName"].Value}删除成功，");
                    this.adminlist.RemoveAt(this.dgv_SystemAdmin.CurrentRow.Index);
                }
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpdateUser_Click(object sender, EventArgs e)
        {
            #region 验证信息
            if (this.txt_UserName.Text==null||this.txt_UserName.Text.ToString().Trim().Length<=0)
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：没有新的用户名");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "没有新的用户名");
                frm.ShowDialog();
                return;
            }
            if (this.txt_Pwd.Text==null||this.txt_Pwd.Text.Trim().Length<=0)
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：没有密码");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "没有输入密码");
                frm.ShowDialog();
                return;
            }
            if (this.txt_AgainPwd.Text==null||this.txt_AgainPwd.Text.Trim().Length<=0)
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：没有输入确定密码");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "没有输入确定密码");
                frm.ShowDialog();
                return;
            }
            if (this.txt_Pwd.Text!=this.txt_AgainPwd.Text)
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：确认密码与密码不服");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "确认密码与密码不服");
                frm.ShowDialog();
                return;
            }
            if (SysAdminManage.SelectUser(this.txt_UserName.Text, this.txt_Pwd.Text))
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因：用户名或密码已存在");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", "用户名或密码已存在");
                frm.ShowDialog();
                return;
            }
            #endregion
            int id = 0; ;

            try
            {
                id = Convert.ToInt32(this.dgv_SystemAdmin.CurrentRow.Cells["LoginId"].Value);
            }
            catch (Exception ex)
            {
                CommonMethod.AddOpLog(false, "添加新的用户错误原因："+ex.Message);
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", ex.Message);
                frm.ShowDialog();
                return;
            }
            //封装数据
            SysAdmin admin = new SysAdmin()
            {
                LoginId=id,
                LoginName=this.txt_UserName.Text,
                LoginPwd=this.txt_Pwd.Text,
                LogAlarm=this.chk_Log.Checked,
                ParamSet=this.chk_ParamSet.Checked,
                HistoryLog=this.chk_HistoryLog.Checked,
                ActualTrend=this.chk_ActualThrend.Checked,
                HistoryTrend=this.chk_HistoryThrend.Checked,
                Report=this.chk_Report.Checked,
                UserManage=this.chk_UserManage.Checked,
            };
            int result = SysAdminManage.updateUser(admin);
            if (result>0)
            {
                CommonMethod.AddOpLog(true, $"修改的用户{this.txt_UserName.Text}成功");
                FrmMessageBoxWithOutAck frm = new FrmMessageBoxWithOutAck("用户管理", $"修改用户{this.txt_UserName.Text}成功");
                this.adminlist.Add(admin);
                UpdateBtn();
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 清空信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Empty_Click(object sender, EventArgs e)
        {
            this.txt_AgainPwd.Text= string.Empty;
            this.txt_Pwd.Text= string.Empty;
            this.txt_UserName.Text= string.Empty;
            this.chk_Log.Checked=false;
            this.chk_HistoryLog.Checked=false;
            this.chk_ActualThrend.Checked=false;
            this.chk_ParamSet.Checked=false;
            this.chk_HistoryThrend.Checked=false;
            this.chk_Report.Checked=false;
            this.chk_UserManage.Checked=false;
            this.btn_QueryOrNoQuery.Text="全选";
        }

        /// <summary>
        /// 显示当前用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_SystemAdmin_DoubleClick(object sender, EventArgs e)
        {
            int index = this.dgv_SystemAdmin.CurrentRow.Index;

            this.txt_UserName.Text=this.adminlist[index].LoginName;
            this.txt_Pwd.Text=this.adminlist[index].LoginPwd;
            this.txt_AgainPwd.Text=this.adminlist[index].LoginPwd;
            this.chk_Log.Checked=this.adminlist[index].LogAlarm;
            this.chk_HistoryLog.Checked=this.adminlist[index].HistoryLog;
            this.chk_ParamSet.Checked=this.adminlist[index].ParamSet;
            this.chk_ActualThrend.Checked=this.adminlist[index].ActualTrend;
            this.chk_HistoryThrend.Checked=this.adminlist[index].HistoryTrend;
            this.chk_Report.Checked=this.adminlist[index].Report;
            this.chk_UserManage.Checked=this.adminlist[index].UserManage;

            UpdateBtn();
        }


        /// <summary>
        /// 全选或者不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_QueryOrNoQuery_Click(object sender, EventArgs e)
        {
            if (this.btn_QueryOrNoQuery.Text=="全选")
            {
                this.chk_Log.Checked=true;
                this.chk_HistoryLog.Checked=true;
                this.chk_ActualThrend.Checked=true;
                this.chk_ParamSet.Checked=true;
                this.chk_HistoryThrend.Checked=true;
                this.chk_Report.Checked=true;
                this.chk_UserManage.Checked=true;
                this.btn_QueryOrNoQuery.Text="不选";
            }
            else
            {
                this.chk_Log.Checked=false;
                this.chk_HistoryLog.Checked=false;
                this.chk_ActualThrend.Checked=false;
                this.chk_ParamSet.Checked=false;
                this.chk_HistoryThrend.Checked=false;
                this.chk_Report.Checked=false;
                this.chk_UserManage.Checked=false;
                this.btn_QueryOrNoQuery.Text="全选";
            }
        }
    }
}
