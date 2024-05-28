using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;


namespace PLCAsServer_ModbusTCP_
{
    /// <summary>
    /// 绑定变量
    /// </summary>
    public class BindVariable
    {
        public string Start { get; set; }

        public int OffsetOrLength { get; set; }

        public thinger.DataConvertLib.DataType DataType { get; set; }
    }
}
