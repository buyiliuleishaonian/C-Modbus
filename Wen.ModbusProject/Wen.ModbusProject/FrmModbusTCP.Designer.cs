namespace Wen.ModbusProject
{
    partial class FrmModbusTCP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModbusTCP));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSlave = new System.Windows.Forms.TextBox();
            this.lblSlave = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbDataFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.list_Info = new System.Windows.Forms.ListView();
            this.clmDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtWriteData = new System.Windows.Forms.TextBox();
            this.lblWriteData = new System.Windows.Forms.Label();
            this.txtDataLength = new System.Windows.Forms.TextBox();
            this.lblDataLength = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.lblDataStyle = new System.Windows.Forms.Label();
            this.cmbStoreArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSlave);
            this.groupBox1.Controls.Add(this.lblSlave);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.btnDisConnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cmbDataFormat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.lblIp);
            this.groupBox1.Location = new System.Drawing.Point(32, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(971, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通信参数";
            // 
            // txtSlave
            // 
            this.txtSlave.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSlave.Location = new System.Drawing.Point(360, 86);
            this.txtSlave.Name = "txtSlave";
            this.txtSlave.Size = new System.Drawing.Size(107, 31);
            this.txtSlave.TabIndex = 18;
            this.txtSlave.Text = "1";
            this.txtSlave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSlave
            // 
            this.lblSlave.AutoSize = true;
            this.lblSlave.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSlave.Location = new System.Drawing.Point(260, 93);
            this.lblSlave.Name = "lblSlave";
            this.lblSlave.Size = new System.Drawing.Size(94, 21);
            this.lblSlave.TabIndex = 17;
            this.lblSlave.Text = "从站地址";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPort.Location = new System.Drawing.Point(332, 36);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(153, 31);
            this.txtPort.TabIndex = 16;
            this.txtPort.Text = "502";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIP.Location = new System.Drawing.Point(101, 36);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(153, 31);
            this.txtIP.TabIndex = 15;
            this.txtIP.Text = "127.0.0.1";
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.BackColor = System.Drawing.Color.Transparent;
            this.btnDisConnect.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDisConnect.Location = new System.Drawing.Point(719, 35);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(104, 30);
            this.btnDisConnect.TabIndex = 14;
            this.btnDisConnect.Text = "断开";
            this.btnDisConnect.UseVisualStyleBackColor = false;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Location = new System.Drawing.Point(531, 36);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(104, 30);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbDataFormat
            // 
            this.cmbDataFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataFormat.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDataFormat.FormattingEnabled = true;
            this.cmbDataFormat.Location = new System.Drawing.Point(101, 93);
            this.cmbDataFormat.Name = "cmbDataFormat";
            this.cmbDataFormat.Size = new System.Drawing.Size(102, 27);
            this.cmbDataFormat.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "大小端";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPort.Location = new System.Drawing.Point(260, 41);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(73, 21);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "端口号";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIp.Location = new System.Drawing.Point(21, 41);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(74, 21);
            this.lblIp.TabIndex = 1;
            this.lblIp.Text = "IP地址";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnWrite);
            this.groupBox2.Controls.Add(this.btnRead);
            this.groupBox2.Controls.Add(this.list_Info);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtWriteData);
            this.groupBox2.Controls.Add(this.lblWriteData);
            this.groupBox2.Controls.Add(this.txtDataLength);
            this.groupBox2.Controls.Add(this.lblDataLength);
            this.groupBox2.Controls.Add(this.txtStart);
            this.groupBox2.Controls.Add(this.lblStart);
            this.groupBox2.Controls.Add(this.cmbDataType);
            this.groupBox2.Controls.Add(this.lblDataStyle);
            this.groupBox2.Controls.Add(this.cmbStoreArea);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(32, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(971, 489);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读写测试";
            // 
            // btnWrite
            // 
            this.btnWrite.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWrite.Location = new System.Drawing.Point(652, 182);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(120, 30);
            this.btnWrite.TabIndex = 28;
            this.btnWrite.Text = "写入";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRead.Location = new System.Drawing.Point(651, 114);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(120, 30);
            this.btnRead.TabIndex = 15;
            this.btnRead.Text = "读取";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // list_Info
            // 
            this.list_Info.BackColor = System.Drawing.SystemColors.Control;
            this.list_Info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDateTime,
            this.clmData});
            this.list_Info.HideSelection = false;
            this.list_Info.Location = new System.Drawing.Point(24, 307);
            this.list_Info.MultiSelect = false;
            this.list_Info.Name = "list_Info";
            this.list_Info.ShowItemToolTips = true;
            this.list_Info.Size = new System.Drawing.Size(747, 157);
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
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(21, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "读取信息";
            // 
            // txtWriteData
            // 
            this.txtWriteData.Location = new System.Drawing.Point(227, 178);
            this.txtWriteData.Name = "txtWriteData";
            this.txtWriteData.Size = new System.Drawing.Size(324, 31);
            this.txtWriteData.TabIndex = 25;
            // 
            // lblWriteData
            // 
            this.lblWriteData.AutoSize = true;
            this.lblWriteData.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteData.Location = new System.Drawing.Point(21, 188);
            this.lblWriteData.Name = "lblWriteData";
            this.lblWriteData.Size = new System.Drawing.Size(200, 21);
            this.lblWriteData.TabIndex = 24;
            this.lblWriteData.Text = "读取数据(空格分开)";
            // 
            // txtDataLength
            // 
            this.txtDataLength.Location = new System.Drawing.Point(348, 113);
            this.txtDataLength.Name = "txtDataLength";
            this.txtDataLength.Size = new System.Drawing.Size(104, 31);
            this.txtDataLength.TabIndex = 23;
            this.txtDataLength.Text = "1";
            this.txtDataLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDataLength
            // 
            this.lblDataLength.AutoSize = true;
            this.lblDataLength.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDataLength.Location = new System.Drawing.Point(241, 120);
            this.lblDataLength.Name = "lblDataLength";
            this.lblDataLength.Size = new System.Drawing.Size(94, 21);
            this.lblDataLength.TabIndex = 22;
            this.lblDataLength.Text = "读取长度";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(113, 110);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(104, 31);
            this.txtStart.TabIndex = 21;
            this.txtStart.Text = "0";
            this.txtStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStart.Location = new System.Drawing.Point(21, 120);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(94, 21);
            this.lblStart.TabIndex = 20;
            this.lblStart.Text = "起始地址";
            // 
            // cmbDataType
            // 
            this.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataType.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(348, 44);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(104, 27);
            this.cmbDataType.TabIndex = 18;
            // 
            // lblDataStyle
            // 
            this.lblDataStyle.AutoSize = true;
            this.lblDataStyle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDataStyle.Location = new System.Drawing.Point(256, 54);
            this.lblDataStyle.Name = "lblDataStyle";
            this.lblDataStyle.Size = new System.Drawing.Size(94, 21);
            this.lblDataStyle.TabIndex = 19;
            this.lblDataStyle.Text = "数据类型";
            // 
            // cmbStoreArea
            // 
            this.cmbStoreArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStoreArea.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbStoreArea.FormattingEnabled = true;
            this.cmbStoreArea.Location = new System.Drawing.Point(101, 44);
            this.cmbStoreArea.Name = "cmbStoreArea";
            this.cmbStoreArea.Size = new System.Drawing.Size(140, 27);
            this.cmbStoreArea.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "存储区";
            // 
            // FrmModbusTCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 773);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmModbusTCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModbusRTU通信平台【文憔悴】";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbDataFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Label lblDataStyle;
        private System.Windows.Forms.ComboBox cmbStoreArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWriteData;
        private System.Windows.Forms.Label lblWriteData;
        private System.Windows.Forms.TextBox txtDataLength;
        private System.Windows.Forms.Label lblDataLength;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView list_Info;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader clmDateTime;
        private System.Windows.Forms.ColumnHeader clmData;
        private System.Windows.Forms.Label lblSlave;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtSlave;
    }
}

