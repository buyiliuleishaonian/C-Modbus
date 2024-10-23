using AIR_BLL;
using CommonHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace AIR_ModbusTCP
{
    public partial class FrmHistoryLog : Form
    {
        public FrmHistoryLog()
        {
            InitializeComponent();

            Initial();
        }

        private LogManage LogManage { get; set; } = new LogManage();

        private DateTime startTime = DateTime.Now;

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void Initial()
        {
            this.date_Start.Value= startTime.AddHours(-2);
            this.date_End.Value= startTime;

            this.cmb_LogType.Items.AddRange(new string[] { "系统日志", "操作日志", "报警日志" });

            this.cmb_LogType.SelectedIndex=-1;

            this.dgv_Log.DataSource=null;

            this.dgv_Log.AutoGenerateColumns=false;
        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            DateTime start = this.date_Start.Value;
            DateTime end = this.date_End.Value;
            string type = this.cmb_LogType.Text;
            var result = CheckTimeAndType(start, end, type);
            DataTable dt = null;
            if (result.IsSuccess)
            {
                Task<DataTable> task = Task.Run(() =>
                {
                    return LogManage.SelectLog(start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"), type).Content;
                });
                dt=task.GetAwaiter().GetResult();
                if (dt!=null&& dt.Rows.Count>0)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.dgv_Log.DataSource=null;
                        this.dgv_Log.DataSource=dt;
                    }));
                }
            }
            else
            {
                CommonMethod.Addoperatelog(false, result.Message);
            }
        }

        /// <summary>
        /// 验证时间，类型满足要求
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public OperateResult CheckTimeAndType(DateTime start, DateTime end, string type)
        {
            if (start==null||start.ToString().Length<=0)
            {
                return OperateResult.CreateFailResult("开始时间为空");
            }
            if (end==null||end.ToString().Length<=0)
            {
                return OperateResult.CreateFailResult("结束时间为空");
            }
            if (start>end)
            {
                return OperateResult.CreateFailResult("开始时间超过了结束时间");
            }
            if ((end-start).TotalHours>=24)
            {
                return OperateResult.CreateFailResult("开始和结束时间之间超过了24小时");
            }
            if (type!=null&&type.Trim().Length<=0)
            {
                return OperateResult.CreateFailResult("没有选择查询类型");
            }
            return OperateResult.CreateSuccessResult();
        }


        /// <summary>
        /// 导出为Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter="Excel文件|*.xls";
            saveFileDialog.Title="日志保存";
            saveFileDialog.InitialDirectory=@"C:\Users";

            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                if (path!=null)
                {
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
        }

        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Log_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgv_Log, e);
        }
    }
}

