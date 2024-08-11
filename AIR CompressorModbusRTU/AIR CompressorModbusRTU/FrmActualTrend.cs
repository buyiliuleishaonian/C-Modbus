using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AIR_CompressorModbusRTU
{
    public partial class FrmActualTrend : Form
    {
        public FrmActualTrend()
        {
            InitializeComponent();

            //设定曲线的X轴属性类型
            this.Chart_ActualThread.XDataType=SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.TimeStamp;
            this.Chart_ActualThread.TimeStampFormat="HH:MM:ss";
            //设置图列是否可见
            this.Chart_ActualThread.LegendVisible=false;
            //设置最多一秒绘制多少个点
            this.Chart_ActualThread.DisplayPoints=4000;
            //设置Y轴的范围
            this.Chart_ActualThread.AxisY.Maximum=100.0f;
            this.Chart_ActualThread.AxisY.Minimum=-100.0f;
            this.Chart_ActualThread.AxisY.AutoScale=false;

            this.Chart_ActualThread.AxisY2.Maximum=10.0f;
            this.Chart_ActualThread.AxisY2.Minimum=-10.0f;
            this.Chart_ActualThread.AxisY2.AutoScale=false;

            //设定曲线
            if (CommonMethod.PLCDevice!=null)
            {
                //得到曲线总数
                int title = CommonMethod.PLCDevice.StoreVarList.Count;
                this.Chart_ActualThread.Series.Clear();
                this.Chart_ActualThread.SeriesCount=title;
                //设置曲线
                for (int i = 0; i<title; i++)
                {
                    //设置曲线名称
                    this.Chart_ActualThread.Series[i].Name=CommonMethod.PLCDevice.StoreVarList[i].Comments;
                    //设置曲线是否可见
                    this.Chart_ActualThread.Series[i].Visible=false;
                    //设置曲线粗细
                    this.Chart_ActualThread.Series[i].Width=SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
                    //设置每个曲线对应的Y轴
                    if (this.Chart_ActualThread.Series[i].Name.Contains("温度"))
                    {
                        this.Chart_ActualThread.Series[i].YPlotAxis=SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
                    }
                    else
                    {
                        this.Chart_ActualThread.Series[i].YPlotAxis=SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Secondary;
                    }
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
                    CheckBox checkBox=new CheckBox();
                    checkBox.AutoSize=true;
                    checkBox.ForeColor=Color.White;
                    checkBox.Name="chk_"+i.ToString();
                    checkBox.Text=CommonMethod.PLCDevice.StoreVarList[i].Comments.ToString();
                    checkBox.Tag=i.ToString();
                    int y = i/6;
                    int x = i%6;
                    checkBox.Location=new Point(xstart+x*column,ystart+y*row);

                    checkBox.CheckedChanged+=CheckBox_CheckedChanged;
                    checkBox.Checked=i<CommonMethod.config.SaveShowSeriesCount ? true:false;

                    this.panelMain.Controls.Add(checkBox);
                }
            }

            Timer=new Timer();
            Timer.Interval=200;
            Timer.Start();
            Timer.Tick+=Timer_Tick;

            this.FormClosing+=(sender,e) =>
            {
                Timer?.Stop();
            };
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CommonMethod.PLCDevice.IsConnected)
            {
                List<double> ydata= new List<double>();
                foreach (var item in CommonMethod.PLCDevice.StoreVarList)
                {
                    string value=item.VarValue.ToString();
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
        }

        private Timer Timer;

        /// <summary>
        /// 显示特定曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
           if (sender is CheckBox checkBox)
            {
                if (checkBox.Text!=null&&checkBox.Tag!=null)
                {
                    int index =Convert.ToInt32( checkBox.Tag.ToString());
                    this.Chart_ActualThread.Series[index].Visible = checkBox.Checked;
                }
            }
        }
    }
}
