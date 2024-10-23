using AIR_BLL;
using CommonHelper;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIR_ModbusTCP
{
    public partial class FrmAlarmLog: Form
    {
        public FrmAlarmLog()
        {
            InitializeComponent();
        }

        private string insertTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");   
        
        private LogManage LogManage { get; set; }=new LogManage();

        /// <summary>
        /// 添加系统日志
        /// </summary>
        /// <param name="isFailorSuccess"></param>
        /// <param name="Note"></param>
        public void AddLog(bool isFailorSuccess,string Note)
        {
            if (this.dgv_Log.InvokeRequired)
            {
                this.Invoke(new Action<bool, string>(AddLog), isFailorSuccess, Note);
            }
            else
            {
                int index = this.dgv_Log.Rows.Add();
                this.dgv_Log.Rows[index].Cells[0].Value=insertTime;
                this.dgv_Log.Rows[index].Cells[1].Value=isFailorSuccess ? "错误" : "信息";
                this.dgv_Log.Rows[index].Cells[2].Value=Note;
            }

            LogManage.AddSystemLog(new SysLogModel()
            {
                InsertTime=insertTime,
                Note=Note,
                LogType="系统日志",
                Operator=CommonMethod.SysAdminModel.LoginName,
                VarName=" ",
                AlarmSet=" ",
                AlarmValue=" ",
                AlarmType=isFailorSuccess?"错误":"信息"
            });
        }

        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="isFailorSuccess"></param>
        /// <param name="Note"></param>
        public void AddOperateLog(bool isFailorSuccess,string Note)
        {
            if (this.dgv_OperaeLog.InvokeRequired)
            {
                this.Invoke(new Action<bool, string>(AddOperateLog), isFailorSuccess, Note);
            }
            else
            {
                int index = this.dgv_OperaeLog.Rows.Add();
                this.dgv_OperaeLog.Rows[index].Cells[0].Value=insertTime;
                this.dgv_OperaeLog.Rows[index].Cells[1].Value=isFailorSuccess ? "错误" : "信息";
                this.dgv_OperaeLog.Rows[index].Cells[2].Value=Note;
            }

            LogManage.AddSystemLog(new SysLogModel()
            {
                InsertTime=insertTime,
                Note=Note,
                LogType="操作日志",
                Operator=CommonMethod.SysAdminModel.LoginName,
                VarName=" ",
                AlarmSet=" ",
                AlarmValue=" ",
                AlarmType=isFailorSuccess?"错误":"信息"
            });
        }

        /// <summary>
        /// 参数报警
        /// </summary>
        /// <param name="isFailorSuccess"></param>
        /// <param name="Note"></param>
        public void AddAlarmLog(SysLogModel syslog)
        {
            if (this.dgv_AlarmLog.InvokeRequired)
            {
                this.Invoke(new Action<SysLogModel>(AddAlarmLog), syslog);
            }
            else
            {
                int index = this.dgv_AlarmLog.Rows.Add();
                this.dgv_AlarmLog.Rows[index].Cells[0].Value=insertTime;
                this.dgv_AlarmLog.Rows[index].Cells[1].Value=syslog.AlarmType;
                this.dgv_AlarmLog.Rows[index].Cells[2].Value=syslog.Note;
            }
            LogManage.AddSystemLog(syslog);
        }

        /// <summary>
        /// 绘制行号
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

                            dgv_Log_RowPostPaint(dgv, e);
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
