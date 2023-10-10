namespace Wen.ModbusProject
{
    partial class FrmTHMonitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTHMonitor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.lblPortName = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.list_Info = new System.Windows.Forms.ListView();
            this.clmDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblHum1 = new System.Windows.Forms.Label();
            this.lblTem1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTem2 = new System.Windows.Forms.Label();
            this.lblHum2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTem3 = new System.Windows.Forms.Label();
            this.lblHum3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblTem4 = new System.Windows.Forms.Label();
            this.lblHum4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisConnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cmbBaudRate);
            this.groupBox1.Controls.Add(this.lblBaudRate);
            this.groupBox1.Controls.Add(this.cmbPortName);
            this.groupBox1.Controls.Add(this.lblPortName);
            this.groupBox1.Location = new System.Drawing.Point(32, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(971, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通信参数";
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.BackColor = System.Drawing.Color.Transparent;
            this.btnDisConnect.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDisConnect.Location = new System.Drawing.Point(695, 40);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(120, 30);
            this.btnDisConnect.TabIndex = 14;
            this.btnDisConnect.Text = "断开";
            this.btnDisConnect.UseVisualStyleBackColor = false;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Location = new System.Drawing.Point(506, 40);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 30);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(333, 41);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(104, 27);
            this.cmbBaudRate.TabIndex = 4;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBaudRate.Location = new System.Drawing.Point(241, 42);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(66, 19);
            this.lblBaudRate.TabIndex = 3;
            this.lblBaudRate.Text = "波特率";
            // 
            // cmbPortName
            // 
            this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(113, 40);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(104, 27);
            this.cmbPortName.TabIndex = 2;
            // 
            // lblPortName
            // 
            this.lblPortName.AutoSize = true;
            this.lblPortName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPortName.Location = new System.Drawing.Point(21, 41);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(66, 19);
            this.lblPortName.TabIndex = 1;
            this.lblPortName.Text = "端口号";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "info.ico");
            this.imageList1.Images.SetKeyName(1, "warning.ico");
            this.imageList1.Images.SetKeyName(2, "error.ico");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(53, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "系统日志";
            // 
            // list_Info
            // 
            this.list_Info.BackColor = System.Drawing.SystemColors.Control;
            this.list_Info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDateTime,
            this.clmData});
            this.list_Info.HideSelection = false;
            this.list_Info.Location = new System.Drawing.Point(57, 457);
            this.list_Info.MultiSelect = false;
            this.list_Info.Name = "list_Info";
            this.list_Info.ShowItemToolTips = true;
            this.list_Info.Size = new System.Drawing.Size(739, 210);
            this.list_Info.SmallImageList = this.imageList1;
            this.list_Info.TabIndex = 27;
            this.list_Info.UseCompatibleStateImageBehavior = false;
            this.list_Info.View = System.Windows.Forms.View.Details;
            // 
            // clmDateTime
            // 
            this.clmDateTime.Text = "日期";
            this.clmDateTime.Width = 200;
            // 
            // clmData
            // 
            this.clmData.Text = "信息";
            this.clmData.Width = 400;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTem1);
            this.groupBox2.Controls.Add(this.lblHum1);
            this.groupBox2.Controls.Add(this.lbl2);
            this.groupBox2.Controls.Add(this.lbl1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(32, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 157);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "温湿读模块1";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1.Location = new System.Drawing.Point(21, 52);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(85, 19);
            this.lbl1.TabIndex = 15;
            this.lbl1.Text = "湿度值：";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2.Location = new System.Drawing.Point(21, 100);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(85, 19);
            this.lbl2.TabIndex = 16;
            this.lbl2.Text = "湿度值：";
            // 
            // lblHum1
            // 
            this.lblHum1.AutoSize = true;
            this.lblHum1.BackColor = System.Drawing.Color.Lime;
            this.lblHum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHum1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHum1.Location = new System.Drawing.Point(112, 52);
            this.lblHum1.Name = "lblHum1";
            this.lblHum1.Size = new System.Drawing.Size(41, 21);
            this.lblHum1.TabIndex = 17;
            this.lblHum1.Text = "0.0";
            this.lblHum1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTem1
            // 
            this.lblTem1.AutoSize = true;
            this.lblTem1.BackColor = System.Drawing.Color.Lime;
            this.lblTem1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTem1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTem1.Location = new System.Drawing.Point(112, 100);
            this.lblTem1.Name = "lblTem1";
            this.lblTem1.Size = new System.Drawing.Size(41, 21);
            this.lblTem1.TabIndex = 18;
            this.lblTem1.Text = "0.0";
            this.lblTem1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTem2);
            this.groupBox3.Controls.Add(this.lblHum2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(285, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 157);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "温湿读模块2";
            // 
            // lblTem2
            // 
            this.lblTem2.AutoSize = true;
            this.lblTem2.BackColor = System.Drawing.Color.Lime;
            this.lblTem2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTem2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTem2.Location = new System.Drawing.Point(112, 100);
            this.lblTem2.Name = "lblTem2";
            this.lblTem2.Size = new System.Drawing.Size(41, 21);
            this.lblTem2.TabIndex = 18;
            this.lblTem2.Text = "0.0";
            this.lblTem2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHum2
            // 
            this.lblHum2.AutoSize = true;
            this.lblHum2.BackColor = System.Drawing.Color.Lime;
            this.lblHum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHum2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHum2.Location = new System.Drawing.Point(112, 52);
            this.lblHum2.Name = "lblHum2";
            this.lblHum2.Size = new System.Drawing.Size(41, 21);
            this.lblHum2.TabIndex = 17;
            this.lblHum2.Text = "0.0";
            this.lblHum2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(21, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "湿度值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(21, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "湿度值：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTem3);
            this.groupBox4.Controls.Add(this.lblHum3);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(538, 219);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(220, 157);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "温湿读模块3";
            // 
            // lblTem3
            // 
            this.lblTem3.AutoSize = true;
            this.lblTem3.BackColor = System.Drawing.Color.Lime;
            this.lblTem3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTem3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTem3.Location = new System.Drawing.Point(112, 100);
            this.lblTem3.Name = "lblTem3";
            this.lblTem3.Size = new System.Drawing.Size(41, 21);
            this.lblTem3.TabIndex = 18;
            this.lblTem3.Text = "0.0";
            this.lblTem3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHum3
            // 
            this.lblHum3.AutoSize = true;
            this.lblHum3.BackColor = System.Drawing.Color.Lime;
            this.lblHum3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHum3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHum3.Location = new System.Drawing.Point(112, 52);
            this.lblHum3.Name = "lblHum3";
            this.lblHum3.Size = new System.Drawing.Size(41, 21);
            this.lblHum3.TabIndex = 17;
            this.lblHum3.Text = "0.0";
            this.lblHum3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(21, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 16;
            this.label8.Text = "湿度值：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(21, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "湿度值：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblTem4);
            this.groupBox5.Controls.Add(this.lblHum4);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(791, 219);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(220, 157);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "温湿读模块4";
            // 
            // lblTem4
            // 
            this.lblTem4.AutoSize = true;
            this.lblTem4.BackColor = System.Drawing.Color.Lime;
            this.lblTem4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTem4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTem4.Location = new System.Drawing.Point(112, 100);
            this.lblTem4.Name = "lblTem4";
            this.lblTem4.Size = new System.Drawing.Size(41, 21);
            this.lblTem4.TabIndex = 18;
            this.lblTem4.Text = "0.0";
            this.lblTem4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHum4
            // 
            this.lblHum4.AutoSize = true;
            this.lblHum4.BackColor = System.Drawing.Color.Lime;
            this.lblHum4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHum4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHum4.Location = new System.Drawing.Point(112, 52);
            this.lblHum4.Name = "lblHum4";
            this.lblHum4.Size = new System.Drawing.Size(41, 21);
            this.lblHum4.TabIndex = 17;
            this.lblHum4.Text = "0.0";
            this.lblHum4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(21, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 19);
            this.label12.TabIndex = 16;
            this.label12.Text = "湿度值：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(21, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 19);
            this.label13.TabIndex = 15;
            this.label13.Text = "湿度值：";
            // 
            // FrmTHMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 700);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.list_Info);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmTHMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModbusRTU通信平台【文憔悴】";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTHMonitor_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView list_Info;
        private System.Windows.Forms.ColumnHeader clmDateTime;
        private System.Windows.Forms.ColumnHeader clmData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblHum1;
        private System.Windows.Forms.Label lblTem1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTem2;
        private System.Windows.Forms.Label lblHum2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTem3;
        private System.Windows.Forms.Label lblHum3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblTem4;
        private System.Windows.Forms.Label lblHum4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

