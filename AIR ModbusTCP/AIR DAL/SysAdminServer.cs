using CommonHelper;
using Model;
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
    /// 用户表数据类
    /// </summary>
    public class SysAdminServer
    {
        /// <summary>
        /// 通过查询用户名和密码，验证用户是否存在
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public SysAdminModel SelectUser(string user, string pwd)
        {
            SysAdminModel model = new SysAdminModel();
            string sql = " select  Loginid,LoginName,LoginPwd,LogAlarm,HistoryLOG,ActualTrend,HistoryTrend,ParamSet,Report,UserManage  from  SysAdmin" +
                " where  LoginName=@LoginName  and LoginPwd=@LoginPwd ";
            SQLiteParameter[] param = new SQLiteParameter[]
            {
                new SQLiteParameter("@LoginName",user),
                new SQLiteParameter("@LoginPwd",pwd)
            };
           DataSet ds=SQLLiteHelper.GetDataSet(sql, param);
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                model.Loginid=Convert.ToInt32(ds.Tables[0].Rows[0]["Loginid"]);
                model.LoginName=ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.LoginPwd=ds.Tables[0].Rows[0]["LoginPwd"].ToString();
                model.HistoryLog=Convert.ToBoolean( ds.Tables[0].Rows[0]["HistoryLog"]);
                model.LogAlarm=Convert.ToBoolean(ds.Tables[0].Rows[0]["LogAlarm"]);
                model.ActualTrend=Convert.ToBoolean(ds.Tables[0].Rows[0]["ActualTrend"]);
                model.HistoryTrend=Convert.ToBoolean(ds.Tables[0].Rows[0]["HistoryTrend"]); 
                model.ParamSet=Convert.ToBoolean(ds.Tables[0].Rows[0]["ParamSet"]);
                model.Report=Convert.ToBoolean(ds.Tables[0].Rows[0]["Report"]);
                model.UserManage=Convert.ToBoolean(ds.Tables[0].Rows[0]["UserManage"]);

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
