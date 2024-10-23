namespace AIR_CompressorModbusRTU
{
    partial class FrmHistoryTrend
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
            this.btn_SelectParam = new thinger.ControlLib.PanelEnhanced();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.cmb_Param = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_End = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.date_Start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx1 = new thinger.ControlLib.PanelEx();
            this.ChartHistory = new SeeSharpTools.JY.GUI.StripChartX();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SelectParam.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_SelectParam
            // 
            this.btn_SelectParam.BackgroundImage = global::AIR_CompressorModbusRTU.Properties.Resources.background;
            this.btn_SelectParam.Controls.Add(this.button1);
            this.btn_SelectParam.Controls.Add(this.btn_save);
            this.btn_SelectParam.Controls.Add(this.btn_Export);
            this.btn_SelectParam.Controls.Add(this.btn_Select);
            this.btn_SelectParam.Controls.Add(this.cmb_Param);
            this.btn_SelectParam.Controls.Add(this.label4);
            this.btn_SelectParam.Controls.Add(this.date_End);
            this.btn_SelectParam.Controls.Add(this.label2);
            this.btn_SelectParam.Controls.Add(this.date_Start);
            this.btn_SelectParam.Controls.Add(this.label1);
            this.btn_SelectParam.Controls.Add(this.panelEx1);
            this.btn_SelectParam.Controls.Add(this.label3);
            this.btn_SelectParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SelectParam.Location = new System.Drawing.Point(0, 0);
            this.btn_SelectParam.Name = "btn_SelectParam";
            this.btn_SelectParam.Size = new System.Drawing.Size(1280, 800);
            this.btn_SelectParam.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(186, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 31);
            this.button1.TabIndex = 21;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(1034, 117);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(95, 31);
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.Transparent;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Export.ForeColor = System.Drawing.Color.White;
            this.btn_Export.Location = new System.Drawing.Point(1137, 117);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(95, 31);
            this.btn_Export.TabIndex = 19;
            this.btn_Export.Text = "导出";
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.Color.Transparent;
            this.btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Select.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Select.ForeColor = System.Drawing.Color.White;
            this.btn_Select.Location = new System.Drawing.Point(933, 117);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(95, 31);
            this.btn_Select.TabIndex = 18;
            this.btn_Select.Text = "查询";
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // cmb_Param
            // 
            this.cmb_Param.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Param.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Param.FormattingEnabled = true;
            this.cmb_Param.IntegralHeight = false;
            this.cmb_Param.Location = new System.Drawing.Point(61, 122);
            this.cmb_Param.Name = "cmb_Param";
            this.cmb_Param.Size = new System.Drawing.Size(121, 28);
            this.cmb_Param.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 26);
            this.label4.TabIndex = 16;
            this.label4.Text = "参数:";
            // 
            // date_End
            // 
            this.date_End.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.date_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.date_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_End.Location = new System.Drawing.Point(710, 122);
            this.date_End.Name = "date_End";
            this.date_End.Size = new System.Drawing.Size(200, 26);
            this.date_End.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(594, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "结束时间:";
            // 
            // date_Start
            // 
            this.date_Start.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.date_Start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.date_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_Start.Location = new System.Drawing.Point(371, 122);
            this.date_Start.Name = "date_Start";
            this.date_Start.Size = new System.Drawing.Size(200, 26);
            this.date_Start.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(258, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "开始时间：";
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.Transparent;
            this.panelEx1.BorderColor = System.Drawing.Color.Blue;
            this.panelEx1.BorderWidth = 2;
            this.panelEx1.Controls.Add(this.ChartHistory);
            this.panelEx1.Location = new System.Drawing.Point(42, 155);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1190, 633);
            this.panelEx1.TabIndex = 4;
            // 
            // ChartHistory
            // 
            this.ChartHistory.AxisX.AutoScale = false;
            this.ChartHistory.AxisX.AutoZoomReset = false;
            this.ChartHistory.AxisX.Color = System.Drawing.Color.White;
            this.ChartHistory.AxisX.InitWithScaleView = false;
            this.ChartHistory.AxisX.IsLogarithmic = false;
            this.ChartHistory.AxisX.LabelAngle = 0;
            this.ChartHistory.AxisX.LabelEnabled = true;
            this.ChartHistory.AxisX.LabelFormat = null;
            this.ChartHistory.AxisX.MajorGridColor = System.Drawing.Color.White;
            this.ChartHistory.AxisX.MajorGridCount = 6;
            this.ChartHistory.AxisX.MajorGridEnabled = true;
            this.ChartHistory.AxisX.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.ChartHistory.AxisX.Maximum = 1000D;
            this.ChartHistory.AxisX.Minimum = 0D;
            this.ChartHistory.AxisX.MinorGridColor = System.Drawing.Color.Black;
            this.ChartHistory.AxisX.MinorGridEnabled = false;
            this.ChartHistory.AxisX.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.ChartHistory.AxisX.TickWidth = 1F;
            this.ChartHistory.AxisX.Title = "";
            this.ChartHistory.AxisX.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.ChartHistory.AxisX.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.ChartHistory.AxisX.ViewMaximum = 1000D;
            this.ChartHistory.AxisX.ViewMinimum = 0D;
            this.ChartHistory.AxisX2.AutoScale = false;
            this.ChartHistory.AxisX2.AutoZoomReset = false;
            this.ChartHistory.AxisX2.Color = System.Drawing.Color.Transparent;
            this.ChartHistory.AxisX2.InitWithScaleView = false;
            this.ChartHistory.AxisX2.IsLogarithmic = false;
            this.ChartHistory.AxisX2.LabelAngle = 0;
            this.ChartHistory.AxisX2.LabelEnabled = true;
            this.ChartHistory.AxisX2.LabelFormat = null;
            this.ChartHistory.AxisX2.MajorGridColor = System.Drawing.Color.Transparent;
            this.ChartHistory.AxisX2.MajorGridCount = 6;
            this.ChartHistory.AxisX2.MajorGridEnabled = true;
            this.ChartHistory.AxisX2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.ChartHistory.AxisX2.Maximum = 1000D;
            this.ChartHistory.AxisX2.Minimum = 0D;
            this.ChartHistory.AxisX2.MinorGridColor = System.Drawing.Color.Black;
            this.ChartHistory.AxisX2.MinorGridEnabled = false;
            this.ChartHistory.AxisX2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.ChartHistory.AxisX2.TickWidth = 1F;
            this.ChartHistory.AxisX2.Title = "";
            this.ChartHistory.AxisX2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.ChartHistory.AxisX2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.ChartHistory.AxisX2.ViewMaximum = 1000D;
            this.ChartHistory.AxisX2.ViewMinimum = 0D;
            this.ChartHistory.AxisY.AutoScale = true;
            this.ChartHistory.AxisY.AutoZoomReset = false;
            this.ChartHistory.AxisY.Color = System.Drawing.Color.White;
            this.ChartHistory.AxisY.InitWithScaleView = false;
            this.ChartHistory.AxisY.IsLogarithmic = false;
            this.ChartHistory.AxisY.LabelAngle = 0;
            this.ChartHistory.AxisY.LabelEnabled = true;
            this.ChartHistory.AxisY.LabelFormat = null;
            this.ChartHistory.AxisY.MajorGridColor = System.Drawing.Color.White;
            this.ChartHistory.AxisY.MajorGridCount = 6;
            this.ChartHistory.AxisY.MajorGridEnabled = true;
            this.ChartHistory.AxisY.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.ChartHistory.AxisY.Maximum = 5D;
            this.ChartHistory.AxisY.Minimum = 0D;
            this.ChartHistory.AxisY.MinorGridColor = System.Drawing.Color.Black;
            this.ChartHistory.AxisY.MinorGridEnabled = false;
            this.ChartHistory.AxisY.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.ChartHistory.AxisY.TickWidth = 1F;
            this.ChartHistory.AxisY.Title = "";
            this.ChartHistory.AxisY.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.ChartHistory.AxisY.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.ChartHistory.AxisY.ViewMaximum = 3.5D;
            this.ChartHistory.AxisY.ViewMinimum = 0.5D;
            this.ChartHistory.AxisY2.AutoScale = false;
            this.ChartHistory.AxisY2.AutoZoomReset = false;
            this.ChartHistory.AxisY2.Color = System.Drawing.Color.White;
            this.ChartHistory.AxisY2.InitWithScaleView = false;
            this.ChartHistory.AxisY2.IsLogarithmic = false;
            this.ChartHistory.AxisY2.LabelAngle = 0;
            this.ChartHistory.AxisY2.LabelEnabled = true;
            this.ChartHistory.AxisY2.LabelFormat = null;
            this.ChartHistory.AxisY2.MajorGridColor = System.Drawing.Color.Transparent;
            this.ChartHistory.AxisY2.MajorGridCount = 6;
            this.ChartHistory.AxisY2.MajorGridEnabled = true;
            this.ChartHistory.AxisY2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.ChartHistory.AxisY2.Maximum = 100D;
            this.ChartHistory.AxisY2.Minimum = 0D;
            this.ChartHistory.AxisY2.MinorGridColor = System.Drawing.Color.Black;
            this.ChartHistory.AxisY2.MinorGridEnabled = false;
            this.ChartHistory.AxisY2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.ChartHistory.AxisY2.TickWidth = 1F;
            this.ChartHistory.AxisY2.Title = "";
            this.ChartHistory.AxisY2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.ChartHistory.AxisY2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.ChartHistory.AxisY2.ViewMaximum = 3.5D;
            this.ChartHistory.AxisY2.ViewMinimum = 0.5D;
            this.ChartHistory.BackColor = System.Drawing.Color.Transparent;
            this.ChartHistory.ChartAreaBackColor = System.Drawing.Color.Transparent;
            this.ChartHistory.Direction = SeeSharpTools.JY.GUI.StripChartX.ScrollDirection.RightToLeft;
            this.ChartHistory.DisplayPoints = 4000;
            this.ChartHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartHistory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChartHistory.ForeColor = System.Drawing.Color.White;
            this.ChartHistory.GradientStyle = SeeSharpTools.JY.GUI.StripChartX.ChartGradientStyle.None;
            this.ChartHistory.LegendBackColor = System.Drawing.Color.Transparent;
            this.ChartHistory.LegendFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChartHistory.LegendForeColor = System.Drawing.Color.Black;
            this.ChartHistory.LegendVisible = false;
            stripChartXSeries1.Color = System.Drawing.Color.Red;
            stripChartXSeries1.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries1.Name = "Series1";
            stripChartXSeries1.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries1.Visible = true;
            stripChartXSeries1.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries1.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries1.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries2.Color = System.Drawing.SystemColors.ActiveCaptionText;
            stripChartXSeries2.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries2.Name = "Series2";
            stripChartXSeries2.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries2.Visible = true;
            stripChartXSeries2.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries2.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries2.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Secondary;
            this.ChartHistory.LineSeries.Add(stripChartXSeries1);
            this.ChartHistory.LineSeries.Add(stripChartXSeries2);
            this.ChartHistory.Location = new System.Drawing.Point(0, 0);
            this.ChartHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChartHistory.Miscellaneous.CheckInfinity = false;
            this.ChartHistory.Miscellaneous.CheckNaN = false;
            this.ChartHistory.Miscellaneous.CheckNegtiveOrZero = false;
            this.ChartHistory.Miscellaneous.DirectionChartCount = 3;
            this.ChartHistory.Miscellaneous.Fitting = SeeSharpTools.JY.GUI.StripChartX.FitType.Range;
            this.ChartHistory.Miscellaneous.MaxSeriesCount = 32;
            this.ChartHistory.Miscellaneous.MaxSeriesPointCount = 4000;
            this.ChartHistory.Miscellaneous.SplitLayoutColumnInterval = 0F;
            this.ChartHistory.Miscellaneous.SplitLayoutDirection = SeeSharpTools.JY.GUI.StripChartXUtility.LayoutDirection.LeftToRight;
            this.ChartHistory.Miscellaneous.SplitLayoutRowInterval = 0F;
            this.ChartHistory.Miscellaneous.SplitViewAutoLayout = true;
            this.ChartHistory.Name = "ChartHistory";
            this.ChartHistory.NextTimeStamp = new System.DateTime(((long)(0)));
            this.ChartHistory.ScrollType = SeeSharpTools.JY.GUI.StripChartX.StripScrollType.Cumulation;
            this.ChartHistory.SeriesCount = 2;
            this.ChartHistory.Size = new System.Drawing.Size(1190, 633);
            this.ChartHistory.SplitView = false;
            this.ChartHistory.StartIndex = 0;
            this.ChartHistory.TabIndex = 0;
            this.ChartHistory.TimeInterval = System.TimeSpan.Parse("00:00:00");
            this.ChartHistory.TimeStampFormat = null;
            this.ChartHistory.XCursor.AutoInterval = true;
            this.ChartHistory.XCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.ChartHistory.XCursor.Interval = 0.001D;
            this.ChartHistory.XCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Zoom;
            this.ChartHistory.XCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.ChartHistory.XCursor.Value = double.NaN;
            this.ChartHistory.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.Index;
            this.ChartHistory.YCursor.AutoInterval = true;
            this.ChartHistory.YCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.ChartHistory.YCursor.Interval = 0.001D;
            this.ChartHistory.YCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Disabled;
            this.ChartHistory.YCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.ChartHistory.YCursor.Value = double.NaN;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(37, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "历史趋势";
            // 
            // FrmHistoryTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.btn_SelectParam);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmHistoryTrend";
            this.Text = "历史趋势";
            this.btn_SelectParam.ResumeLayout(false);
            this.btn_SelectParam.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced btn_SelectParam;
        private thinger.ControlLib.PanelEx panelEx1;
        private SeeSharpTools.JY.GUI.StripChartX ChartHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.ComboBox cmb_Param;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button button1;
    }
}