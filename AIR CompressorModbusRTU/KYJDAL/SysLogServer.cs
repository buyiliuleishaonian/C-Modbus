using Model;
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
    /// 系统日志数据访问层
    /// </summary>
    public class SysLogServer
    {
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        private SQLLiteServer SQLLiteServer { get; set; } = new SQLLiteServer();

        /// <summary>
        /// 添加报警信息
        /// </summary>
        /// <param name="syslog"></param>
        /// <returns></returns>
        public bool InsertSysLog(SysLogIn syslog)
        {
            string sql = "insert into syslog(InsertTime,Note,LogType,Operador,VarName,AlarmSet,AlarmValue,AlarmType) " +
                " values(@InsertTime,@Note,@LogType,@Operador,@VarName,@AlarmSet,@AlarmValue,@AlarmType)";
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("@InsertTime",syslog.InsertTime),
                new SQLiteParameter("@Note",syslog.Note),
                new SQLiteParameter("@LogType",syslog.LogType),
                new SQLiteParameter("@Operador",syslog.Operador),
                new SQLiteParameter("@VarName",syslog.VarName),
                new SQLiteParameter("@AlarmSet",syslog.AlarmSet),
                new SQLiteParameter("@AlarmValue",syslog.AlarmValue),
                new SQLiteParameter("@AlarmType",syslog.AlarmType),
            };
            int result = SQLLiteHelper.ExecuteNonQuery(sql, param);
            return result>0 ? true : false;    
        }

        /// <summary>
        /// 日志查询
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataSet SelectLogDataSet(string start,string end,string logType)
        {
            string sql = "select inserttime,note,logtype,operador,varname,alarmset,alarmValue,Alarmtype from syslog" +
                " where ((insertTime between @Start and @End) and LogType=@LogType)";
            SQLiteParameter[] para = new SQLiteParameter[]
            {
                new SQLiteParameter("@Start",start),
                new SQLiteParameter("@End",end),
                new SQLiteParameter("@LogType",logType)
            };
            DataSet ds = new DataSet();
            ds=SQLLiteHelper.GetDataSet(sql, para);
            return ds;
        }

    }
}
