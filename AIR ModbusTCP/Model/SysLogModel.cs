using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 报警类
    /// </summary>
    public class SysLogModel
    {
        /// <summary>
        /// 报警ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 插入时间
        /// </summary>
        public string InsertTime { get; set; }
        /// <summary>
        /// 报警内容
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public string LogType { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string  Operator { get; set; }
        /// <summary>
        /// 报警变量名
        /// </summary>
        public string VarName { get; set; }
        /// <summary>
        /// 报警设定值
        /// </summary>
        public string AlarmSet { get; set; }
        /// <summary>
        /// 报警值
        /// </summary>
        public string AlarmValue { get; set; }
        /// <summary>
        /// 变量报警类型
        /// </summary>
        public bool AlarmType { get; set; }
    }
}
