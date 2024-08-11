using KYJDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kYJBLL
{
    /// <summary>
    /// 系统日志 逻辑访问层
    /// </summary>
    public class SysLogManage
    {
        private SysLogServer SysLogServer { get; set; }=new SysLogServer();

        /// <summary>
        /// 添加一条日志
        /// </summary>
        /// <param name="syslog"></param>
        /// <returns></returns>
        public bool InsertLog(SysLogIn syslog)
        {
           return  SysLogServer.InsertSysLog(syslog);
        }

        /// <summary>
        /// 查询规定时间的日志
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataSet SelectLogDataSet(string start,string end,string logtype)
        {
            return SysLogServer.SelectLogDataSet(start, end,logtype);   
        }
    }
}
