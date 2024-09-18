using CommonHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIR_DAL
{
    /// <summary>
    /// 数据库逻辑访问
    /// </summary>
    public class SQLiteServer
    {
        public void ConnectPath(string path)
        {
            SQLLiteHelper.connString=path;
        }
    }
}
