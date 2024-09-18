using AIR_DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIR_BLL
{
    /// <summary>
    /// 用户访问层
    /// </summary>
    public class SysAdminManage
    {
        public SysAdminServer SysAdminServer { get; set; } = new SysAdminServer();

        /// <summary>
        /// 通过用户名和密码，查询用户是否存在
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public SysAdminModel  SelectUser(string user, string pwd)
        {
            return SysAdminServer.SelectUser(user, pwd);
        }
    }
}
