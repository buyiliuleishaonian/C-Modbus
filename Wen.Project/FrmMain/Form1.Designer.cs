namespace FrmMain
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblWen = new System.Windows.Forms.Label();
            this.lblShi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudSlaveID = new System.Windows.Forms.NumericUpDown();
            this.btnCommit = new System.Windows.Forms.Button();
            this.cboBudRate = new System.Windows.Forms.ComboBox();
            this.cboPortName = new System.Windows.Forms.ComboBox();
            this.lblDizhi = new System.Windows.Forms.Label();
            this.lblBit = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.timer_Read = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Timers.Timer();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblRegister = new System.Windows.Forms.Label();
            this.txtRegister = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegisterNumbers = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlaveID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWen
            // 
            this.lblWen.AutoSize = true;
            this.lblWen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWen.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWen.Location = new System.Drawing.Point(53, 63);
            this.lblWen.Name = "lblWen";
            this.lblWen.Size = new System.Drawing.Size(78, 23);
            this.lblWen.TabIndex = 0;
            this.lblWen.Text = "label1";
            // 
            // lblShi
            // 
            this.lblShi.AutoSize = true;
            this.lblShi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShi.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShi.Location = new System.Drawing.Point(192, 63);
            this.lblShi.Name = "lblShi";
            this.lblShi.Size = new System.Drawing.Size(78, 23);
            this.lblShi.TabIndex = 1;
            this.lblShi.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(53, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "温度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(192, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "湿度";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRegisterNumbers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRegister);
            this.groupBox1.Controls.Add(this.lblRegister);
            this.groupBox1.Controls.Add(this.nudSlaveID);
            this.groupBox1.Controls.Add(this.btnCommit);
            this.groupBox1.Controls.Add(this.cboBudRate);
            this.groupBox1.Controls.Add(this.cboPortName);
            this.groupBox1.Controls.Add(this.lblDizhi);
            this.groupBox1.Controls.Add(this.lblBit);
            this.groupBox1.Controls.Add(this.lblPoint);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(29, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 305);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备连接";
            // 
            // nudSlaveID
            // 
            this.nudSlaveID.Location = new System.Drawing.Point(173, 175);
            this.nudSlaveID.Name = "nudSlaveID";
            this.nudSlaveID.Size = new System.Drawing.Size(155, 31);
            this.nudSlaveID.TabIndex = 7;
            // 
            // btnCommit
            // 
            this.btnCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCommit.Location = new System.Drawing.Point(168, 229);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(160, 30);
            this.btnCommit.TabIndex = 6;
            this.btnCommit.Text = "连接";
            this.btnCommit.UseVisualStyleBackColor = false;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // cboBudRate
            // 
            this.cboBudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBudRate.FormattingEnabled = true;
            this.cboBudRate.Location = new System.Drawing.Point(173, 116);
            this.cboBudRate.Name = "cboBudRate";
            this.cboBudRate.Size = new System.Drawing.Size(156, 29);
            this.cboBudRate.TabIndex = 4;
            // 
            // cboPortName
            // 
            this.cboPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortName.FormattingEnabled = true;
            this.cboPortName.Location = new System.Drawing.Point(173, 63);
            this.cboPortName.Name = "cboPortName";
            this.cboPortName.Size = new System.Drawing.Size(156, 29);
            this.cboPortName.TabIndex = 3;
            // 
            // lblDizhi
            // 
            this.lblDizhi.AutoSize = true;
            this.lblDizhi.Location = new System.Drawing.Point(30, 177);
            this.lblDizhi.Name = "lblDizhi";
            this.lblDizhi.Size = new System.Drawing.Size(120, 21);
            this.lblDizhi.TabIndex = 2;
            this.lblDizhi.Text = "设备站地址";
            // 
            // lblBit
            // 
            this.lblBit.AutoSize = true;
            this.lblBit.Location = new System.Drawing.Point(30, 119);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(76, 21);
            this.lblBit.TabIndex = 1;
            this.lblBit.Text = "波特率";
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(30, 66);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(76, 21);
            this.lblPoint.TabIndex = 0;
            this.lblPoint.Text = "端口号";
            // 
            // timer_Read
            // 
            this.timer_Read.Interval = 1000;
            this.timer_Read.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.SynchronizingObject = this;
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Location = new System.Drawing.Point(344, 63);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(164, 21);
            this.lblRegister.TabIndex = 8;
            this.lblRegister.Text = "初始寄存器地址";
            // 
            // txtRegister
            // 
            this.txtRegister.Location = new System.Drawing.Point(537, 58);
            this.txtRegister.Name = "txtRegister";
            this.txtRegister.Size = new System.Drawing.Size(128, 31);
            this.txtRegister.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "寄存器数量";
            // 
            // txtRegisterNumbers
            // 
            this.txtRegisterNumbers.Location = new System.Drawing.Point(537, 116);
            this.txtRegisterNumbers.Name = "txtRegisterNumbers";
            this.txtRegisterNumbers.Size = new System.Drawing.Size(128, 31);
            this.txtRegisterNumbers.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 523);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblShi);
            this.Controls.Add(this.lblWen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "基于Modbus温湿度采集案列";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlaveID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWen;
        private System.Windows.Forms.Label lblShi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Label lblDizhi;
        private System.Windows.Forms.Label lblBit;
        private System.Windows.Forms.ComboBox cboPortName;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.ComboBox cboBudRate;
        private System.Windows.Forms.NumericUpDown nudSlaveID;
        private System.Windows.Forms.Timer timer_Read;
        private System.Timers.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.TextBox txtRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegisterNumbers;
    }
}

