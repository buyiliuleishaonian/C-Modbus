using kYJBLL;
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

namespace AIR_CompressorModbusRTU
{
    public partial class FrmHistoryTrend : Form
    {
        public FrmHistoryTrend()
        {
            InitializeComponent();

            //初始化曲线控件
            //设定曲线的X轴类型
            this.ChartHistory.XDataType=SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.TimeStamp;
            this.ChartHistory.TimeStampFormat="HH:MM:ss";
            //设定图列显示
            this.ChartHistory.LegendVisible=false;
            //1分钟绘制点数
            this.ChartHistory.DisplayPoints=100000;

            //对于Y轴的绘制需要根据参数变化来变化
            this.ChartHistory.AxisY.AutoScale=false;
            this.ChartHistory.AxisY.Maximum=100.0f;
            this.ChartHistory.AxisY.Minimum=-100.0f;

            this.ChartHistory.AxisY2.Maximum=3.5f;
            this.ChartHistory.AxisY2.Minimum=-3.5f;
            this.ChartHistory.AxisY2.AutoScale=false;


            //设置时间
            this.date_Start.Value=DateTime.Now.AddHours(-2);

            if (CommonMethod.PLCDevice!=null&&CommonMethod.config!=null)
            {
                for (int i = 0; i<Math.Min(CommonMethod.config.SaveShowSeriesCount, CommonMethod.PLCDevice.StoreVarList.Count); i++)
                {
                    selectParam.Add(CommonMethod.PLCDevice.StoreVarList[i].Comments);
                }
                BindComboBoxChanage();
            }
        }

        /// <summary>
        /// 绑定ComboBox选择改变触发事件
        /// </summary>
        public void BindComboBoxChanage()
        {
            this.cmb_Param.SelectedIndexChanged-=Cmb_Param_SelectedIndexChanged;
            this.cmb_Param.Items.Clear();
            this.cmb_Param.Items.AddRange(selectParam.ToArray());
            this.cmb_Param.SelectedIndex=0;
            this.cmb_Param.SelectedIndexChanged+=Cmb_Param_SelectedIndexChanged;
        }

        /// <summary>
        /// 只查询对应的变量历史数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Param_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <this.ChartHistory.SeriesCount; i++)
            {
                this.ChartHistory.Series[i].Visible=this.cmb_Param.Text==this.ChartHistory.Series[i].Name;
            }
        }

        /// <summary>
        /// 实时数据逻辑
        /// </summary>
        private ActualDataManage ActualDataManage { get; set; } = new ActualDataManage();

        private List<string> selectParam { get; set; } = new List<string>();


        /// <summary>
        /// 通过时间以及参数查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            string start = this.date_Start.Text;
            string end = this.date_End.Text;
            string varName = this.cmb_Param.Text;
            //添加参数
            if (!selectParam.Contains(this.cmb_Param.Text))
            {
                selectParam.Add(this.cmb_Param.Text);
            }
            Task<OperateResult<DataTable>> task1 = Task.Run(() =>
            {
                return SelectHistoryData(start, end, varName);
            });
            //得到Task1线程的结果
            var taskResult = task1.GetAwaiter().GetResult();
            //这样也可以得到task1的结果
            if (taskResult.IsSuccess)
            {
                UpdateChart(taskResult.Content, start, end);
            }
            else
            {
                CommonMethod.AddOpLog(false, "查询历史信息错误");
            }
        }

        /// <summary>
        /// 查询历史数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="varname"></param>
        /// <returns></returns>
        public OperateResult<DataTable> SelectHistoryData(string start, string end, string varName)
        {
            if (varName==null)
            {
                CommonMethod.AddOpLog(true, "没有选择参数");
                new FrmMessageBoxWithAck("参数数据查询", $"参数{this.cmb_Param.Text}数据历史查询").ShowDialog();
                return null;
            }
            if (Convert.ToDateTime(start)>=Convert.ToDateTime(end))
            {
                CommonMethod.AddOpLog(true, "开始时间比结束时间晚");
                new FrmMessageBoxWithAck("参数数据查询", "开始时间比结束时间晚").ShowDialog();
                return null;
            }
            if ((Convert.ToDateTime(end)-Convert.ToDateTime(start)).TotalHours>=24)
            {
                CommonMethod.AddOpLog(true, "查询时间超过了24小时");
                new FrmMessageBoxWithAck("参数数据查询", "查询时间超过了24小时").ShowDialog();
                return null;
            }
            var result = selectParam.Select(c => CommonMethod.PLCDevice.StoreVarList.FirstOrDefault(d => d.Comments==c).VarName).ToList();
            return OperateResult.CreateSuccessResult(ActualDataManage.SelectHistoryData(start, end, result));
        }

        /// <summary>
        /// 绘制曲线
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void UpdateChart(DataTable dt, string start, string end)
        {
            //清空曲线，获取曲线数量
            this.ChartHistory.Clear();
            int count = selectParam.Count;
            this.ChartHistory.SeriesCount = count;
            //设定曲线名称，粗细，是否可见
            for (int i = 0; i < count; i++)
            {
                this.ChartHistory.Series[i].Name=this.cmb_Param.Items[i].ToString();
                this.ChartHistory.Series[i].Width=SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
                this.ChartHistory.Series[i].Visible=true;

                if (this.ChartHistory.Series[i].Name.Contains("温度"))
                {
                    this.ChartHistory.Series[i].YPlotAxis=SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
                }
                else
                {
                    this.ChartHistory.Series[i].YPlotAxis=SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Secondary;
                }
            }

            DateTime[] Xdata = GetTime(Convert.ToDateTime(start), Convert.ToDateTime(end)).ToArray();
            double[,] Ydata = new double[count, Xdata.Length];
            var varList = BindDataTbale(dt);

            for (int i = 0; i < Xdata.Length; i++)
            {
                if (varList.ContainsKey(Xdata[i]))
                {

                    for (int j = 0; j < count; j++)
                    {
                        try
                        {
                            Ydata[j, i]=Convert.ToDouble(varList[Xdata[i]][j]);
                        }
                        catch (Exception ex)
                        {
                            Ydata[j, i]=0;
                        }
                    }


                }
                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        Ydata[j, i]=0;
                    }
                }
            }
            this.ChartHistory.Plot(Ydata, Xdata);

        }


        /// <summary>
        /// 将一段时间内的，每一秒都取出来
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private List<DateTime> GetTime(DateTime start, DateTime end)
        {
            List<DateTime> list = new List<DateTime>();
            DateTime t1 = start;
            while (t1<=end)
            {
                list.Add(t1);
                t1=t1.AddSeconds(1);
            }
            return list;
        }


        /// <summary>
        /// 将Datatable拆分为Dictionary
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Dictionary<DateTime, List<string>> BindDataTbale(DataTable dt)
        {
            Dictionary<DateTime, List<string>> varList = new Dictionary<DateTime, List<string>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime dtime = Convert.ToDateTime(dt.Rows[i][0]);
                List<string> result = new List<string>();
                for (int j = 0; j<dt.Columns.Count-1; j++)
                {
                    result.Add(dt.Rows[i][j+1].ToString());
                }
                if (!varList.ContainsKey(dtime))
                {
                    varList.Add(dtime, result);
                }
            }
            return varList;
        }

        /// <summary>
        /// 保存为CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title="保存历史数据";
            saveFileDialog.InitialDirectory=@"C:\Users";
            saveFileDialog.FileName="历史数据"+DateTime.Now.ToString("yyyyMMddhhss");
            saveFileDialog.Filter="图片文件|*.CSV|所有文件|*.*";
            saveFileDialog.AddExtension=true;
            saveFileDialog.DefaultExt="CSV";

            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                string fileName=saveFileDialog.FileName;
                this.ChartHistory.SaveAsCsv(fileName);
                if (new FrmMessageBoxWithAck("打开文件", "确认是否开打").ShowDialog()==DialogResult.OK)
                {
                    Process.Start(fileName);
                }
            }
        }

        /// <summary>
        /// 保存为Image图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title="保存历史数据";
            saveFileDialog.InitialDirectory=@"C:\Users";
            saveFileDialog.FileName="历史数据"+DateTime.Now.ToString("yyyyMMddhhss");
            saveFileDialog.Filter="图片文件|*.png|所有文件|*.*";
            saveFileDialog.AddExtension=true;
            saveFileDialog.DefaultExt="png";

            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                this.ChartHistory.SaveAsImage(fileName);
                if (new FrmMessageBoxWithAck("打开文件", "确认是否开打").ShowDialog()==DialogResult.OK)
                {
                    Process.Start(fileName);
                }
            }
        }

        /// <summary>
        /// 显示参数变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            SelectParam select = null;
            if (CommonMethod.PLCDevice.IsConnected&&CommonMethod.PLCDevice.StoreVarList!=null)
            {
                FrmSelectParam frm = new FrmSelectParam(selectParam);
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    select+=frm.SelectAddOrDeleteParam;
                    selectParam=select();
                    this.cmb_Param.Items.Clear();
                    this.cmb_Param.Items.AddRange(selectParam.ToArray());
                    this.cmb_Param.SelectedIndex = 0;
                    CommonMethod.SetSaveShowSeriesCount(this.selectParam.Count);
                }
            }
        }
    }
}
