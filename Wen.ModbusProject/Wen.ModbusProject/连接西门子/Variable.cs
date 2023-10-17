using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;

namespace Wen.ModbusProject.连接西门子
{
    /// <summary>
    /// 创建变量的实体类，接受西门子数据的对象，并且得到初始地址，数据类型，OffSetOrLength
    /// </summary>
    public class Variable
    {
        //标签名称
        public string VarName { get; set; }
        //起始地址
        public int Start { get; set; }
        //数据类型
        public DataType DataType { get; set; }
        //OffsetORLength  未偏移或长度
        public int OffSetOrLength { get; set; }
        //变量的值
        public object VarValue { get; set; }
    }
}
