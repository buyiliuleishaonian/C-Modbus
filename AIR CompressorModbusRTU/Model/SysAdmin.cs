using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class SysAdmin
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int LoginId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// 日志报警权限
        /// </summary>
        public bool LogAlarm { get; set; }
        /// <summary>
        /// 日志查询权限
        /// </summary>
        public bool HistoryLog { get; set; }
        /// <summary>
        /// 实时趋势权限
        /// </summary>
        public bool ActualTrend { get; set; }
        /// <summary>
        /// 历史趋势权限
        /// </summary>
        public bool HistoryTrend { get; set;}
        /// <summary>
        /// 参数设置权限
        /// </summary>
        public bool ParamSet { get; set; }
        /// <summary>
        /// 数据报表权限
        /// </summary>
        public bool Report { get; set; }
        /// <summary>
        /// 用户管理权限
        /// </summary>
        public bool UserManage { get; set; }
    }
}
