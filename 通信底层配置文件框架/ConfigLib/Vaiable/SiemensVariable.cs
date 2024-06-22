using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ConfigLib
{
    /// <summary>
    /// 西门子S7通信变量
    /// </summary>
    public  class SiemensVariable:VariableBase
    {
        /// <summary>
        /// 起始地址
        /// </summary>
        public string Start { get; set; }

    }
}
