using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 系统日志类
    /// </summary>
    public class SysLogIn
    {
        /// <summary>
        /// 序列
        /// </summary>
        public  int Id { get; set; }
        /// <summary>
        /// 插入时间
        /// </summary>
        public string InsertTime { get; set; }
        /// <summary>
        /// 日志信息
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public string LogType  { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string Operador { get; set; }
        /// <summary>
        /// 变量名
        /// </summary>
        public string  VarName { get; set; }
        /// <summary>
        /// 报警参数设置
        /// </summary>
        public string AlarmSet { get; set; }
        /// <summary>
        /// 报警值
        /// </summary>
        public string AlarmValue { get; set; }
        /// <summary>
        /// 触发/消除
        /// </summary>
        public string AlarmType { get; set; }


    }
}
