using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace CommonHelper
{
    /// <summary>
    /// SQLHelper帮助类
    /// </summary>
    public class SQLHelper

    {
            //通过UI层下的app.config的添加子节点
            //来得到数据库的 服务器，用户名，密码（通过Sql登入）和所要连接的数据库名称
            private static string sql1 = ConfigurationManager.ConnectionStrings["sqlStr"].ToString();
            //通过输入来得到数据库
            private static string sql2 = "server=.;uid=jgw;password=123456;database=MultiThMonitorDB";

            /// <summary>
            /// 放回增删改的结果是否成功
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <param name="sq">参数化sql中的字符串</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static int GetExecuteNonQuery(string sql, params SqlParameter[] sq)
            {
                int number = 0;
                try
                {
                    using (SqlConnection con = new SqlConnection(sql2))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddRange(sq);
                        number = cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number==547)
                    {
                        MessageBox.Show("DELETE 语句与 REFERENCE 约束FK_ScoreListInfos_StudentsInfos冲突。" +
                            "该冲突发生于数据库学生管理系统，表dbo.ScoreListInfos, column 'Studentid'。"+ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return number;
            }


            /// <summary>
            /// 查询某张表的一行第一列数据，
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <param name="sq">参数化sql中的字符串</param>
            /// <returns></returns>
            public static object GetExecuteScalar(string sql, params SqlParameter[] sq)
            {
                object obj = null;
                try
                {
                    using (SqlConnection con = new SqlConnection(sql1))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddRange(sq);
                        obj = cmd.ExecuteScalar();
                        return obj;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            /// <summary>
            /// 读取一张视图
            /// 需要在调用之后关闭方法
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <param name="sq">参数化sql中的字符串</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static SqlDataReader GetExecuteReader(string sql, params SqlParameter[] sq)
            {
                try
                {
                    SqlConnection con = new SqlConnection(sql1);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddRange(sq);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//讲数据库绑定到虚拟表上
                    return reader;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            /// <summary>
            /// 读取一张虚拟表
            /// 需要在调用之后关闭方法
            /// 通过string.Format来实现参数化
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <param name="sq">参数化sql中的字符串</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static SqlDataReader GetExecuteReader(string sql)
            {
                SqlDataReader reader = null;
                try
                {
                    SqlConnection con = new SqlConnection(sql1);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//讲数据库绑定到虚拟表上
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return reader;
            }

            /// <summary>
            /// 读取数据库的集表，多个数据可以
            /// 想要得到某个表，需要ds.table[""]通过表的索引
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <param name="sq">参数化sql中的字符串</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static DataSet GetDataSet(string sql, params SqlParameter[] sq)
            {
                DataSet ds = new DataSet();
                try
                {
                    using (SqlConnection con = new SqlConnection(sql1))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddRange(sq);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }

            /// <summary>
            /// 读取数据库的集表，多个数据可以
            /// 想要得到某个表，需要ds.table[""]通过表的索引
            /// 通过string.Format来实现参数化
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <param name="sq">参数化sql中的字符串</param>
            /// <exception cref="Exception"></exception>
            public static DataSet GetDataSet(string sql)
            {
                DataSet ds = new DataSet();
                try
                {
                    using (SqlConnection con = new SqlConnection(sql1))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }

            /// <summary>
            /// 放回一张虚拟表
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <param name="sq">参数化sql中的字符串</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static DataTable GetDataTable(string sql, params SqlParameter[] sq)
            {
                DataTable dt = new DataTable();
                try
                {
                    using (SqlConnection con = new SqlConnection(sql1))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddRange(sq);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return dt;
            }

            /// <summary>
            /// 放回一张虚拟表
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static DataTable GetDataTable(string sql)
            {
                DataTable dt = new DataTable();
                try
                {
                    using (SqlConnection con = new SqlConnection(sql1))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return dt;
            }

            /// <summary>
            /// 放回一张表中第一行所有数据
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <param name="sq">参数化sql中的字符串</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static DataRow GetDataRow(string sql, params SqlParameter[] sq)
            {
                DataRow dr = null;
                try
                {
                    using (SqlConnection con = new SqlConnection(sql1))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddRange(sq);
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        if (dt.Rows!=null)
                        {
                            dr=dt.Rows[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return dr;
            }

            /// <summary>
            /// 放回一张表中第一行所有数据
            /// </summary>
            /// <param name="sql">待执行的sql语句</param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static DataRow GetDataRow(string sql)
            {
                DataRow dr = null;
                try
                {
                    using (SqlConnection con = new SqlConnection(sql1))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        if (dt.Rows != null)
                        {
                            dr = dt.Rows[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return dr;
            }

            /// <summary>
            /// 返回数据库服务器的时间
            /// </summary>
            /// <returns></returns>
            public static DateTime GetDataTime()
            {

                return Convert.ToDateTime(GetExecuteScalar("select getdate()"));
            }


            /// <summary>
            /// 执行sql事务
            /// </summary>
            /// <param name="sql"></param>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public static bool GetTransaction(List<string> sql)
            {
                bool b = false;
                SqlConnection con = new SqlConnection(sql2);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection=con;
                try
                {
                    con.Open();
                    cmd.Transaction= con.BeginTransaction();
                    foreach (var item in sql)
                    {
                        cmd.CommandText= item;//需要执行的sql语句
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Transaction.Commit();
                    b=true;
                }
                catch (Exception ex)
                {
                    if (cmd.Transaction!=null)
                    {
                        cmd.Transaction.Rollback();//回滚事务，就是将报错之前所执行的所有sql语句之后执行结果全部撤销
                        cmd.Transaction=null;
                    }
                    else
                    {
                        throw new Exception(ex.Message);
                    }
                }
                finally
                {
                    if (cmd.Transaction!=null)
                    {
                        cmd.Transaction= null;
                    }
                    con.Close();
                }
                return b;
            }
        
    }

}

