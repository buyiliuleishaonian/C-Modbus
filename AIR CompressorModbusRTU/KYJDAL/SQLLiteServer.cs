using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYJDAL
{
    public class SQLLiteServer
    {
        public void ConnStr(string  conStr)
        {
            SQLLiteHelper.connString= conStr;
        }
    }
}
