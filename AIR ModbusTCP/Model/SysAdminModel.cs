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
    public class SysAdminModel
    {
        /// <summary>
        ///用户ID
        /// </summary>
        public int Loginid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string   LoginName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string   LoginPwd { get; set; }
        /// <summary>
        /// 日志权限
        /// </summary>
        public bool   LogAlarm { get; set; }
        /// <summary>
        /// 历史报警权限
        /// </summary>
        public bool   HistoryLog { get; set; }
        /// <summary>
        /// 实时值权限
        /// </summary>
        public bool   ActualTrend { get; set; }
        /// <summary>
        /// 历史数据权限
        /// </summary>
        public bool   HistoryTrend { get; set; }
        /// <summary>
        /// 参数修改权限
        /// </summary>
        public bool   ParamSet { get; set; }
        /// <summary>
        /// 标记变量最大值权限
        /// </summary>
        public bool   Report { get; set; }
        /// <summary>
        /// 用户修改权限
        /// </summary>
        public bool   UserManage { get; set; }
    }
}
