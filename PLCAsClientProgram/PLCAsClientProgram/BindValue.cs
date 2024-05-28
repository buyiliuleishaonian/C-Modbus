using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;

namespace PLCAsClientProgram
{
    public class BindValue
    {
        public int Start { get; set; }

        public int OffsetOrLength { get; set; }

        public DataType DataType { get; set; }     
    }
}
