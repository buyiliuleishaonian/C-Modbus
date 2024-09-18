namespace AIR_ModbusTCP
{
    partial class FrmReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEnhanced1 = new thinger.ControlLib.PanelEnhanced();
            this.chk_Avg = new System.Windows.Forms.CheckBox();
            this.chk_Min = new System.Windows.Forms.CheckBox();
            this.chk_Max = new System.Windows.Forms.CheckBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.cmb_Param = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_Start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_ParamData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ParamData)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::AIR_ModbusTCP.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.chk_Avg);
            this.panelEnhanced1.Controls.Add(this.chk_Min);
            this.panelEnhanced1.Controls.Add(this.chk_Max);
            this.panelEnhanced1.Controls.Add(this.btn_Select);
            this.panelEnhanced1.Controls.Add(this.cmb_Param);
            this.panelEnhanced1.Controls.Add(this.label4);
            this.panelEnhanced1.Controls.Add(this.date_Start);
            this.panelEnhanced1.Controls.Add(this.label1);
            this.panelEnhanced1.Controls.Add(this.dgv_ParamData);
            this.panelEnhanced1.Controls.Add(this.label3);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1280, 800);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // chk_Avg
            // 
            this.chk_Avg.AutoSize = true;
            this.chk_Avg.BackColor = System.Drawing.Color.Transparent;
            this.chk_Avg.Checked = true;
            this.chk_Avg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Avg.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_Avg.ForeColor = System.Drawing.Color.White;
            this.chk_Avg.Location = new System.Drawing.Point(820, 103);
            this.chk_Avg.Name = "chk_Avg";
            this.chk_Avg.Size = new System.Drawing.Size(88, 30);
            this.chk_Avg.TabIndex = 40;
            this.chk_Avg.Text = "平均值";
            this.chk_Avg.UseVisualStyleBackColor = false;
            // 
            // chk_Min
            // 
            this.chk_Min.AutoSize = true;
            this.chk_Min.BackColor = System.Drawing.Color.Transparent;
            this.chk_Min.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_Min.ForeColor = System.Drawing.Color.White;
            this.chk_Min.Location = new System.Drawing.Point(692, 103);
            this.chk_Min.Name = "chk_Min";
            this.chk_Min.Size = new System.Drawing.Size(88, 30);
            this.chk_Min.TabIndex = 39;
            this.chk_Min.Text = "最小值";
            this.chk_Min.UseVisualStyleBackColor = false;
            // 
            // chk_Max
            // 
            this.chk_Max.AutoSize = true;
            this.chk_Max.BackColor = System.Drawing.Color.Transparent;
            this.chk_Max.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_Max.ForeColor = System.Drawing.Color.White;
            this.chk_Max.Location = new System.Drawing.Point(564, 103);
            this.chk_Max.Name = "chk_Max";
            this.chk_Max.Size = new System.Drawing.Size(88, 30);
            this.chk_Max.TabIndex = 38;
            this.chk_Max.Text = "最大值";
            this.chk_Max.UseVisualStyleBackColor = false;
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.Color.Transparent;
            this.btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Select.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Select.ForeColor = System.Drawing.Color.White;
            this.btn_Select.Location = new System.Drawing.Point(926, 100);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(95, 31);
            this.btn_Select.TabIndex = 37;
            this.btn_Select.Text = "查询";
            this.btn_Select.UseVisualStyleBackColor = false;
            // 
            // cmb_Param
            // 
            this.cmb_Param.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Param.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Param.FormattingEnabled = true;
            this.cmb_Param.IntegralHeight = false;
            this.cmb_Param.Location = new System.Drawing.Point(107, 105);
            this.cmb_Param.Name = "cmb_Param";
            this.cmb_Param.Size = new System.Drawing.Size(121, 28);
            this.cmb_Param.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 26);
            this.label4.TabIndex = 35;
            this.label4.Text = "报表类型";
            // 
            // date_Start
            // 
            this.date_Start.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.date_Start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.date_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_Start.Location = new System.Drawing.Point(347, 105);
            this.date_Start.Name = "date_Start";
            this.date_Start.Size = new System.Drawing.Size(200, 26);
            this.date_Start.TabIndex = 34;
            this.date_Start.Value = new System.DateTime(2024, 8, 2, 20, 43, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(234, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 33;
            this.label1.Text = "日期时间：";
            // 
            // dgv_ParamData
            // 
            this.dgv_ParamData.AllowUserToAddRows = false;
            this.dgv_ParamData.AllowUserToResizeColumns = false;
            this.dgv_ParamData.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_ParamData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_ParamData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_ParamData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ParamData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgv_ParamData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ParamData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_ParamData.ColumnHeadersHeight = 40;
            this.dgv_ParamData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ParamData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column6,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column3,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dgv_ParamData.EnableHeadersVisualStyles = false;
            this.dgv_ParamData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(146)))), ((int)(((byte)(235)))));
            this.dgv_ParamData.Location = new System.Drawing.Point(23, 139);
            this.dgv_ParamData.Name = "dgv_ParamData";
            this.dgv_ParamData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ParamData.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_ParamData.RowHeadersWidth = 120;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_ParamData.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_ParamData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_ParamData.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_ParamData.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_ParamData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgv_ParamData.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_ParamData.RowTemplate.Height = 23;
            this.dgv_ParamData.Size = new System.Drawing.Size(1236, 644);
            this.dgv_ParamData.TabIndex = 32;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "insertTime";
            this.Column1.HeaderText = "日期时间";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LQT_Level";
            this.Column2.HeaderText = "冷却塔液位";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "LQT_InPre";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column4.HeaderText = "冷却塔进口压力";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 125;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "LQT_InTemp";
            this.Column6.HeaderText = "冷却塔进口温度";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "LQT_OutPre";
            this.Column5.HeaderText = "冷却塔出口压力";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 125;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "LQT_OutTemp";
            this.Column7.HeaderText = "冷却塔出口温度";
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "LQT_RTNTemp";
            this.Column8.HeaderText = "冷却塔回水温度";
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 125;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "LQB1_OutTemp";
            this.Column9.HeaderText = "冷却泵1#出口压力";
            this.Column9.Name = "Column9";
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LQB_OutPre";
            this.Column3.HeaderText = "冷却泵2#出口压力";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 150;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "KYJ1_OutTemp";
            this.Column10.HeaderText = "空压机#1出口温度";
            this.Column10.Name = "Column10";
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 150;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "KYJ2_OutTemp";
            this.Column11.HeaderText = "空压机#2出口温度";
            this.Column11.Name = "Column11";
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Width = 150;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "KYJ3_OutTemp";
            this.Column12.HeaderText = "空压机#3出口温度";
            this.Column12.Name = "Column12";
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column12.Width = 150;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "KYJ4_OutTemp";
            this.Column13.HeaderText = "空压机4#出口温度";
            this.Column13.Name = "Column13";
            this.Column13.Width = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 31;
            this.label3.Text = "数据管理";
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmReport";
            this.Text = "数据报表";
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEnhanced1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ParamData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.CheckBox chk_Avg;
        private System.Windows.Forms.CheckBox chk_Min;
        private System.Windows.Forms.CheckBox chk_Max;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.ComboBox cmb_Param;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_ParamData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.Label label3;
    }
}