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
        private SQLiteServer SQLiteServer { get; set; } = new SQLiteServer();

        /// <summary>
        /// 数据库地址
        /// </summary>
        /// <param name="path"></param>
        public void ConnectPath(string path)
        {
            SQLiteServer.ConnectPath(path);
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="name"></param>
        /// <param name="varname"></param>
        /// <returns></returns>
        public bool CreateTable(string name, List<string> varname, bool isprimary)
        {
            return SQLiteServer.CreateTable(varname, name, isprimary);
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteTable(string name)
        {
            return SQLiteServer.DeleteTable(name);
        }

        /// <summary>
        /// 整理数据表
        /// </summary>
        /// <returns></returns>
        public bool VacuumTable()
        {
            return SQLiteServer.VacuumTable();
        }

        /// <summary>
        /// 查询数据表
        /// </summary>
        /// <param name="actualTable"></param>
        /// <returns></returns>
        public bool SelectTable(string actualTable)
        {
            return SQLiteServer.SelectTable(actualTable);
        }
    }
}
