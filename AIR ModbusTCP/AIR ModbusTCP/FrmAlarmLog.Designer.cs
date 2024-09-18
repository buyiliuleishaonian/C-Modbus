namespace AIR_ModbusTCP
{
    partial class FrmAlarmLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEnhanced1 = new thinger.ControlLib.PanelEnhanced();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_AlarmLog = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_OperaeLog = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Log = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AlarmLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OperaeLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::AIR_ModbusTCP.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.label4);
            this.panelEnhanced1.Controls.Add(this.label2);
            this.panelEnhanced1.Controls.Add(this.label1);
            this.panelEnhanced1.Controls.Add(this.dgv_AlarmLog);
            this.panelEnhanced1.Controls.Add(this.dgv_OperaeLog);
            this.panelEnhanced1.Controls.Add(this.dgv_Log);
            this.panelEnhanced1.Controls.Add(this.label3);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1280, 800);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(93, 562);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 22);
            this.label4.TabIndex = 14;
            this.label4.Text = "报警日志";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(93, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "操作日志";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(93, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "系统日志";
            // 
            // dgv_AlarmLog
            // 
            this.dgv_AlarmLog.AllowUserToAddRows = false;
            this.dgv_AlarmLog.AllowUserToResizeColumns = false;
            this.dgv_AlarmLog.AllowUserToResizeRows = false;
            this.dgv_AlarmLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_AlarmLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_AlarmLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_AlarmLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_AlarmLog.ColumnHeadersHeight = 32;
            this.dgv_AlarmLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_AlarmLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgv_AlarmLog.EnableHeadersVisualStyles = false;
            this.dgv_AlarmLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(146)))), ((int)(((byte)(235)))));
            this.dgv_AlarmLog.Location = new System.Drawing.Point(69, 556);
            this.dgv_AlarmLog.Name = "dgv_AlarmLog";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_AlarmLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_AlarmLog.RowHeadersWidth = 120;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_AlarmLog.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_AlarmLog.RowTemplate.Height = 23;
            this.dgv_AlarmLog.Size = new System.Drawing.Size(1143, 226);
            this.dgv_AlarmLog.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "日期时间";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "报警日志";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "报警内容";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv_OperaeLog
            // 
            this.dgv_OperaeLog.AllowUserToAddRows = false;
            this.dgv_OperaeLog.AllowUserToResizeColumns = false;
            this.dgv_OperaeLog.AllowUserToResizeRows = false;
            this.dgv_OperaeLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_OperaeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_OperaeLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_OperaeLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_OperaeLog.ColumnHeadersHeight = 32;
            this.dgv_OperaeLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_OperaeLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgv_OperaeLog.EnableHeadersVisualStyles = false;
            this.dgv_OperaeLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(146)))), ((int)(((byte)(235)))));
            this.dgv_OperaeLog.Location = new System.Drawing.Point(69, 322);
            this.dgv_OperaeLog.Name = "dgv_OperaeLog";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_OperaeLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_OperaeLog.RowHeadersWidth = 120;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(60)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_OperaeLog.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_OperaeLog.RowTemplate.Height = 23;
            this.dgv_OperaeLog.Size = new System.Drawing.Size(1143, 226);
            this.dgv_OperaeLog.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "日期时间";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "操作日志";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "操作内容";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv_Log
            // 
            this.dgv_Log.AllowUserToAddRows = false;
            this.dgv_Log.AllowUserToResizeColumns = false;
            this.dgv_Log.AllowUserToResizeRows = false;
            this.dgv_Log.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Log.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Log.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_Log.ColumnHeadersHeight = 32;
            this.dgv_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgv_Log.EnableHeadersVisualStyles = false;
            this.dgv_Log.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(146)))), ((int)(((byte)(235)))));
            this.dgv_Log.Location = new System.Drawing.Point(69, 88);
            this.dgv_Log.Name = "dgv_Log";
            this.dgv_Log.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Log.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgv_Log.RowHeadersWidth = 120;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Log.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgv_Log.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Log.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_Log.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_Log.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgv_Log.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Log.RowTemplate.Height = 23;
            this.dgv_Log.Size = new System.Drawing.Size(1143, 226);
            this.dgv_Log.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "日期时间";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "日志类型";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "日志内容";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(92, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "日志信息";
            // 
            // FrmAlarmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAlarmLog";
            this.Text = "日志报警";
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEnhanced1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AlarmLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OperaeLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_AlarmLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView dgv_OperaeLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView dgv_Log;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label3;
    }
}