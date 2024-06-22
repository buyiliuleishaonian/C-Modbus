using KYJDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kYJBLL
{
    public class SQLLiteManage
    {
        private SQLLiteServer SQLLiteServer { get; set; }=new SQLLiteServer();
        public void ConnStr(string path)
        {
            SQLLiteServer.ConnStr(path);
        }
    }
}
