using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KYJDAL
{
    public class SysAdminServer
    {

        private SQLLiteServer SQLLiteServer { get; set; } = new SQLLiteServer();

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
            DataSet ds = SQLLiteHelper.GetDataSet(sql, sqlLiteParameter);
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

        /// <summary>
        /// 查询所有变量
        /// </summary>
        /// <returns></returns>
        public BindingList<SysAdmin> Query()
        {
            DataTable dt = null;
            BindingList<SysAdmin> sysAdmins = new BindingList<SysAdmin>();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select  LoginId,LoginPwd,LoginName,LoginPwd,LogAlarm,HistoryLog,ActualTrend,HistoryTrend,ParamSet,Report,UserManage");
            sql.AppendLine(" from sysadmin ");
            DataSet dataSet = SQLLiteHelper.GetDataSet(sql.ToString());
            if (dataSet!=null)
            {
                dt = dataSet.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sysAdmins.Add(new SysAdmin()
                    {
                        LoginId=Convert.ToInt32(dt.Rows[i]["LoginId"]),
                        LoginName=dt.Rows[i]["LoginName"].ToString(),
                        LoginPwd=dt.Rows[i]["LoginPwd"].ToString(),
                        LogAlarm=Convert.ToBoolean(dt.Rows[i]["LogAlarm"]),
                        HistoryLog=Convert.ToBoolean(dt.Rows[i]["HistoryLog"]),
                        ActualTrend=Convert.ToBoolean(dt.Rows[i]["ActualTrend"]),
                        HistoryTrend=Convert.ToBoolean(dt.Rows[i]["HistoryTrend"]),
                        ParamSet=Convert.ToBoolean(dt.Rows[i]["ParamSet"]),
                        Report=Convert.ToBoolean(dt.Rows[i]["Report"]),
                        UserManage=Convert.ToBoolean(dt.Rows[i]["UserManage"])
                    });
                }
            }
            return sysAdmins;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int AddUser(SysAdmin admin)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into sysAdmin  ");
            sql.Append(" (LoginName,LoginPwd,LogAlarm,HistoryLog,ActualTrend,HistoryTrend,ParamSet,Report,UserManage) ");
            sql.Append("values(");
            sql.Append("@LoginName,@LoginPwd,@LogAlarm,@HistoryLog,@ActualTrend,@HistoryTrend,@ParamSet,@Report,@UserManage)");

            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("LoginName",admin.LoginName),
                new SQLiteParameter("LoginPwd",admin.LoginPwd),
                new SQLiteParameter("LogAlarm",admin.LogAlarm),
                new SQLiteParameter("HistoryLog",admin.HistoryLog),
                new SQLiteParameter("ActualTrend",admin.ActualTrend),
                new SQLiteParameter("HistoryTrend",admin.HistoryTrend),
                new SQLiteParameter("ParamSet",admin.ParamSet),
                new SQLiteParameter("Report",admin.Report),
                new SQLiteParameter("UserManage",admin.UserManage)
            };
            return SQLLiteHelper.ExecuteNonQuery(sql.ToString(), param);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int DeleteUser(int loginID)
        {
            string sql = "delete from sysAdmin " +
                " where loginID=@loginID ";
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("@loginID",loginID)
            };
            return SQLLiteHelper.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int UpdateUser(SysAdmin admin)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update SysAdmin ");
            sql.Append("set loginPwd=@LoginPwd,LogAlarm='@LoginAlarm',HistoryLog='@HistoryLog',ActualTrend='@ActualTrend',HistoryTrend='@HistoryTrend',ParamSet='@ParamSet'," +
                " Report='@Report',UserManage='@UserManage' ");
            sql.Append(" where LoginName=@LoginName  and LoginId=@LoginID ");
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("LoginID",admin.LoginId),
                new SQLiteParameter("LoginName",admin.LoginName),
                new SQLiteParameter("LoginPwd",admin.LoginPwd),
                new SQLiteParameter("LogAlarm",admin.LogAlarm),
                new SQLiteParameter("HistoryLog",admin.HistoryLog),
                new SQLiteParameter("ActualTrend",admin.ActualTrend),
                new SQLiteParameter("HistoryTrend",admin.HistoryTrend),
                new SQLiteParameter("ParamSet",admin.ParamSet),
                new SQLiteParameter("Report",admin.Report),
                new SQLiteParameter("UserManage",admin.UserManage)
            };
            return SQLLiteHelper.ExecuteNonQuery(sql.ToString(), param);
        }

        /// <summary>
        /// 查询除了当前用户名以外是否还有相同密码的用户
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool SelectUser(string pwd, string name)
        {
            string sql = "select count(*) from sysadmin" +
                " where LoginName!=@LoginName and LoginPwd=@LoginPwd ";
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("LoginName",name),
                new SQLiteParameter("LoginPwd",pwd)
            };
            return Convert.ToInt32(SQLLiteHelper.ExecuteScalar(sql, param))>0;
        }

        /// <summary>
        ///  查询新用户的用户名，和密码是否存在重复的
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool QueryName(string pwd,string name)
        {
            string sql = "select count(*) from sysadmin " +
                " where loginpwd=@loginpwd  or loginname=@loginname ";
            SQLiteParameter[] param = new SQLiteParameter[] 
            {
                new SQLiteParameter("loginpwd",pwd),
                new SQLiteParameter("loginname",name)
            };
            return Convert.ToInt32(SQLLiteHelper.ExecuteScalar(sql, param))>0;
        }
    }
}
