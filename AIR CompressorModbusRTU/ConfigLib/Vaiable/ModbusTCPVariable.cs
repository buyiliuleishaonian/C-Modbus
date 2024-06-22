using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ConfigLib
{
    /// <summary>
    /// ModbusTCP变量
    /// </summary>
    public  class ModbusTCPVariable:VariableBase
    {
        /// <summary>
        /// 起始地址
        /// </summary>
        public string Start { get; set; }

    }
}
