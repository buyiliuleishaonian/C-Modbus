using CommonHelper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using thinger.DataConvertLib;

namespace AIR_DAL
{
    /// <summary>
    /// 日志逻辑
    /// </summary>
    public class LogServer
    {
        /// <summary>
        /// 添加一条日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OperateResult AddLog(SysLogModel model)
        {
           string sql = "insert into SysLog(Inserttime,Note,LogType,Operator,AlarmSet,AlarmValue,AlarmType)" +
                " Values(@inserttime,@note,@logType,@operator,@alarmSet,@alarmValue,@alarmType)";
            SQLiteParameter[] param=new SQLiteParameter[] 
            {
                new SQLiteParameter("@inserttime",model.InsertTime),
                new SQLiteParameter("@note",model.Note),
                new SQLiteParameter("@logType",model.LogType),
                new SQLiteParameter("@operator",model.Operator),
                new SQLiteParameter("@alarmSet",model.AlarmSet),
                new SQLiteParameter("@alarmValue",model.AlarmValue),
                new SQLiteParameter("@alarmType",model.AlarmType),
            };
            int num= SQLLiteHelper.ExecuteNonQuery(sql, param);
            if (num>0)
            {
                return OperateResult.CreateSuccessResult();
            }
            return OperateResult.CreateFailResult();
        }


        /// <summary>
        /// 按照时间和日志类型查询
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="logType"></param>
        /// <returns></returns>

        public OperateResult<DataTable> SelectLog(string start,string end,string logType)
        {
            string sql = "select Inserttime,Note,LogType,Operator,VarName,AlarmSet,AlarmValue,AlarmType from SysLog " +
               " where ( Inserttime between @start and @end ) and  LogType=@LogType   ";
            SQLiteParameter[] param = new SQLiteParameter[]
           {
               new SQLiteParameter("@start",start),
               new SQLiteParameter("@end",end),
               new SQLiteParameter("@LogType",logType),
           };
           DataSet  ds=SQLLiteHelper.GetDataSet(sql, param);
            DataTable dt=ds.Tables[0];
            if (ds.Tables.Count>0)
            {
                return OperateResult.CreateSuccessResult(ds.Tables[0]);
            }
            return OperateResult.CreateFailResult<DataTable>("查询为空");
        }

    }
}
