using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYJDAL
{
    public class SysAdminServer
    {
        private SQLLiteServer SQLLiteServer { get; set; }=new SQLLiteServer();
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public SysAdmin QuerySysAdmin(SysAdmin admin)
        {
            string sql = "select LoginId,LogAlarm,HistoryLog,ActualTrend,HistoryTrend,ParamSet,Report,UserManage from SysAdmin" +
                " where LoginName=@LoginName and LoginPwd=@LoginPwd";
            SQLiteParameter[] sqlLiteParameter = new SQLiteParameter[]
            {
                new SQLiteParameter("@LoginName",admin.LoginName),
                new SQLiteParameter("@LoginPwd",admin.LoginPwd)
            };
            DataSet ds = SQLLiteHelper.GetDataSet(sql,sqlLiteParameter);
            try
            {
                if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
                {
                    admin.LoginId=Convert.ToInt32(ds.Tables[0].Rows[0]["LoginId"].ToString());
                    admin.LogAlarm=Convert.ToBoolean(ds.Tables[0].Rows[0]["LogAlarm"].ToString());
                    admin.HistoryLog=Convert.ToBoolean(ds.Tables[0].Rows[0]["HistoryLog"].ToString());
                    admin.ActualTrend=Convert.ToBoolean(ds.Tables[0].Rows[0]["ActualTrend"].ToString());
                    admin.HistoryTrend=Convert.ToBoolean(ds.Tables[0].Rows[0]["HistoryTrend"].ToString());
                    admin.ParamSet=Convert.ToBoolean(ds.Tables[0].Rows[0]["ParamSet"].ToString());
                    admin.Report=Convert.ToBoolean(ds.Tables[0].Rows[0]["Report"].ToString());
                    admin.UserManage=Convert.ToBoolean(ds.Tables[0].Rows[0]["UserManage"].ToString());
                }
            }
            catch 
            {
                return null;
            }
            return admin;
        }
    }
}
