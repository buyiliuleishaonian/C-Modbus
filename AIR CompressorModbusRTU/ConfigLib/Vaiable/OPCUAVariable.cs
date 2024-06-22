using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ConfigLib
{
    /// <summary>
    /// OPCUA通信
    /// </summary>
    public  class OPCUAVariable : VariableBase
    {
        /// <summary>
        /// 变量句柄
        /// </summary>
        [JsonIgnore]
        public int ClientHandle { get; set; }

    }
}
