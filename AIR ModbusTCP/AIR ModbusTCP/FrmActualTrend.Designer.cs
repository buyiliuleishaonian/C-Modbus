namespace AIR_ModbusTCP
{
    partial class FrmActualTrend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SeeSharpTools.JY.GUI.StripChartXSeries stripChartXSeries1 = new SeeSharpTools.JY.GUI.StripChartXSeries();
            SeeSharpTools.JY.GUI.StripChartXSeries stripChartXSeries2 = new SeeSharpTools.JY.GUI.StripChartXSeries();
            this.panelEnhanced1 = new thinger.ControlLib.PanelEnhanced();
            this.panelMain = new thinger.ControlLib.PanelEx();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.panelEx1 = new thinger.ControlLib.PanelEx();
            this.Chart_ActualThread = new SeeSharpTools.JY.GUI.StripChartX();
            this.panelEnhanced1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::AIR_ModbusTCP.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.panelMain);
            this.panelEnhanced1.Controls.Add(this.lbl_Title);
            this.panelEnhanced1.Controls.Add(this.panelEx1);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1280, 800);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.BorderColor = System.Drawing.Color.Blue;
            this.panelMain.BorderWidth = 2;
            this.panelMain.Controls.Add(this.checkBox7);
            this.panelMain.Controls.Add(this.checkBox1);
            this.panelMain.Controls.Add(this.checkBox8);
            this.panelMain.Controls.Add(this.checkBox2);
            this.panelMain.Controls.Add(this.checkBox9);
            this.panelMain.Controls.Add(this.checkBox3);
            this.panelMain.Controls.Add(this.checkBox10);
            this.panelMain.Controls.Add(this.checkBox4);
            this.panelMain.Controls.Add(this.checkBox11);
            this.panelMain.Controls.Add(this.checkBox5);
            this.panelMain.Controls.Add(this.checkBox12);
            this.panelMain.Controls.Add(this.checkBox6);
            this.panelMain.ForeColor = System.Drawing.Color.White;
            this.panelMain.Location = new System.Drawing.Point(45, 686);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1178, 93);
            this.panelMain.TabIndex = 5;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox7.ForeColor = System.Drawing.Color.White;
            this.checkBox7.Location = new System.Drawing.Point(939, 67);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(144, 23);
            this.checkBox7.TabIndex = 11;
            this.checkBox7.Tag = "KYJ4_OutTemp";
            this.checkBox7.Text = "4#空压机出口温度";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(34, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 23);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Tag = "LQT_Level";
            this.checkBox1.Text = "冷却塔液位";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox8.ForeColor = System.Drawing.Color.White;
            this.checkBox8.Location = new System.Drawing.Point(758, 67);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(144, 23);
            this.checkBox8.TabIndex = 10;
            this.checkBox8.Tag = "KYJ3_OutTemp";
            this.checkBox8.Text = "3#空压机出口温度";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(215, 20);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(126, 23);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Tag = "LQT_InTemp";
            this.checkBox2.Text = "冷却塔进口温度";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox9.ForeColor = System.Drawing.Color.White;
            this.checkBox9.Location = new System.Drawing.Point(577, 67);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(144, 23);
            this.checkBox9.TabIndex = 9;
            this.checkBox9.Tag = "KYJ2_OutTemp";
            this.checkBox9.Text = "2#空压机出口温度";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox3.ForeColor = System.Drawing.Color.White;
            this.checkBox3.Location = new System.Drawing.Point(396, 20);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(126, 23);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Tag = "LQT_InPre";
            this.checkBox3.Text = "冷却塔进口压力";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox10.ForeColor = System.Drawing.Color.White;
            this.checkBox10.Location = new System.Drawing.Point(396, 67);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(144, 23);
            this.checkBox10.TabIndex = 8;
            this.checkBox10.Tag = "KYJ1_OutTemp";
            this.checkBox10.Text = "1#空压机出口温度";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox4.ForeColor = System.Drawing.Color.White;
            this.checkBox4.Location = new System.Drawing.Point(577, 20);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(126, 23);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Tag = "LQT_OutTemp";
            this.checkBox4.Text = "冷却塔出口温度";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox11.ForeColor = System.Drawing.Color.White;
            this.checkBox11.Location = new System.Drawing.Point(215, 67);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(116, 23);
            this.checkBox11.TabIndex = 7;
            this.checkBox11.Tag = "LQB2_OutPer";
            this.checkBox11.Text = "2#冷却泵压力";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox5.ForeColor = System.Drawing.Color.White;
            this.checkBox5.Location = new System.Drawing.Point(758, 20);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(126, 23);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Tag = "LQT_OutPer";
            this.checkBox5.Text = "冷却塔出口压力";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox12.ForeColor = System.Drawing.Color.White;
            this.checkBox12.Location = new System.Drawing.Point(34, 67);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(116, 23);
            this.checkBox12.TabIndex = 6;
            this.checkBox12.Tag = "LQB1_OutPer";
            this.checkBox12.Text = "1#冷却泵压力";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox6.ForeColor = System.Drawing.Color.White;
            this.checkBox6.Location = new System.Drawing.Point(939, 20);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(126, 23);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Tag = "LQT_RTNTemp";
            this.checkBox6.Text = "冷却塔回水温度";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(28, 29);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(102, 28);
            this.lbl_Title.TabIndex = 3;
            this.lbl_Title.Text = "实时趋势";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.Transparent;
            this.panelEx1.BorderColor = System.Drawing.Color.Blue;
            this.panelEx1.BorderWidth = 2;
            this.panelEx1.Controls.Add(this.Chart_ActualThread);
            this.panelEx1.Location = new System.Drawing.Point(45, 94);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1178, 585);
            this.panelEx1.TabIndex = 4;
            // 
            // Chart_ActualThread
            // 
            this.Chart_ActualThread.AxisX.AutoScale = false;
            this.Chart_ActualThread.AxisX.AutoZoomReset = false;
            this.Chart_ActualThread.AxisX.Color = System.Drawing.Color.White;
            this.Chart_ActualThread.AxisX.InitWithScaleView = false;
            this.Chart_ActualThread.AxisX.IsLogarithmic = false;
            this.Chart_ActualThread.AxisX.LabelAngle = 0;
            this.Chart_ActualThread.AxisX.LabelEnabled = true;
            this.Chart_ActualThread.AxisX.LabelFormat = null;
            this.Chart_ActualThread.AxisX.MajorGridColor = System.Drawing.Color.White;
            this.Chart_ActualThread.AxisX.MajorGridCount = 6;
            this.Chart_ActualThread.AxisX.MajorGridEnabled = true;
            this.Chart_ActualThread.AxisX.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.Chart_ActualThread.AxisX.Maximum = 1000D;
            this.Chart_ActualThread.AxisX.Minimum = 0D;
            this.Chart_ActualThread.AxisX.MinorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualThread.AxisX.MinorGridEnabled = false;
            this.Chart_ActualThread.AxisX.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.Chart_ActualThread.AxisX.TickWidth = 1F;
            this.Chart_ActualThread.AxisX.Title = "";
            this.Chart_ActualThread.AxisX.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.Chart_ActualThread.AxisX.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.Chart_ActualThread.AxisX.ViewMaximum = 1000D;
            this.Chart_ActualThread.AxisX.ViewMinimum = 0D;
            this.Chart_ActualThread.AxisX2.AutoScale = false;
            this.Chart_ActualThread.AxisX2.AutoZoomReset = false;
            this.Chart_ActualThread.AxisX2.Color = System.Drawing.Color.Black;
            this.Chart_ActualThread.AxisX2.InitWithScaleView = false;
            this.Chart_ActualThread.AxisX2.IsLogarithmic = false;
            this.Chart_ActualThread.AxisX2.LabelAngle = 0;
            this.Chart_ActualThread.AxisX2.LabelEnabled = true;
            this.Chart_ActualThread.AxisX2.LabelFormat = null;
            this.Chart_ActualThread.AxisX2.MajorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualThread.AxisX2.MajorGridCount = 6;
            this.Chart_ActualThread.AxisX2.MajorGridEnabled = true;
            this.Chart_ActualThread.AxisX2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.Chart_ActualThread.AxisX2.Maximum = 1000D;
            this.Chart_ActualThread.AxisX2.Minimum = 0D;
            this.Chart_ActualThread.AxisX2.MinorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualThread.AxisX2.MinorGridEnabled = false;
            this.Chart_ActualThread.AxisX2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.Chart_ActualThread.AxisX2.TickWidth = 1F;
            this.Chart_ActualThread.AxisX2.Title = "";
            this.Chart_ActualThread.AxisX2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.Chart_ActualThread.AxisX2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.Chart_ActualThread.AxisX2.ViewMaximum = 1000D;
            this.Chart_ActualThread.AxisX2.ViewMinimum = 0D;
            this.Chart_ActualThread.AxisY.AutoScale = true;
            this.Chart_ActualThread.AxisY.AutoZoomReset = false;
            this.Chart_ActualThread.AxisY.Color = System.Drawing.Color.White;
            this.Chart_ActualThread.AxisY.InitWithScaleView = false;
            this.Chart_ActualThread.AxisY.IsLogarithmic = false;
            this.Chart_ActualThread.AxisY.LabelAngle = 0;
            this.Chart_ActualThread.AxisY.LabelEnabled = true;
            this.Chart_ActualThread.AxisY.LabelFormat = null;
            this.Chart_ActualThread.AxisY.MajorGridColor = System.Drawing.Color.White;
            this.Chart_ActualThread.AxisY.MajorGridCount = 5;
            this.Chart_ActualThread.AxisY.MajorGridEnabled = true;
            this.Chart_ActualThread.AxisY.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.Chart_ActualThread.AxisY.Maximum = 5D;
            this.Chart_ActualThread.AxisY.Minimum = 0.5D;
            this.Chart_ActualThread.AxisY.MinorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualThread.AxisY.MinorGridEnabled = false;
            this.Chart_ActualThread.AxisY.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.Chart_ActualThread.AxisY.TickWidth = 0F;
            this.Chart_ActualThread.AxisY.Title = "";
            this.Chart_ActualThread.AxisY.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.Chart_ActualThread.AxisY.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.Chart_ActualThread.AxisY.ViewMaximum = 1D;
            this.Chart_ActualThread.AxisY.ViewMinimum = 0.5D;
            this.Chart_ActualThread.AxisY2.AutoScale = true;
            this.Chart_ActualThread.AxisY2.AutoZoomReset = false;
            this.Chart_ActualThread.AxisY2.Color = System.Drawing.Color.White;
            this.Chart_ActualThread.AxisY2.InitWithScaleView = false;
            this.Chart_ActualThread.AxisY2.IsLogarithmic = false;
            this.Chart_ActualThread.AxisY2.LabelAngle = 0;
            this.Chart_ActualThread.AxisY2.LabelEnabled = true;
            this.Chart_ActualThread.AxisY2.LabelFormat = null;
            this.Chart_ActualThread.AxisY2.MajorGridColor = System.Drawing.Color.White;
            this.Chart_ActualThread.AxisY2.MajorGridCount = 5;
            this.Chart_ActualThread.AxisY2.MajorGridEnabled = true;
            this.Chart_ActualThread.AxisY2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.Chart_ActualThread.AxisY2.Maximum = 1D;
            this.Chart_ActualThread.AxisY2.Minimum = 0D;
            this.Chart_ActualThread.AxisY2.MinorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualThread.AxisY2.MinorGridEnabled = false;
            this.Chart_ActualThread.AxisY2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.Chart_ActualThread.AxisY2.TickWidth = 0F;
            this.Chart_ActualThread.AxisY2.Title = "";
            this.Chart_ActualThread.AxisY2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.Chart_ActualThread.AxisY2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.Chart_ActualThread.AxisY2.ViewMaximum = 1D;
            this.Chart_ActualThread.AxisY2.ViewMinimum = 0D;
            this.Chart_ActualThread.BackColor = System.Drawing.Color.Transparent;
            this.Chart_ActualThread.ChartAreaBackColor = System.Drawing.Color.Transparent;
            this.Chart_ActualThread.Direction = SeeSharpTools.JY.GUI.StripChartX.ScrollDirection.LeftToRight;
            this.Chart_ActualThread.DisplayPoints = 4000;
            this.Chart_ActualThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chart_ActualThread.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Chart_ActualThread.ForeColor = System.Drawing.Color.White;
            this.Chart_ActualThread.GradientStyle = SeeSharpTools.JY.GUI.StripChartX.ChartGradientStyle.None;
            this.Chart_ActualThread.LegendBackColor = System.Drawing.Color.Transparent;
            this.Chart_ActualThread.LegendFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Chart_ActualThread.LegendForeColor = System.Drawing.Color.White;
            this.Chart_ActualThread.LegendVisible = false;
            stripChartXSeries1.Color = System.Drawing.Color.Red;
            stripChartXSeries1.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries1.Name = "Series1";
            stripChartXSeries1.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries1.Visible = true;
            stripChartXSeries1.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries1.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries1.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries2.Color = System.Drawing.Color.Blue;
            stripChartXSeries2.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries2.Name = "Series2";
            stripChartXSeries2.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries2.Visible = true;
            stripChartXSeries2.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries2.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries2.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Secondary;
            this.Chart_ActualThread.LineSeries.Add(stripChartXSeries1);
            this.Chart_ActualThread.LineSeries.Add(stripChartXSeries2);
            this.Chart_ActualThread.Location = new System.Drawing.Point(0, 0);
            this.Chart_ActualThread.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Chart_ActualThread.Miscellaneous.CheckInfinity = false;
            this.Chart_ActualThread.Miscellaneous.CheckNaN = false;
            this.Chart_ActualThread.Miscellaneous.CheckNegtiveOrZero = false;
            this.Chart_ActualThread.Miscellaneous.DirectionChartCount = 3;
            this.Chart_ActualThread.Miscellaneous.Fitting = SeeSharpTools.JY.GUI.StripChartX.FitType.Range;
            this.Chart_ActualThread.Miscellaneous.MaxSeriesCount = 32;
            this.Chart_ActualThread.Miscellaneous.MaxSeriesPointCount = 4000;
            this.Chart_ActualThread.Miscellaneous.SplitLayoutColumnInterval = 0F;
            this.Chart_ActualThread.Miscellaneous.SplitLayoutDirection = SeeSharpTools.JY.GUI.StripChartXUtility.LayoutDirection.LeftToRight;
            this.Chart_ActualThread.Miscellaneous.SplitLayoutRowInterval = 0F;
            this.Chart_ActualThread.Miscellaneous.SplitViewAutoLayout = true;
            this.Chart_ActualThread.Name = "Chart_ActualThread";
            this.Chart_ActualThread.NextTimeStamp = new System.DateTime(((long)(0)));
            this.Chart_ActualThread.ScrollType = SeeSharpTools.JY.GUI.StripChartX.StripScrollType.Cumulation;
            this.Chart_ActualThread.SeriesCount = 2;
            this.Chart_ActualThread.Size = new System.Drawing.Size(1178, 585);
            this.Chart_ActualThread.SplitView = false;
            this.Chart_ActualThread.StartIndex = 0;
            this.Chart_ActualThread.TabIndex = 0;
            this.Chart_ActualThread.TimeInterval = System.TimeSpan.Parse("00:00:00");
            this.Chart_ActualThread.TimeStampFormat = null;
            this.Chart_ActualThread.XCursor.AutoInterval = true;
            this.Chart_ActualThread.XCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.Chart_ActualThread.XCursor.Interval = 0.001D;
            this.Chart_ActualThread.XCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Zoom;
            this.Chart_ActualThread.XCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.Chart_ActualThread.XCursor.Value = double.NaN;
            this.Chart_ActualThread.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.Index;
            this.Chart_ActualThread.YCursor.AutoInterval = true;
            this.Chart_ActualThread.YCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.Chart_ActualThread.YCursor.Interval = 0.001D;
            this.Chart_ActualThread.YCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Disabled;
            this.Chart_ActualThread.YCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.Chart_ActualThread.YCursor.Value = double.NaN;
            // 
            // FrmActualTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmActualTrend";
            this.Text = "实时趋势";
            this.panelEnhanced1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private thinger.ControlLib.PanelEx panelMain;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label lbl_Title;
        private thinger.ControlLib.PanelEx panelEx1;
        public SeeSharpTools.JY.GUI.StripChartX Chart_ActualThread;
    }
}