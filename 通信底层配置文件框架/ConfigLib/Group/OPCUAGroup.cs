using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ConfigLib
{
    public  class OPCUAGroup : GroupBase
    {
        /// <summary>
        /// 变量的集合
        /// </summary>
        public List<OPCUAVariable> VarList { get; set; } = new List<OPCUAVariable>();

    }
}
