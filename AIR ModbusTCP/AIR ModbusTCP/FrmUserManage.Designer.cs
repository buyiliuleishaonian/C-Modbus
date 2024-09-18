namespace AIR_ModbusTCP
{
    partial class FrmUserManage
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
            this.panelEnhanced1 = new thinger.ControlLib.PanelEnhanced();
            this.dgv_SystemAdmin = new System.Windows.Forms.DataGridView();
            this.LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogAlarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Report = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserManage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grb_UserMenage = new System.Windows.Forms.GroupBox();
            this.chk_UserManage = new System.Windows.Forms.CheckBox();
            this.btn_Empty = new System.Windows.Forms.Button();
            this.btn_UpdateUser = new System.Windows.Forms.Button();
            this.btn_DeleteUser = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.btn_QueryOrNoQuery = new System.Windows.Forms.Button();
            this.chk_Report = new System.Windows.Forms.CheckBox();
            this.chk_ParamSet = new System.Windows.Forms.CheckBox();
            this.chk_HistoryThrend = new System.Windows.Forms.CheckBox();
            this.chk_ActualThrend = new System.Windows.Forms.CheckBox();
            this.chk_HistoryLog = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_Log = new System.Windows.Forms.CheckBox();
            this.txt_AgainPwd = new System.Windows.Forms.TextBox();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SystemAdmin)).BeginInit();
            this.grb_UserMenage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::AIR_ModbusTCP.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.dgv_SystemAdmin);
            this.panelEnhanced1.Controls.Add(this.grb_UserMenage);
            this.panelEnhanced1.Controls.Add(this.lbl_Title);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(1200, 800);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // dgv_SystemAdmin
            // 
            this.dgv_SystemAdmin.AllowUserToAddRows = false;
            this.dgv_SystemAdmin.AllowUserToDeleteRows = false;
            this.dgv_SystemAdmin.AllowUserToResizeColumns = false;
            this.dgv_SystemAdmin.AllowUserToResizeRows = false;
            this.dgv_SystemAdmin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_SystemAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_SystemAdmin.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgv_SystemAdmin.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SystemAdmin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_SystemAdmin.ColumnHeadersHeight = 36;
            this.dgv_SystemAdmin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginName,
            this.LoginPwd,
            this.LogAlarm,
            this.HistoryLog,
            this.ActualTrend,
            this.HistoryTrend,
            this.ParamSet,
            this.Report,
            this.UserManage,
            this.LoginID});
            this.dgv_SystemAdmin.EnableHeadersVisualStyles = false;
            this.dgv_SystemAdmin.GridColor = System.Drawing.SystemColors.Highlight;
            this.dgv_SystemAdmin.Location = new System.Drawing.Point(367, 120);
            this.dgv_SystemAdmin.Name = "dgv_SystemAdmin";
            this.dgv_SystemAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_SystemAdmin.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SystemAdmin.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_SystemAdmin.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_SystemAdmin.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_SystemAdmin.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_SystemAdmin.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_SystemAdmin.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgv_SystemAdmin.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_SystemAdmin.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SystemAdmin.RowTemplate.Height = 23;
            this.dgv_SystemAdmin.Size = new System.Drawing.Size(829, 639);
            this.dgv_SystemAdmin.TabIndex = 6;
            // 
            // LoginName
            // 
            this.LoginName.DataPropertyName = "LoginName";
            this.LoginName.HeaderText = "用户名";
            this.LoginName.Name = "LoginName";
            this.LoginName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LoginPwd
            // 
            this.LoginPwd.DataPropertyName = "LoginPwd";
            this.LoginPwd.HeaderText = "密码";
            this.LoginPwd.Name = "LoginPwd";
            this.LoginPwd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoginPwd.Width = 125;
            // 
            // LogAlarm
            // 
            this.LogAlarm.DataPropertyName = "LogAlarm";
            this.LogAlarm.HeaderText = "日志系统";
            this.LogAlarm.Name = "LogAlarm";
            this.LogAlarm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LogAlarm.Width = 80;
            // 
            // HistoryLog
            // 
            this.HistoryLog.DataPropertyName = "HistoryLog";
            this.HistoryLog.HeaderText = "历史日志";
            this.HistoryLog.Name = "HistoryLog";
            this.HistoryLog.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HistoryLog.Width = 80;
            // 
            // ActualTrend
            // 
            this.ActualTrend.DataPropertyName = "ActualTrend";
            this.ActualTrend.HeaderText = "实时数据";
            this.ActualTrend.Name = "ActualTrend";
            this.ActualTrend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ActualTrend.Width = 80;
            // 
            // HistoryTrend
            // 
            this.HistoryTrend.DataPropertyName = "HistoryTrend";
            this.HistoryTrend.HeaderText = "历史数据";
            this.HistoryTrend.Name = "HistoryTrend";
            this.HistoryTrend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HistoryTrend.Width = 80;
            // 
            // ParamSet
            // 
            this.ParamSet.DataPropertyName = "ParamSet";
            this.ParamSet.HeaderText = "参数设置";
            this.ParamSet.Name = "ParamSet";
            this.ParamSet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ParamSet.Width = 80;
            // 
            // Report
            // 
            this.Report.DataPropertyName = "Report";
            this.Report.HeaderText = "数据查询";
            this.Report.Name = "Report";
            this.Report.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Report.Width = 80;
            // 
            // UserManage
            // 
            this.UserManage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserManage.DataPropertyName = "UserManage";
            this.UserManage.HeaderText = "用户管理";
            this.UserManage.Name = "UserManage";
            // 
            // LoginID
            // 
            this.LoginID.DataPropertyName = "LoginID";
            this.LoginID.HeaderText = "序号";
            this.LoginID.Name = "LoginID";
            this.LoginID.Visible = false;
            // 
            // grb_UserMenage
            // 
            this.grb_UserMenage.BackColor = System.Drawing.Color.Transparent;
            this.grb_UserMenage.Controls.Add(this.chk_UserManage);
            this.grb_UserMenage.Controls.Add(this.btn_Empty);
            this.grb_UserMenage.Controls.Add(this.btn_UpdateUser);
            this.grb_UserMenage.Controls.Add(this.btn_DeleteUser);
            this.grb_UserMenage.Controls.Add(this.btn_AddUser);
            this.grb_UserMenage.Controls.Add(this.btn_QueryOrNoQuery);
            this.grb_UserMenage.Controls.Add(this.chk_Report);
            this.grb_UserMenage.Controls.Add(this.chk_ParamSet);
            this.grb_UserMenage.Controls.Add(this.chk_HistoryThrend);
            this.grb_UserMenage.Controls.Add(this.chk_ActualThrend);
            this.grb_UserMenage.Controls.Add(this.chk_HistoryLog);
            this.grb_UserMenage.Controls.Add(this.label4);
            this.grb_UserMenage.Controls.Add(this.chk_Log);
            this.grb_UserMenage.Controls.Add(this.txt_AgainPwd);
            this.grb_UserMenage.Controls.Add(this.txt_Pwd);
            this.grb_UserMenage.Controls.Add(this.txt_UserName);
            this.grb_UserMenage.Controls.Add(this.label3);
            this.grb_UserMenage.Controls.Add(this.label2);
            this.grb_UserMenage.Controls.Add(this.label1);
            this.grb_UserMenage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grb_UserMenage.ForeColor = System.Drawing.Color.White;
            this.grb_UserMenage.Location = new System.Drawing.Point(9, 120);
            this.grb_UserMenage.Name = "grb_UserMenage";
            this.grb_UserMenage.Size = new System.Drawing.Size(311, 644);
            this.grb_UserMenage.TabIndex = 5;
            this.grb_UserMenage.TabStop = false;
            this.grb_UserMenage.Text = "用户信息";
            // 
            // chk_UserManage
            // 
            this.chk_UserManage.AutoSize = true;
            this.chk_UserManage.Location = new System.Drawing.Point(27, 396);
            this.chk_UserManage.Name = "chk_UserManage";
            this.chk_UserManage.Size = new System.Drawing.Size(93, 26);
            this.chk_UserManage.TabIndex = 20;
            this.chk_UserManage.Text = "用户管理";
            this.chk_UserManage.UseVisualStyleBackColor = true;
            // 
            // btn_Empty
            // 
            this.btn_Empty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Empty.ForeColor = System.Drawing.Color.White;
            this.btn_Empty.Location = new System.Drawing.Point(146, 540);
            this.btn_Empty.Name = "btn_Empty";
            this.btn_Empty.Size = new System.Drawing.Size(94, 31);
            this.btn_Empty.TabIndex = 19;
            this.btn_Empty.Text = "清空信息";
            this.btn_Empty.UseVisualStyleBackColor = true;
            // 
            // btn_UpdateUser
            // 
            this.btn_UpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UpdateUser.ForeColor = System.Drawing.Color.White;
            this.btn_UpdateUser.Location = new System.Drawing.Point(19, 540);
            this.btn_UpdateUser.Name = "btn_UpdateUser";
            this.btn_UpdateUser.Size = new System.Drawing.Size(94, 31);
            this.btn_UpdateUser.TabIndex = 18;
            this.btn_UpdateUser.Text = "修改用户";
            this.btn_UpdateUser.UseVisualStyleBackColor = true;
            // 
            // btn_DeleteUser
            // 
            this.btn_DeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteUser.ForeColor = System.Drawing.Color.White;
            this.btn_DeleteUser.Location = new System.Drawing.Point(146, 474);
            this.btn_DeleteUser.Name = "btn_DeleteUser";
            this.btn_DeleteUser.Size = new System.Drawing.Size(94, 31);
            this.btn_DeleteUser.TabIndex = 17;
            this.btn_DeleteUser.Text = "删除用户";
            this.btn_DeleteUser.UseVisualStyleBackColor = true;
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddUser.ForeColor = System.Drawing.Color.White;
            this.btn_AddUser.Location = new System.Drawing.Point(19, 474);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(94, 31);
            this.btn_AddUser.TabIndex = 16;
            this.btn_AddUser.Text = "添加用户";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            // 
            // btn_QueryOrNoQuery
            // 
            this.btn_QueryOrNoQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QueryOrNoQuery.ForeColor = System.Drawing.Color.White;
            this.btn_QueryOrNoQuery.Location = new System.Drawing.Point(146, 391);
            this.btn_QueryOrNoQuery.Name = "btn_QueryOrNoQuery";
            this.btn_QueryOrNoQuery.Size = new System.Drawing.Size(94, 31);
            this.btn_QueryOrNoQuery.TabIndex = 15;
            this.btn_QueryOrNoQuery.Text = "全权/不选";
            this.btn_QueryOrNoQuery.UseVisualStyleBackColor = true;
            // 
            // chk_Report
            // 
            this.chk_Report.AutoSize = true;
            this.chk_Report.Location = new System.Drawing.Point(146, 349);
            this.chk_Report.Name = "chk_Report";
            this.chk_Report.Size = new System.Drawing.Size(93, 26);
            this.chk_Report.TabIndex = 14;
            this.chk_Report.Text = "数据查询";
            this.chk_Report.UseVisualStyleBackColor = true;
            // 
            // chk_ParamSet
            // 
            this.chk_ParamSet.AutoSize = true;
            this.chk_ParamSet.Location = new System.Drawing.Point(27, 349);
            this.chk_ParamSet.Name = "chk_ParamSet";
            this.chk_ParamSet.Size = new System.Drawing.Size(93, 26);
            this.chk_ParamSet.TabIndex = 13;
            this.chk_ParamSet.Text = "参数设置";
            this.chk_ParamSet.UseVisualStyleBackColor = true;
            // 
            // chk_HistoryThrend
            // 
            this.chk_HistoryThrend.AutoSize = true;
            this.chk_HistoryThrend.Location = new System.Drawing.Point(146, 291);
            this.chk_HistoryThrend.Name = "chk_HistoryThrend";
            this.chk_HistoryThrend.Size = new System.Drawing.Size(93, 26);
            this.chk_HistoryThrend.TabIndex = 12;
            this.chk_HistoryThrend.Text = "历史数据";
            this.chk_HistoryThrend.UseVisualStyleBackColor = true;
            // 
            // chk_ActualThrend
            // 
            this.chk_ActualThrend.AutoSize = true;
            this.chk_ActualThrend.Location = new System.Drawing.Point(27, 291);
            this.chk_ActualThrend.Name = "chk_ActualThrend";
            this.chk_ActualThrend.Size = new System.Drawing.Size(93, 26);
            this.chk_ActualThrend.TabIndex = 11;
            this.chk_ActualThrend.Text = "实时数据";
            this.chk_ActualThrend.UseVisualStyleBackColor = true;
            // 
            // chk_HistoryLog
            // 
            this.chk_HistoryLog.AutoSize = true;
            this.chk_HistoryLog.Location = new System.Drawing.Point(146, 233);
            this.chk_HistoryLog.Name = "chk_HistoryLog";
            this.chk_HistoryLog.Size = new System.Drawing.Size(93, 26);
            this.chk_HistoryLog.TabIndex = 10;
            this.chk_HistoryLog.Text = "历史日志";
            this.chk_HistoryLog.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "权限选择:";
            // 
            // chk_Log
            // 
            this.chk_Log.AutoSize = true;
            this.chk_Log.Location = new System.Drawing.Point(27, 233);
            this.chk_Log.Name = "chk_Log";
            this.chk_Log.Size = new System.Drawing.Size(93, 26);
            this.chk_Log.TabIndex = 4;
            this.chk_Log.Text = "日志系统";
            this.chk_Log.UseVisualStyleBackColor = true;
            // 
            // txt_AgainPwd
            // 
            this.txt_AgainPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.txt_AgainPwd.ForeColor = System.Drawing.Color.White;
            this.txt_AgainPwd.Location = new System.Drawing.Point(117, 114);
            this.txt_AgainPwd.Name = "txt_AgainPwd";
            this.txt_AgainPwd.PasswordChar = '*';
            this.txt_AgainPwd.Size = new System.Drawing.Size(162, 29);
            this.txt_AgainPwd.TabIndex = 8;
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.txt_Pwd.ForeColor = System.Drawing.Color.White;
            this.txt_Pwd.Location = new System.Drawing.Point(117, 72);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '*';
            this.txt_Pwd.Size = new System.Drawing.Size(162, 29);
            this.txt_Pwd.TabIndex = 7;
            // 
            // txt_UserName
            // 
            this.txt_UserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.txt_UserName.ForeColor = System.Drawing.Color.White;
            this.txt_UserName.Location = new System.Drawing.Point(117, 28);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(162, 29);
            this.txt_UserName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "确认密码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "用户密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "用户名称:";
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(4, 37);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(102, 28);
            this.lbl_Title.TabIndex = 4;
            this.lbl_Title.Text = "用户管理";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmUserManage";
            this.Text = "用户管理";
            this.panelEnhanced1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SystemAdmin)).EndInit();
            this.grb_UserMenage.ResumeLayout(false);
            this.grb_UserMenage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.DataGridView dgv_SystemAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualTrend;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryTrend;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Report;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserManage;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginID;
        private System.Windows.Forms.GroupBox grb_UserMenage;
        private System.Windows.Forms.CheckBox chk_UserManage;
        private System.Windows.Forms.Button btn_Empty;
        private System.Windows.Forms.Button btn_UpdateUser;
        private System.Windows.Forms.Button btn_DeleteUser;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Button btn_QueryOrNoQuery;
        private System.Windows.Forms.CheckBox chk_Report;
        private System.Windows.Forms.CheckBox chk_ParamSet;
        private System.Windows.Forms.CheckBox chk_HistoryThrend;
        private System.Windows.Forms.CheckBox chk_ActualThrend;
        private System.Windows.Forms.CheckBox chk_HistoryLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_Log;
        private System.Windows.Forms.TextBox txt_AgainPwd;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Title;
    }
}