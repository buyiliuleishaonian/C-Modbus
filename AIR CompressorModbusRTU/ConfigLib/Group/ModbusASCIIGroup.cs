using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  ConfigLib
{
    public  class ModbusASCIIGroup : GroupBase
    {
        /// <summary>
        /// 起始地址
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// 读取长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 变量的集合
        /// </summary>
        public List<ModbusASCIIVariable> VarList { get; set; } = new List<ModbusASCIIVariable>();

    }
}
