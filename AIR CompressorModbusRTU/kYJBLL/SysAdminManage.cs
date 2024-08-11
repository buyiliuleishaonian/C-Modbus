using KYJDAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kYJBLL
{
    public class SysAdminManage
    {
        private SysAdminServer SysAdminServer { get; set; }=new SysAdminServer();

        /// <summary>
        /// 查询所有变量
        /// </summary>
        /// <returns></returns>
        public BindingList<SysAdmin> Query()
        {
            return SysAdminServer.Query();
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public SysAdmin QuerySysAdmin(SysAdmin admin)
        {
            return SysAdminServer.QuerySysAdmin(admin);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int AddUser(SysAdmin admin)
        {
            return SysAdminServer.AddUser(admin);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int updateUser(SysAdmin admin)
        {
            return SysAdminServer.UpdateUser(admin);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public int DeleteUser(int loginid)
        {
            return SysAdminServer.DeleteUser(loginid);
        }

        /// <summary>
        /// 查询当前密码，除了当前用户以外是否还有人拥有
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool SelectUser(string name,string pwd)
        { 
            return SysAdminServer.SelectUser(pwd,name);
        }

        /// <summary>
        /// 查询当前名字或名是否重复
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool QueryNameOrPwd(string name,string pwd)
        {
            return SysAdminServer.QueryName(pwd,name);
        }
    }
}
