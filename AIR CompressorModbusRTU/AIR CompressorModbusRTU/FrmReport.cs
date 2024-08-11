using CommonHelper;
using kYJBLL;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
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

namespace AIR_CompressorModbusRTU
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();

            Initial();

            this.dgv_ParamData.AutoGenerateColumns=false;

            this.cmb_Param.SelectedIndexChanged+=Cmb_Param_SelectedIndexChanged;

            this.cmb_Param.Items.AddRange(new string[] { "一小时制", "一天制" });

            this.cmb_Param.SelectedIndex = 0;

            this.date_Start.Value= DateTime.Now;

        }

        /// <summary>
        /// 查询的时间段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Param_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmb_Param.SelectedIndex)
            {
                case 0:
                    this.date_Start.CustomFormat="yyyy-MM-dd HH:00:00";
                    break;
                case 1:
                    this.date_Start.CustomFormat="yyyy-MM-dd 00:00:00";
                    break;
                default:
                    this.date_Start.CustomFormat="yyyy-MM-dd 00:00:00";
                    break;
            }
        }

        /// <summary>
        /// 绘制表列名集合
        /// </summary>
        private List<DataGridViewTextBoxColumn> columnlist = new List<DataGridViewTextBoxColumn>();

        /// <summary>
        /// 最大值限制集合
        /// </summary>
        private List<string> maxcondition = new List<string>();
        /// <summary>
        /// 最小值限制集合
        /// </summary>
        private List<string> mincondition = new List<string>();
        /// <summary>
        /// 平均值集合
        /// </summary>
        private List<string> agvcondition = new List<string>();
        /// <summary>
        /// 数据表访问
        /// </summary>
        private ActualDataManage ActualDataManage = new ActualDataManage();


        /// <summary>
        /// 设定DataGridView列名
        /// </summary>
        private void Initial()
        {
            this.dgv_ParamData.Columns.Clear();
            this.dgv_ParamData.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText="日期时间",
                DataPropertyName="insertTime",
                ReadOnly=true,
                Width=170,
                Name="Columns"+1.ToString(),
                SortMode=System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
            });
            foreach (var item in CommonMethod.PLCDevice.StoreVarList)
            {
                maxcondition.Add($"MAX({item.VarName})");
                mincondition.Add($"Min({item.VarName})");
                agvcondition.Add($"AVG({item.VarName})");
            }
            if (CommonMethod.PLCDevice.IsConnected&&CommonMethod.PLCDevice.StoreVarList!=null)
            {
                for (int i = 0; i <CommonMethod.PLCDevice.StoreVarList.Count; i++)
                {
                    columnlist.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText=CommonMethod.PLCDevice.StoreVarList[i].Comments,
                        DataPropertyName=CommonMethod.PLCDevice.StoreVarList[i].VarName,
                        ReadOnly=true,
                        Width=150,
                        Name="Columns"+(i+2).ToString(),
                        SortMode=System.Windows.Forms.DataGridViewColumnSortMode.NotSortable,
                    });
                }
                this.dgv_ParamData.Columns.AddRange(columnlist.ToArray());
            }

        }


        //这里查询，指的是查询时间段里面的最大值，最小值，平均值，也就是需要对每段时间，每个变量，查询出来一个数据表

        /// <summary>
        /// 查询数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            this.dgv_ParamData.Rows.Clear();
            List<string> startlist = new List<string>();
            List<string> endlist = new List<string>();
            List<string> condition = new List<string>();
            //先得到需要查询的时间段
            switch (this.cmb_Param.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i<60; i++)
                    {
                        startlist.Add(this.date_Start.Value.AddMinutes(i).ToString("yyyy-MM-dd HH:mm:ss"));
                        endlist.Add(this.date_Start.Value.AddMinutes(i+1).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    break;
                case 1:
                    for (int i = 0; i <24; i++)
                    {
                        startlist.Add(this.date_Start.Value.AddHours(i).ToString("yyyy-MM-dd HH:mm:ss"));
                        endlist.Add(this.date_Start.Value.AddHours(i+1).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    break;
                default:
                    for (int i = 0; i <24; i++)
                    {
                        startlist.Add(this.date_Start.Value.AddHours(i).ToString("yyyy-MM-dd HH:mm:ss"));
                        endlist.Add(this.date_Start.Value.AddHours(i+1).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    break;
            }
            condition=this.chk_Max.Checked ? maxcondition : this.chk_Min.Checked ? mincondition : agvcondition;
            FrmWaitTip frm=new FrmWaitTip();
            frm.Show();
            //需要在每个片段里面都要进行查询，所以需要开启多个线程
            Task.Factory.StartNew(() =>
            {
                Task<DataTable>[] tasklist = new Task<DataTable>[startlist.Count];
                for (int i = 0; i < startlist.Count; i++)
                {
                    tasklist[i]=Task.Factory.StartNew((Index) =>
                    {
                        //每次查询线程相差1秒
                        System.Threading.Thread.Sleep(100);
                        return ActualDataManage.QueryDataCondition(startlist[(int)Index], endlist[(int)Index], condition, "table"+i);
                    }, i);
                }
                //等待所有线程都跑完
                var task = Task.WhenAll(tasklist);
                DataTable result = GetDataTable(task.Result);
                this.Invoke(new Action(() =>
                {
                    frm.Close();
                    for (int i = 0; i < result.Rows.Count; i++)
                    {
                        int index = this.dgv_ParamData.Rows.Add();
                        //每行第一列
                        this.dgv_ParamData.Rows[i].Cells[0].Value=startlist[i].ToString();
                        for (int j = 0; j <result.Columns.Count; j++)
                        {
                            object value = result.Rows[index][j];
                            if (value is DBNull)
                            {
                                this.dgv_ParamData.Rows[i].Cells[j+1].Value=0.0;
                            }
                            else
                            {
                                try
                                {
                                    this.dgv_ParamData.Rows[i].Cells[j+1].Value=Convert.ToDouble(value).ToString("f2");
                                }
                                catch
                                {
                                    this.dgv_ParamData.Rows[i].Cells[j+1].Value=0.0;
                                }
                            }

                        }
                    }
                }));
            });
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title="保存数据报表";
            saveFileDialog.InitialDirectory=@"C:\Users";
            saveFileDialog.FileName="数据报表"+DateTime.Now.ToString("yyyyMMddhhss");
            saveFileDialog.Filter="文件|*.cvs|所有文件|*.*";
            saveFileDialog.AddExtension=true;
            saveFileDialog.DefaultExt="cvs";

            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                ExcelHelper.DataGridViewToExcelNew(fileName,this.dgv_ParamData);
                Process.Start(fileName);
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Export_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(this.dgv_ParamData);
        }

        /// <summary>
        /// 将相同结构的表数据，融合成一个表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable GetDataTable(DataTable[] dt)
        {
            //复制一张表的结构，作为最后表的结构
            DataTable result = dt[0].Clone();

            //设置行数据的数组，既一个行有多少列
            object[] rows = new object[result.Columns.Count];

            for (int i = 0; i < dt.Length; i++)
            {
                for (int j = 0; j < dt[i].Rows.Count; j++)
                {
                    //获得每张表，每行的数据
                    dt[i].Rows[j].ItemArray.CopyTo(rows, 0);
                    result.Rows.Add(rows);
                }
            }
            return result;
        }

        #region 绘制行号和样式
        private void dgv_ParamData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgv_ParamData, e);
        }

        private void dgv_ParamData_Paint(object sender, PaintEventArgs e)
        {
            new DataGridViewStyle().DgvStyle1(this.dgv_ParamData);
        }
        #endregion

    }
}
