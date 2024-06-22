using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ConfigLib
{
    /// <summary>
    /// 欧姆龙串口通信
    /// </summary>
    public  class OmronHostlinkVariable : VariableBase
    {
        /// <summary>
        /// 起始地址
        /// </summary>
        public string Start { get; set; }

    }
}
