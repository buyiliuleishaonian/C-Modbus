using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonHelper;
using kYJBLL;
using Model;

namespace AIR_CompressorModbusRTU
{
    public partial class FrmAlarmLog : Form
    {
        public FrmAlarmLog()
        {
            InitializeComponent();
        }

        private string currentTime;

        /// <summary>
        /// 日志逻辑对象
        /// </summary>
        private SysLogManage SysLogManage { get; set; }=new SysLogManage();

        /// <summary>
        /// 当前时间
        /// </summary>
        public string CurrentTime
        {
            
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        /// <summary>
        /// 系统日志
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="log"></param>
        public void AddLog(bool isError, string log)
        {
            if (this.dgv_Log.InvokeRequired)
            {
                this.Invoke(new Action<bool,string>(AddLog),isError,log);
            }
            else
            {
                int index = this.dgv_Log.Rows.Add();
                this.dgv_Log.Rows[index].Cells[0].Value=this.CurrentTime;
                this.dgv_Log.Rows[index].Cells[1].Value=isError ? "错误" : "信息";
                this.dgv_Log.Rows[index].Cells[2].Value=log;
            }

            SysLogManage.InsertLog(new SysLogIn()
            {
                InsertTime=CurrentTime,
                Note=log,
                LogType="系统日志",
                Operador=CommonMethod.SysAdmin.LoginName,
                AlarmType=isError ? "错误" : "信息",
                VarName=" ",
                AlarmSet=" ",
                AlarmValue=" ",
            });
        }

        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="log"></param>
        public void AddOperaLog(bool isError,string log)
        {
            if (this.dgv_OperaeLog.InvokeRequired)
            {
                this.Invoke(new Action<bool, string>(AddOperaLog), isError, log);
            }
            else
            {
                int index = this.dgv_OperaeLog.Rows.Add();
                this.dgv_OperaeLog.Rows[index].Cells[0].Value=this.CurrentTime;
                this.dgv_OperaeLog.Rows[index].Cells[1].Value=isError ? "错误" : "信息";
                this.dgv_OperaeLog.Rows[index].Cells[2].Value=log;
            }

            //数据库添加
            SysLogManage.InsertLog(new SysLogIn()
            {
                InsertTime=CurrentTime,
                Note=log,
                LogType="操作日志",
                Operador=CommonMethod.SysAdmin.LoginName,
                AlarmType=isError ? "错误" : "信息",
                VarName=" ",
                AlarmSet=" ",
                AlarmValue=" ",
            });
        }

        /// <summary>
        /// 报警日志
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="log"></param>
        public void AddAlarmLog(SysLogIn syslog)
        {
            if (this.dgv_AlarmLog.InvokeRequired)
            {
                this.Invoke(new Action<SysLogIn>(AddAlarmLog), syslog);
            }
            else
            {
                int index = this.dgv_AlarmLog.Rows.Add();
                this.dgv_AlarmLog.Rows[index].Cells[0].Value=syslog.InsertTime;
                this.dgv_AlarmLog.Rows[index].Cells[1].Value=syslog.LogType;
                this.dgv_AlarmLog.Rows[index].Cells[2].Value=syslog.Note;
            }

            //数据库添加
            SysLogManage.InsertLog(syslog);
        }

        /// <summary>
        /// 绘制序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Log_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //判断控制是否被多线程调用
            if (sender is DataGridView dgv)
            {
                if (dgv.InvokeRequired)
                {
                    //this.Invoke(new Action<DataGridView, DataGridViewRowPostPaintEventArgs>(dgv_Log_RowPostPaint),dgv,e);
                    this.Invoke(new Action(
                        () =>
                        {

                            dgv_Log_RowPostPaint(dgv,e);
                        }));
                }
                else
                {
                    DataGridViewStyle.DgvRowPostPaint(dgv, e);
                }
            }
        }
    }
}
