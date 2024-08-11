using CommonHelper;
using ConfigLib;
using kYJBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace AIR_CompressorModbusRTU
{
    public partial class FrmHistoryLog : Form
    {
        public FrmHistoryLog()
        {
            InitializeComponent();

            this.Load+=FrmHistoryLog_Load;
        }

        private SysLogManage SysLogManage { get; set; } = new SysLogManage();

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHistoryLog_Load(object sender, EventArgs e)
        {
            this.cmb_LogType.Items.AddRange(new string[] { "系统日志", "操作日志", "报警日志" });

            this.date_Start.Value=DateTime.Now.AddHours(-2);

            this.dgv_Log.AutoGenerateColumns=false;
        }

        /// <summary>
        /// 添加序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Log_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(sender as DataGridView, e);
        }

        /// <summary>
        /// 查询规定时间的日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            string start = this.date_Start.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string end = this.date_End.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string logtype = this.cmb_LogType.Text;

            //查询数据，读取数据，都需要用到多线程
            Task<OperateResult<DataTable>> task = Task.Run(() =>
            {
                return QuerySysLog(start, end, logtype);
            });

            //得到线程结束之后的数据
            var result = task.GetAwaiter().GetResult();
            this.Invoke(new Action(() =>
            {
                if (result.IsSuccess)
                {
                    if (result.Content!=null)
                    {
                        this.dgv_Log.DataSource=null;
                        this.dgv_Log.DataSource=result.Content;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    new FrmMessageBoxWithOutAck("查询错误", "错误原因"+result.Message).ShowDialog();
                }
            }));

        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="logtype"></param>
        /// <returns></returns>
        private OperateResult<DataTable> QuerySysLog(string start, string end, string logtype)
        {
            TimeSpan timespan = Convert.ToDateTime(end)-Convert.ToDateTime(start);
            if (Convert.ToDateTime(start)>Convert.ToDateTime(end))
            {
                CommonMethod.AddOpLog(true, $"查询开始时间{start}大于结束时间{end}，无法查询");
                return OperateResult.CreateFailResult<DataTable>("");
            }
            if (timespan.TotalHours>24.0)
            {
                CommonMethod.AddOpLog(true, $"查询开始时间{start}结束时间{end}相差24小时，无法查询");
                return OperateResult.CreateFailResult<DataTable>("");
            }
            if (!start.Contains(end))
            {
                if (logtype.Trim().Length>0)
                {
                    DataSet ds = new DataSet();
                    ds=SysLogManage.SelectLogDataSet(start, end, logtype);
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        return OperateResult.CreateSuccessResult(ds.Tables[0]);
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<DataTable>("当前时间段没有数据");
                    }
                }
                else
                {
                    return OperateResult.CreateFailResult<DataTable>("没有选择日志类型");
                }
            }
            else
            {
                return OperateResult.CreateFailResult<DataTable>($"查询开始时间{start}和结束时间{end}一样，无法查询");
            }
        }

        /// <summary>
        /// 将数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            string path = null;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter="Excel类型1|*.xls|Excel类型2|*.cvs";
            dlg.Title="文件导出位置";
            dlg.InitialDirectory=@"C:\Users";
            dlg.FileName="日志报表"+DateTime.Now.ToString("yyyyMMddhhss");
            dlg.AddExtension= true;

            if (dlg.ShowDialog()==DialogResult.OK)
            {
                path=dlg.FileName;
                if (ExcelHelper.DataGridViewToExcel(path, this.dgv_Log))
                {
                    Process.Start(path);
                }
                else
                {
                    new FrmMessageBoxWithOutAck("导出日志信息", "导出失败").ShowDialog();
                }
            }
        }

        /// <summary>
        /// 每当单元格属性变化时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Log_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex!=-1&&e.ColumnIndex>4)
            {
                var result = this.dgv_Log.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (result.Value==null||result.Value.ToString().Trim().Length==0)
                {
                    e.Value="--";
                }
            }
        }
    }
}
