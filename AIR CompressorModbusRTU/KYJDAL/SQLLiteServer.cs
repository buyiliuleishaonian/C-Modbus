using Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

        /// <summary>
        /// 查询表名是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool IsTabelExist(string tableName)
        {
            string sql = "select count(*) from sqlite_master where type='table' and name=@tableName";
            SQLiteParameter[] param= new SQLiteParameter[] 
            {
                new SQLiteParameter("@tableName",tableName)
            };
            try
            {
               return  int.Parse((SQLLiteHelper.ExecuteScalar(sql, param)).ToString())==1;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool DeleteTable(string tableName)
        {
            string sql = "drop table  " +tableName;
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
        /// 清空表数据
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
        /// 创建数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <param name="isPrimarykey"></param>
        /// <returns></returns>
        public bool CreateTable(string tableName,List<string> columns,bool isPrimarykey=true)
        { 
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Create Table ");
            stringBuilder.AppendLine(tableName+"(");
            if (isPrimarykey)
            {
                stringBuilder.AppendLine(" ID INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,");
            }

            for (int i = 0; i <columns.Count-1; i++) 
            {
                
                    stringBuilder.AppendLine(columns[i]+" VARCHAR(20),");
            }
            stringBuilder.AppendLine(columns[columns.Count-1]+" VARCHAR(20)");
            stringBuilder.AppendLine(");");
            string s=stringBuilder.ToString();
            try
            {
                return int.Parse((SQLLiteHelper.ExecuteNonQuery(stringBuilder.ToString())).ToString())==0;
            }
            catch(Exception ex)
            {
               string result=  ex.Message;
                return false;
            }
        }
    }
}
