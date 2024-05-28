using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;

namespace Wen.PLCAsServerProgram
{
    /// <summary>
    /// 绑定变量
    /// </summary>
    public class BindVariable
    {
        /// <summary>
        /// 起始地址
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// 偏移量或者长度
        /// </summary>
        public int OffsetOrLength { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public DataType DataType { get; set; }
    }
}
