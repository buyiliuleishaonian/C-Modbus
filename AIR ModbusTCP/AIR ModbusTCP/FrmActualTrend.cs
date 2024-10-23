using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace AIR_ModbusTCP
{
    public partial class FrmActualTrend : Form
    {
        public FrmActualTrend()
        {
            InitializeComponent();
            //先确定XY轴的数据类型
            this.Chart_ActualThread.XDataType=SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.TimeStamp;
            this.Chart_ActualThread.TimeStampFormat="HH:mm:ss";
            //再确定绘制多少点
            this.Chart_ActualThread.DisplayPoints=4000;
            //曲线标题是否可见
            this.Chart_ActualThread.LegendVisible=false;
            //设置Y轴的最大值和最小值  
            this.Chart_ActualThread.AxisY.Maximum=5.0;
            this.Chart_ActualThread.AxisY.Minimum=0.0;
            this.Chart_ActualThread.AxisY.AutoScale=false;
            this.Chart_ActualThread.AxisY2.Maximum=100.0;
            this.Chart_ActualThread.AxisY2.Maximum=0.0;
            this.Chart_ActualThread.AxisY2.AutoScale=false;


            DispalySerice();

            updateTime.Interval=200;
            updateTime.Elapsed+=UpdateTime_Elapsed;
            updateTime.Start();

            this.FormClosing+=FrmActualTrend_FormClosing;

        }



        private void FrmActualTrend_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTime?.Stop();
        }

        private void UpdateTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (CommonMethod.PLCDevice.IsConnected)
                {
                    List<double> ydata = new List<double>();
                    foreach (var item in CommonMethod.PLCDevice.StoreVarList)
                    {
                        string value = item.VarValue.ToString();
                        if (double.TryParse(value, out double currentValue))
                        {
                            ydata.Add(currentValue);
                        }
                        else
                        {
                            ydata.Add(0.0);
                        }
                    }
                    this.Chart_ActualThread.PlotSingle(ydata.ToArray());
                }
            }));

        }

        private System.Timers.Timer updateTime = new System.Timers.Timer();

        private void DispalySerice()
        {
            if (CommonMethod.PLCDevice.StoreVarList.Count>0)
            {
                this.Chart_ActualThread.Series.Clear();
                int title = CommonMethod.PLCDevice.StoreVarList.Count;
                this.Chart_ActualThread.SeriesCount=title;
                for (int i = 0; i < title; i++)
                {
                    this.Chart_ActualThread.Series[i].Name=CommonMethod.PLCDevice.StoreVarList[i].Comments;
                    if (this.Chart_ActualThread.Series[i].Name.Contains("温度"))
                    {
                        this.Chart_ActualThread.Series[i].YPlotAxis=SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Secondary;
                    }
                    else
                    {
                        this.Chart_ActualThread.Series[i].YPlotAxis=SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
                    }
                    this.Chart_ActualThread.Series[i].Visible=false;
                    this.Chart_ActualThread.Series[i].Width=SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
                }
                //设置PanelMain中的控件 
                //设置chackBox
                this.panelMain.Controls.Clear();

                int row = 47;
                int column = 181;

                int xstart = 34;
                int ystart = 20;

                for (int i = 0; i < title; i++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.AutoSize=true;
                    checkBox.ForeColor=Color.White;
                    checkBox.Name="chk_"+i.ToString();
                    checkBox.Text=CommonMethod.PLCDevice.StoreVarList[i].Comments.ToString();
                    checkBox.Tag=i.ToString();
                    int y = i/6;
                    int x = i%6;
                    checkBox.Location=new Point(xstart+x*column, ystart+y*row);

                    checkBox.CheckedChanged+=CheckBox_CheckedChanged; ;
                    checkBox.Checked=i<CommonMethod.Config.SaveShowSeriesCount ? true : false;

                    this.panelMain.Controls.Add(checkBox);
                }
            }
        }

        /// <summary>
        /// 显示曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                var index = sender as CheckBox;
                this.Chart_ActualThread.Series[Convert.ToInt32(index.Tag)].Visible=index.Checked;
            }
        }
    }
}

