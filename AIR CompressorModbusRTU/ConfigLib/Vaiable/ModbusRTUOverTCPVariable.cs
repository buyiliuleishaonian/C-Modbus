using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ConfigLib
{
    /// <summary>
    /// 需要将串口转为TCP通信的变量
    /// </summary>
    public  class ModbusRTUOverTCPVariable:VariableBase
    {
        /// <summary>
        /// 起始地址
        /// </summary>
        public string Start { get; set; }

    }
}
