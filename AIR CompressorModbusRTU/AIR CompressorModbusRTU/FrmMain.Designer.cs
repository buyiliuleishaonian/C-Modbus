namespace AIR_CompressorModbusRTU
{
    partial class FraMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FraMain));
            this.NaviPanel = new System.Windows.Forms.Panel();
            this.naviControl1 = new Wen.KYJControlLib.NaviControl();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.led_ConnState = new thinger.ControlLib.SimpleLed();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.SystemSct = new thinger.ControlLib.ScrollText();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NaviPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NaviPanel
            // 
            this.NaviPanel.BackColor = System.Drawing.Color.Transparent;
            this.NaviPanel.Controls.Add(this.naviControl1);
            this.NaviPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NaviPanel.Location = new System.Drawing.Point(0, 900);
            this.NaviPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NaviPanel.Name = "NaviPanel";
            this.NaviPanel.Size = new System.Drawing.Size(1280, 100);
            this.NaviPanel.TabIndex = 1;
            // 
            // naviControl1
            // 
            this.naviControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.naviControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.naviControl1.Location = new System.Drawing.Point(0, 0);
            this.naviControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naviControl1.Name = "naviControl1";
            this.naviControl1.Size = new System.Drawing.Size(1280, 100);
            this.naviControl1.TabIndex = 0;
            this.naviControl1.SelectButtonForm += new System.Func<object, System.EventArgs, bool>(this.naviControl1_SelectButtonForm);
            this.naviControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseDown);
            this.naviControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseMove);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 100);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1280, 800);
            this.MainPanel.TabIndex = 2;
            this.MainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseDown);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseMove);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TopPanel.BackgroundImage")));
            this.TopPanel.Controls.Add(this.led_ConnState);
            this.TopPanel.Controls.Add(this.TitlePanel);
            this.TopPanel.Controls.Add(this.label7);
            this.TopPanel.Controls.Add(this.lbl_UserName);
            this.TopPanel.Controls.Add(this.label5);
            this.TopPanel.Controls.Add(this.label4);
            this.TopPanel.Controls.Add(this.label3);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1280, 100);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseMove);
            // 
            // led_ConnState
            // 
            this.led_ConnState.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("led_ConnState.BackgroundImage")));
            this.led_ConnState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.led_ConnState.BindVarName = null;
            this.led_ConnState.Location = new System.Drawing.Point(1187, 54);
            this.led_ConnState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.led_ConnState.Name = "led_ConnState";
            this.led_ConnState.Size = new System.Drawing.Size(26, 25);
            this.led_ConnState.State = true;
            this.led_ConnState.TabIndex = 10;
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TitlePanel.BackgroundImage")));
            this.TitlePanel.Controls.Add(this.SystemSct);
            this.TitlePanel.Location = new System.Drawing.Point(450, 23);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(428, 43);
            this.TitlePanel.TabIndex = 9;
            // 
            // SystemSct
            // 
            this.SystemSct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SystemSct.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SystemSct.ForeColor = System.Drawing.Color.White;
            this.SystemSct.IsScoll = true;
            this.SystemSct.Location = new System.Drawing.Point(0, 0);
            this.SystemSct.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SystemSct.Name = "SystemSct";
            this.SystemSct.ScrollDirection = thinger.ControlLib.ScrollDirection.RightToLeft;
            this.SystemSct.ScrollDistance = 5;
            this.SystemSct.ScrollInterval = 50;
            this.SystemSct.Size = new System.Drawing.Size(428, 43);
            this.SystemSct.TabIndex = 8;
            this.SystemSct.TextScroll = "系统运行正常";
            this.SystemSct.VerticalAlignment = thinger.ControlLib.TextVerticalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(1086, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "通信状态：";
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_UserName.Location = new System.Drawing.Point(993, 53);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(76, 26);
            this.lbl_UserName.TabIndex = 5;
            this.lbl_UserName.Text = "Admin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(904, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "管理员:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1013, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "2024.6.4 21:36 星期二";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(904, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "系统时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(55, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "AIR COMPRESSOR  SCADA SYSTEM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "空压机监控系统";
            // 
            // FraMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 1000);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.NaviPanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FraMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseMove);
            this.NaviPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.TitlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel NaviPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel TitlePanel;
        private thinger.ControlLib.ScrollText SystemSct;
        private Wen.KYJControlLib.NaviControl naviControl1;
        private thinger.ControlLib.SimpleLed led_ConnState;
    }
}

