using CommonHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIR_DAL
{
    /// <summary>
    /// 数据存储
    /// </summary>
    public class DataService
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="varname"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddData(List<string> varname, List<string> value,string  date)
        {
            // Generate the SQL statement
            string sql = $"INSERT INTO ActualTable" +
                $" ( InsertTime,{string.Join(", ", varname)})  VALUES (@date,{string.Join(", ", value.Select(v => $"'{v}'"))})";
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("@date",date)
            };
            try
            {
                return SQLLiteHelper.ExecuteNonQuery(sql,param) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                string result = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="varname"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable SelectData(List< string> varname, string start, string end)
        {
            string sql = $"select  InsertTime, {string.Join(",", varname) }  from ActualTable where InsertTime  between '{start}' and '{end}' ";
            try 
            {
                DataTable dt= SQLLiteHelper.GetDataSet(sql).Tables[0];
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
