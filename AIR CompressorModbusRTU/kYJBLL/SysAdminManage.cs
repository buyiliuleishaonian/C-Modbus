using KYJDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kYJBLL
{
    public class SysAdminManage
    {
        private SysAdminServer SysAdminServer { get; set; }=new SysAdminServer();

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public SysAdmin QuerySysAdmin(SysAdmin admin)
        {
            return SysAdminServer.QuerySysAdmin(admin);
        }
    }
}
