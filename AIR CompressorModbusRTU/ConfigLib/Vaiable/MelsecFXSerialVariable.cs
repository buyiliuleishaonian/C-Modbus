
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ConfigLib
{
    /// <summary>
    /// 三菱串口通信变量
    /// </summary>
    public  class MelsecFXSerialVariable : VariableBase
    {
        /// <summary>
        /// 起始地址
        /// </summary>
        public string Start { get; set; }

    }
}
