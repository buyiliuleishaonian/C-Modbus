using AIR_BLL;
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
    public partial class FrmHistroyTrend : Form
    {
        public FrmHistroyTrend()
        {
            InitializeComponent();

            Initial();
        }

        private List<string> varname { get; set; } = new List<string>();

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
            this.cmb_Param.DataSource=null;


            this.date_Start.Value=DateTime.Now.AddHours(-2);
            this.date_End.Value=DateTime.Now;

            this.ChartHistory.XDataType=SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.TimeStamp;
            this.ChartHistory.TimeStampFormat="HH:mm:ss";

            this.ChartHistory.DisplayPoints=100000;
            this.ChartHistory.LegendVisible=false;

            this.ChartHistory.AxisY.Maximum=5.0;
            this.ChartHistory.AxisY.Minimum=0.0;
            this.ChartHistory.AxisY.AutoScale=false;
            this.ChartHistory.AxisY2.Maximum=100.0;
            this.ChartHistory.AxisY2.Minimum=0.0;
            this.ChartHistory.AxisY2.AutoScale=false;

            if (CommonMethod.PLCDevice.IsConnected&&CommonMethod.PLCDevice.StoreVarList.Count>0)
            {
                for (int i = 0; i < Math.Min(CommonMethod.Config.SaveShowSeriesCount, CommonMethod.PLCDevice.StoreVarList.Count); i++)
                {
                    varname.Add(CommonMethod.PLCDevice.StoreVarList[i].Comments);
                }
                BindCommonBoxChanage();
            }
        }

        /// <summary>
        /// 绑定数据，以及变化事件
        /// </summary>
        private void BindCommonBoxChanage()
        {
            this.cmb_Param.SelectedIndexChanged-=Cmb_Param_SelectedIndexChanged;
            this.cmb_Param.Items.Clear();
            this.cmb_Param.Items.AddRange(varname.ToArray());
            this.cmb_Param.SelectedIndex=0;
            this.cmb_Param.SelectedIndexChanged+=Cmb_Param_SelectedIndexChanged; ;

        }

        /// <summary>
        /// 保证只显示所对应的变量曲线
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
        /// 验证时间，类型满足要求
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public OperateResult CheckTimeAndType(DateTime start, DateTime end, List<string> type)
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
            if (type!=null&&type.Count()<=0)
            {
                return OperateResult.CreateFailResult("没有选择查询类型");
            }
            return OperateResult.CreateSuccessResult();
        }


        #region 查询，保存，导出

        /// <summary>
        /// 数据逻辑层
        /// </summary>
        private DataManage DataManage { get; set; } = new DataManage();

        private void btn_Select_Click(object sender, EventArgs e)
        {
            DateTime start = this.date_Start.Value;
            DateTime end = this.date_End.Value;
            var resdata = varname.Select(c => CommonMethod.PLCDevice.StoreVarList.FirstOrDefault(d => d.Comments==c).VarName).ToList(); ;
            var result1 = CheckTimeAndType(start, end, resdata);
            if (!varname.Contains(this.cmb_Param.Text))
            {
                varname.Add(this.cmb_Param.Text);
            }
            if (result1.IsSuccess)
            {
                Task<DataTable> task1 = Task.Run(() =>
                {
                    return DataManage.SelectData(start.ToString("yyyy-MM-dd HH:mm:ss")
                    , end.ToString("yyyy-MM-dd HH:mm:ss"), resdata);
                });
                //得到Task1线程的结果
                var taskResult = task1.GetAwaiter().GetResult();
                //这样也可以得到task1的结果
                if (taskResult.Rows.Count>0)
                {
                    UpdateChart(taskResult, start.ToString(), end.ToString());
                }
                else
                {
                    CommonMethod.Addoperatelog(false, "查询历史信息错误");
                }
            }
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
            int count = varname.Count;
            this.ChartHistory.SeriesCount = count;
            //设定曲线名称，粗细，是否可见
            for (int i = 0; i < count; i++)
            {
                this.ChartHistory.Series[i].Name=this.cmb_Param.Items[i].ToString();
                this.ChartHistory.Series[i].Width=SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
                this.ChartHistory.Series[i].Visible=true;

                if (this.ChartHistory.Series[i].Name.Contains("温度"))
                {
                    this.ChartHistory.Series[i].YPlotAxis=SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Secondary;
                }
                else
                {
                    this.ChartHistory.Series[i].YPlotAxis=SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
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
        /// 降指定的时间内的每一秒全部添加到List集合
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

        public Dictionary<DateTime, List<string>> BindDataTbale(DataTable dt)
        {
            Dictionary<DateTime, List<string>> varList = new Dictionary<DateTime, List<string>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var result1 = dt.Rows[i][0];
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
                string fileName = saveFileDialog.FileName;
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
        #endregion
    }
}

