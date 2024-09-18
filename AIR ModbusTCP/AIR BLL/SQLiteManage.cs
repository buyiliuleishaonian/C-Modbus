using AIR_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIR_BLL
{
    public class SQLiteManage
    {
        private SQLiteServer SQLiteServer { get; set; }=new SQLiteServer();

        public void ConnectPath(string path)
        {
           SQLiteServer.ConnectPath(path);
        }
    }
}
