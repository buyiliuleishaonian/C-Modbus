using AIR_DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using thinger.DataConvertLib;

namespace AIR_BLL
{
    /// <summary>
    /// 系统日志的
    /// </summary>
    public class LogManage
    {
        LogServer LogServer { get; set; }=new LogServer();

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperateResult AddSystemLog(SysLogModel model)
        {
           return  LogServer.AddLog(model);
        }

        /// <summary>
        /// 按照时间和类型查询日志
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="logType"></param>
        /// <returns></returns>
        public OperateResult<DataTable> SelectLog(string start,string end,string logType)
        {
            return LogServer.SelectLog(start,end,logType);
        }
    }
}
