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

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="name"></param>
        /// <param name="isPrimarykey"></param>
        public bool CreateTable(List<string> variable, string name, bool isPrimarykey = true)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Create table " + name +" (");
            if (isPrimarykey)
            {
                sql.AppendLine(" ID INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,");
            }
            for (int i = 0; i < variable.Count-1; i++)
            {
                sql.AppendLine(variable[i]+"  VARCHAR(20),");
            }
            sql.AppendLine(variable[variable.Count-1]+ " VARCHAR(50) ");
            sql.AppendLine(");");
            string s = sql.ToString();
            try
            {
                return SQLLiteHelper.ExecuteNonQuery(s)==0;
            }
            catch (Exception ex)
            {
                string result = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteTable(string name)
        {
            string sql = "drop table "+name;
            try
            {
                SQLLiteHelper.ExecuteNonQuery(sql);
                return true;
            }
            catch(Exception ex)
            {
                string result = ex.Message;
                return false;
            }

        }

        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool VacuumTable()
        {
            string sql = "vacuum";
            try
            {
                SQLLiteHelper.ExecuteNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 查询数据表是否存在
        /// </summary>
        /// <param name="actualName"></param>
        /// <returns></returns>
        public bool SelectTable(string actualName)
        {
           string sql= $"select name from  sqlite_master where type='table' and name='{actualName}'";
            try
            {
                var num = SQLLiteHelper.ExecuteNonQuery(sql);
                return num==0 ? true : false;
            }
            catch
            {
                

                return false;
            }
        }
    }
}
