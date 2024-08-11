using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYJDAL
{
    /// <summary>
    /// 数据表
    /// </summary>
    public class ActualDataServer
    {
         /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="varName">数据列名称</param>
        /// <param name="varValue">数据</param>
        /// <returns></returns>
        public int AddActualData(List<string> varName,List<string> varValue)
        { 
            StringBuilder sql=new StringBuilder();
            sql.AppendLine("insert into  ActualTable ");
            sql.AppendLine("( ");
            sql.AppendLine(string.Join(",",varName));
            sql.AppendLine(") ");
            sql.AppendLine("values(");
            sql.AppendLine(string.Join(",",varValue.Select(c=>"'"+c+"'").ToList()));
            sql.AppendLine(")");

            return SQLLiteHelper.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// 按照时间和参数查询历史数据
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">历史时间</param>
        /// <param name="varname">参数</param>
        /// <returns></returns>
        public DataTable SelectHistoryData(string start,string end,List<string> varName)
        {
            DataTable dt = null;
            StringBuilder sql= new StringBuilder();
            sql.AppendLine("select  insertTime, ");
            sql.AppendLine(string.Join(",",varName));
            sql.AppendLine(" from ActualTable");
            sql.AppendLine(" where insertTime between @start and @end");
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("@start",start),
                new SQLiteParameter("@end",end)
            };

            DataSet ds = SQLLiteHelper.GetDataSet(sql.ToString(),param);
            if (ds!=null)
            {
                return dt=ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据条件查询报表数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="condition">要求</param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable QueryDataValue(string start, string end, List<string> condition,string tableName)
        {
            DataTable dt = null;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select  ");
            sql.AppendLine(string.Join(",", condition));
            sql.AppendLine(" from ActualTable");
            sql.AppendLine(" where insertTime between @start and @end");
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("@start",start),
                new SQLiteParameter("@end",end)
            };
            DataSet ds = SQLLiteHelper.GetDataSet(sql.ToString(), param,tableName);
            if (ds!=null)
            {
                return dt=ds.Tables[0];
            }
            else
            {
                return null;
            }

        }
    }
}
