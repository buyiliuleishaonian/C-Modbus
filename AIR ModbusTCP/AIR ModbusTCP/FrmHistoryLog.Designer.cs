namespace AIR_ModbusTCP
{
    partial class FrmHistoryLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEnhanced1 = new thinger.ControlLib.PanelEnhanced();
            this.dgv_Log = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.cmb_LogType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_End = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.date_Start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::AIR_ModbusTCP.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.dgv_Log);
            this.panelEnhanced1.Controls.Add(this.btn_Save);
            this.panelEnhanced1.Controls.Add(this.btn_Select);
            this.panelEnhanced1.Controls.Add(this.cmb_LogType);
            this.panelEnhanced1.Controls.Add(this.label4);
            this.panelEnhanced1.Controls.Add(this.date_End);
            this.panelEnhanced1.Controls.Add(this.label2);
            this.panelEnhanced1.Controls.Add(this.date_Start);
            this.panelEnhanced1.Controls.Add(this.label1);
            this.panelEnhanced1.Controls.Add(this.label3);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1280, 800);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // dgv_Log
            // 
            this.dgv_Log.AllowUserToAddRows = false;
            this.dgv_Log.AllowUserToResizeColumns = false;
            this.dgv_Log.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Log.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Log.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Log.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Log.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Log.ColumnHeadersHeight = 32;
            this.dgv_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column6,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgv_Log.EnableHeadersVisualStyles = false;
            this.dgv_Log.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(146)))), ((int)(((byte)(235)))));
            this.dgv_Log.Location = new System.Drawing.Point(41, 118);
            this.dgv_Log.Name = "dgv_Log";
            this.dgv_Log.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Log.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Log.RowHeadersWidth = 120;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Log.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Log.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Log.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_Log.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_Log.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgv_Log.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Log.RowTemplate.Height = 23;
            this.dgv_Log.Size = new System.Drawing.Size(1181, 644);
            this.dgv_Log.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "inserttime";
            this.Column1.HeaderText = "日期时间";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LogType";
            this.Column2.HeaderText = "日志类型";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "AlarmType";
            this.Column4.HeaderText = "报警类型";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Note";
            this.Column6.HeaderText = "日志报警信息";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 250;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "operador";
            this.Column5.HeaderText = "操作对象";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "varname";
            this.Column7.HeaderText = "变量名称";
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "alarmSet";
            this.Column8.HeaderText = "报警设定";
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.DataPropertyName = "alarmValue";
            this.Column9.HeaderText = "报警值";
            this.Column9.Name = "Column9";
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(1062, 58);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(95, 31);
            this.btn_Save.TabIndex = 21;
            this.btn_Save.Text = "导出";
            this.btn_Save.UseVisualStyleBackColor = false;
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.Color.Transparent;
            this.btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Select.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Select.ForeColor = System.Drawing.Color.White;
            this.btn_Select.Location = new System.Drawing.Point(951, 58);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(95, 31);
            this.btn_Select.TabIndex = 20;
            this.btn_Select.Text = "查询";
            this.btn_Select.UseVisualStyleBackColor = false;
            // 
            // cmb_LogType
            // 
            this.cmb_LogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_LogType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_LogType.FormattingEnabled = true;
            this.cmb_LogType.IntegralHeight = false;
            this.cmb_LogType.Location = new System.Drawing.Point(805, 60);
            this.cmb_LogType.Name = "cmb_LogType";
            this.cmb_LogType.Size = new System.Drawing.Size(121, 28);
            this.cmb_LogType.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(706, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "日志类型:";
            // 
            // date_End
            // 
            this.date_End.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.date_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.date_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_End.Location = new System.Drawing.Point(484, 62);
            this.date_End.Name = "date_End";
            this.date_End.Size = new System.Drawing.Size(200, 26);
            this.date_End.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(382, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 26);
            this.label2.TabIndex = 16;
            this.label2.Text = "结束时间:";
            // 
            // date_Start
            // 
            this.date_Start.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.date_Start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.date_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_Start.Location = new System.Drawing.Point(156, 62);
            this.date_Start.Name = "date_Start";
            this.date_Start.Size = new System.Drawing.Size(200, 26);
            this.date_Start.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(54, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "开始时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "日志查询";
            // 
            // FrmHistoryLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmHistoryLog";
            this.Text = "日志查询";
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEnhanced1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.DataGridView dgv_Log;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.ComboBox cmb_LogType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}