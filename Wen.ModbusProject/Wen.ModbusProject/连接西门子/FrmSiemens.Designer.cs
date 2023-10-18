namespace Wen.ModbusProject
{
    partial class FrmSiemens
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.gx_Read = new System.Windows.Forms.GroupBox();
            this.lblString2 = new System.Windows.Forms.Label();
            this.lblString1 = new System.Windows.Forms.Label();
            this.lblFloat5 = new System.Windows.Forms.Label();
            this.lblFloat4 = new System.Windows.Forms.Label();
            this.lblFloat3 = new System.Windows.Forms.Label();
            this.lblFloat2 = new System.Windows.Forms.Label();
            this.lblFloat1 = new System.Windows.Forms.Label();
            this.lblInt5 = new System.Windows.Forms.Label();
            this.lblInt4 = new System.Windows.Forms.Label();
            this.lblInt3 = new System.Windows.Forms.Label();
            this.lblInt2 = new System.Windows.Forms.Label();
            this.lblReadString = new System.Windows.Forms.Label();
            this.lblReadFloat = new System.Windows.Forms.Label();
            this.lblInt1 = new System.Windows.Forms.Label();
            this.lblReadInt = new System.Windows.Forms.Label();
            this.lblReadBool5 = new System.Windows.Forms.Label();
            this.lblReadBool4 = new System.Windows.Forms.Label();
            this.lblReadBool3 = new System.Windows.Forms.Label();
            this.lblReadBool2 = new System.Windows.Forms.Label();
            this.lblReadBool1 = new System.Windows.Forms.Label();
            this.lblReadBool = new System.Windows.Forms.Label();
            this.gx_Write = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWriteString = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWriteFloat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWriteInt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gx_Read.SuspendLayout();
            this.gx_Write.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.btnDisConnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.lblIp);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 96);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通信参数";
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
            this.txtIP.Text = "192.168.0.12";
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
            // gx_Read
            // 
            this.gx_Read.Controls.Add(this.lblString2);
            this.gx_Read.Controls.Add(this.lblString1);
            this.gx_Read.Controls.Add(this.lblFloat5);
            this.gx_Read.Controls.Add(this.lblFloat4);
            this.gx_Read.Controls.Add(this.lblFloat3);
            this.gx_Read.Controls.Add(this.lblFloat2);
            this.gx_Read.Controls.Add(this.lblFloat1);
            this.gx_Read.Controls.Add(this.lblInt5);
            this.gx_Read.Controls.Add(this.lblInt4);
            this.gx_Read.Controls.Add(this.lblInt3);
            this.gx_Read.Controls.Add(this.lblInt2);
            this.gx_Read.Controls.Add(this.lblReadString);
            this.gx_Read.Controls.Add(this.lblReadFloat);
            this.gx_Read.Controls.Add(this.lblInt1);
            this.gx_Read.Controls.Add(this.lblReadInt);
            this.gx_Read.Controls.Add(this.lblReadBool5);
            this.gx_Read.Controls.Add(this.lblReadBool4);
            this.gx_Read.Controls.Add(this.lblReadBool3);
            this.gx_Read.Controls.Add(this.lblReadBool2);
            this.gx_Read.Controls.Add(this.lblReadBool1);
            this.gx_Read.Controls.Add(this.lblReadBool);
            this.gx_Read.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gx_Read.Location = new System.Drawing.Point(12, 167);
            this.gx_Read.Name = "gx_Read";
            this.gx_Read.Size = new System.Drawing.Size(859, 299);
            this.gx_Read.TabIndex = 17;
            this.gx_Read.TabStop = false;
            this.gx_Read.Text = "数据读取";
            // 
            // lblString2
            // 
            this.lblString2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblString2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblString2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblString2.ForeColor = System.Drawing.Color.Black;
            this.lblString2.Location = new System.Drawing.Point(495, 226);
            this.lblString2.Name = "lblString2";
            this.lblString2.Size = new System.Drawing.Size(273, 28);
            this.lblString2.TabIndex = 36;
            this.lblString2.Tag = "10;84;50";
            this.lblString2.Text = "0.0";
            this.lblString2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblString1
            // 
            this.lblString1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblString1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblString1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblString1.ForeColor = System.Drawing.Color.Black;
            this.lblString1.Location = new System.Drawing.Point(142, 226);
            this.lblString1.Name = "lblString1";
            this.lblString1.Size = new System.Drawing.Size(273, 28);
            this.lblString1.TabIndex = 35;
            this.lblString1.Tag = "10;32;50";
            this.lblString1.Text = "0.0";
            this.lblString1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFloat5
            // 
            this.lblFloat5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFloat5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFloat5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFloat5.ForeColor = System.Drawing.Color.Black;
            this.lblFloat5.Location = new System.Drawing.Point(661, 165);
            this.lblFloat5.Name = "lblFloat5";
            this.lblFloat5.Size = new System.Drawing.Size(93, 28);
            this.lblFloat5.TabIndex = 34;
            this.lblFloat5.Tag = "6;28;0";
            this.lblFloat5.Text = "0.0";
            this.lblFloat5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFloat4
            // 
            this.lblFloat4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFloat4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFloat4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFloat4.ForeColor = System.Drawing.Color.Black;
            this.lblFloat4.Location = new System.Drawing.Point(526, 165);
            this.lblFloat4.Name = "lblFloat4";
            this.lblFloat4.Size = new System.Drawing.Size(93, 28);
            this.lblFloat4.TabIndex = 33;
            this.lblFloat4.Tag = "6;24;0";
            this.lblFloat4.Text = "0.0";
            this.lblFloat4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFloat3
            // 
            this.lblFloat3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFloat3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFloat3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFloat3.ForeColor = System.Drawing.Color.Black;
            this.lblFloat3.Location = new System.Drawing.Point(391, 165);
            this.lblFloat3.Name = "lblFloat3";
            this.lblFloat3.Size = new System.Drawing.Size(93, 28);
            this.lblFloat3.TabIndex = 32;
            this.lblFloat3.Tag = "6;20;0";
            this.lblFloat3.Text = "0.0";
            this.lblFloat3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFloat2
            // 
            this.lblFloat2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFloat2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFloat2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFloat2.ForeColor = System.Drawing.Color.Black;
            this.lblFloat2.Location = new System.Drawing.Point(256, 165);
            this.lblFloat2.Name = "lblFloat2";
            this.lblFloat2.Size = new System.Drawing.Size(93, 28);
            this.lblFloat2.TabIndex = 31;
            this.lblFloat2.Tag = "6;16;0";
            this.lblFloat2.Text = "0.0";
            this.lblFloat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFloat1
            // 
            this.lblFloat1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFloat1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFloat1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFloat1.ForeColor = System.Drawing.Color.Black;
            this.lblFloat1.Location = new System.Drawing.Point(121, 165);
            this.lblFloat1.Name = "lblFloat1";
            this.lblFloat1.Size = new System.Drawing.Size(93, 28);
            this.lblFloat1.TabIndex = 30;
            this.lblFloat1.Tag = "6;12;0";
            this.lblFloat1.Text = "0.0";
            this.lblFloat1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInt5
            // 
            this.lblInt5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInt5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInt5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInt5.ForeColor = System.Drawing.Color.Black;
            this.lblInt5.Location = new System.Drawing.Point(661, 99);
            this.lblInt5.Name = "lblInt5";
            this.lblInt5.Size = new System.Drawing.Size(93, 28);
            this.lblInt5.TabIndex = 29;
            this.lblInt5.Tag = "2;10;0";
            this.lblInt5.Text = "0";
            this.lblInt5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInt4
            // 
            this.lblInt4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInt4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInt4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInt4.ForeColor = System.Drawing.Color.Black;
            this.lblInt4.Location = new System.Drawing.Point(526, 99);
            this.lblInt4.Name = "lblInt4";
            this.lblInt4.Size = new System.Drawing.Size(93, 28);
            this.lblInt4.TabIndex = 28;
            this.lblInt4.Tag = "2;8;0";
            this.lblInt4.Text = "0";
            this.lblInt4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInt3
            // 
            this.lblInt3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInt3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInt3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInt3.ForeColor = System.Drawing.Color.Black;
            this.lblInt3.Location = new System.Drawing.Point(391, 99);
            this.lblInt3.Name = "lblInt3";
            this.lblInt3.Size = new System.Drawing.Size(93, 28);
            this.lblInt3.TabIndex = 27;
            this.lblInt3.Tag = "2;6;0";
            this.lblInt3.Text = "0";
            this.lblInt3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInt2
            // 
            this.lblInt2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInt2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInt2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInt2.ForeColor = System.Drawing.Color.Black;
            this.lblInt2.Location = new System.Drawing.Point(256, 99);
            this.lblInt2.Name = "lblInt2";
            this.lblInt2.Size = new System.Drawing.Size(93, 28);
            this.lblInt2.TabIndex = 26;
            this.lblInt2.Tag = "2;4;0";
            this.lblInt2.Text = "0";
            this.lblInt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReadString
            // 
            this.lblReadString.AutoSize = true;
            this.lblReadString.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadString.Location = new System.Drawing.Point(6, 233);
            this.lblReadString.Name = "lblReadString";
            this.lblReadString.Size = new System.Drawing.Size(115, 21);
            this.lblReadString.TabIndex = 20;
            this.lblReadString.Text = "字符串数据";
            // 
            // lblReadFloat
            // 
            this.lblReadFloat.AutoSize = true;
            this.lblReadFloat.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadFloat.Location = new System.Drawing.Point(6, 169);
            this.lblReadFloat.Name = "lblReadFloat";
            this.lblReadFloat.Size = new System.Drawing.Size(94, 21);
            this.lblReadFloat.TabIndex = 14;
            this.lblReadFloat.Text = "浮点数据";
            // 
            // lblInt1
            // 
            this.lblInt1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInt1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInt1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInt1.ForeColor = System.Drawing.Color.Black;
            this.lblInt1.Location = new System.Drawing.Point(121, 99);
            this.lblInt1.Name = "lblInt1";
            this.lblInt1.Size = new System.Drawing.Size(93, 28);
            this.lblInt1.TabIndex = 9;
            this.lblInt1.Tag = "2;2;0";
            this.lblInt1.Text = "0";
            this.lblInt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReadInt
            // 
            this.lblReadInt.AutoSize = true;
            this.lblReadInt.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadInt.Location = new System.Drawing.Point(6, 105);
            this.lblReadInt.Name = "lblReadInt";
            this.lblReadInt.Size = new System.Drawing.Size(94, 21);
            this.lblReadInt.TabIndex = 8;
            this.lblReadInt.Text = "整型数据";
            // 
            // lblReadBool5
            // 
            this.lblReadBool5.BackColor = System.Drawing.Color.Red;
            this.lblReadBool5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReadBool5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadBool5.ForeColor = System.Drawing.Color.White;
            this.lblReadBool5.Location = new System.Drawing.Point(661, 34);
            this.lblReadBool5.Name = "lblReadBool5";
            this.lblReadBool5.Size = new System.Drawing.Size(93, 28);
            this.lblReadBool5.TabIndex = 7;
            this.lblReadBool5.Tag = "0;0;4";
            this.lblReadBool5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReadBool4
            // 
            this.lblReadBool4.BackColor = System.Drawing.Color.Red;
            this.lblReadBool4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReadBool4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadBool4.ForeColor = System.Drawing.Color.White;
            this.lblReadBool4.Location = new System.Drawing.Point(526, 34);
            this.lblReadBool4.Name = "lblReadBool4";
            this.lblReadBool4.Size = new System.Drawing.Size(93, 28);
            this.lblReadBool4.TabIndex = 5;
            this.lblReadBool4.Tag = "0;0;3";
            this.lblReadBool4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReadBool3
            // 
            this.lblReadBool3.BackColor = System.Drawing.Color.Red;
            this.lblReadBool3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReadBool3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadBool3.ForeColor = System.Drawing.Color.White;
            this.lblReadBool3.Location = new System.Drawing.Point(391, 34);
            this.lblReadBool3.Name = "lblReadBool3";
            this.lblReadBool3.Size = new System.Drawing.Size(93, 28);
            this.lblReadBool3.TabIndex = 4;
            this.lblReadBool3.Tag = "0;0;2";
            this.lblReadBool3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReadBool2
            // 
            this.lblReadBool2.BackColor = System.Drawing.Color.Red;
            this.lblReadBool2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReadBool2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadBool2.ForeColor = System.Drawing.Color.White;
            this.lblReadBool2.Location = new System.Drawing.Point(256, 34);
            this.lblReadBool2.Name = "lblReadBool2";
            this.lblReadBool2.Size = new System.Drawing.Size(93, 28);
            this.lblReadBool2.TabIndex = 3;
            this.lblReadBool2.Tag = "0;0;1";
            this.lblReadBool2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReadBool1
            // 
            this.lblReadBool1.BackColor = System.Drawing.Color.Red;
            this.lblReadBool1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReadBool1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadBool1.ForeColor = System.Drawing.Color.White;
            this.lblReadBool1.Location = new System.Drawing.Point(121, 34);
            this.lblReadBool1.Name = "lblReadBool1";
            this.lblReadBool1.Size = new System.Drawing.Size(93, 28);
            this.lblReadBool1.TabIndex = 2;
            this.lblReadBool1.Tag = "0;0;0";
            this.lblReadBool1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReadBool
            // 
            this.lblReadBool.AutoSize = true;
            this.lblReadBool.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReadBool.Location = new System.Drawing.Point(6, 41);
            this.lblReadBool.Name = "lblReadBool";
            this.lblReadBool.Size = new System.Drawing.Size(94, 21);
            this.lblReadBool.TabIndex = 1;
            this.lblReadBool.Text = "布尔数据";
            // 
            // gx_Write
            // 
            this.gx_Write.Controls.Add(this.label1);
            this.gx_Write.Controls.Add(this.lblWriteString);
            this.gx_Write.Controls.Add(this.label2);
            this.gx_Write.Controls.Add(this.lblWriteFloat);
            this.gx_Write.Controls.Add(this.label3);
            this.gx_Write.Controls.Add(this.lblWriteInt);
            this.gx_Write.Controls.Add(this.label4);
            this.gx_Write.Controls.Add(this.label12);
            this.gx_Write.Controls.Add(this.label5);
            this.gx_Write.Controls.Add(this.label11);
            this.gx_Write.Controls.Add(this.label6);
            this.gx_Write.Controls.Add(this.label10);
            this.gx_Write.Controls.Add(this.label7);
            this.gx_Write.Controls.Add(this.label9);
            this.gx_Write.Controls.Add(this.label8);
            this.gx_Write.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gx_Write.Location = new System.Drawing.Point(12, 492);
            this.gx_Write.Name = "gx_Write";
            this.gx_Write.Size = new System.Drawing.Size(859, 299);
            this.gx_Write.TabIndex = 37;
            this.gx_Write.TabStop = false;
            this.gx_Write.Text = "数据写入";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(495, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 28);
            this.label1.TabIndex = 48;
            this.label1.Tag = "10;84;50";
            this.label1.Text = "0.0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // lblWriteString
            // 
            this.lblWriteString.AutoSize = true;
            this.lblWriteString.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteString.Location = new System.Drawing.Point(6, 195);
            this.lblWriteString.Name = "lblWriteString";
            this.lblWriteString.Size = new System.Drawing.Size(115, 21);
            this.lblWriteString.TabIndex = 20;
            this.lblWriteString.Text = "字符串数据";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(142, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 28);
            this.label2.TabIndex = 47;
            this.label2.Tag = "10;32;50";
            this.label2.Text = "0.0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // lblWriteFloat
            // 
            this.lblWriteFloat.AutoSize = true;
            this.lblWriteFloat.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteFloat.Location = new System.Drawing.Point(6, 131);
            this.lblWriteFloat.Name = "lblWriteFloat";
            this.lblWriteFloat.Size = new System.Drawing.Size(94, 21);
            this.lblWriteFloat.TabIndex = 14;
            this.lblWriteFloat.Text = "浮点数据";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(661, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 28);
            this.label3.TabIndex = 46;
            this.label3.Tag = "6;28;0";
            this.label3.Text = "0.0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // lblWriteInt
            // 
            this.lblWriteInt.AutoSize = true;
            this.lblWriteInt.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteInt.Location = new System.Drawing.Point(6, 67);
            this.lblWriteInt.Name = "lblWriteInt";
            this.lblWriteInt.Size = new System.Drawing.Size(94, 21);
            this.lblWriteInt.TabIndex = 8;
            this.lblWriteInt.Text = "整型数据";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(526, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 28);
            this.label4.TabIndex = 45;
            this.label4.Tag = "6;24;0";
            this.label4.Text = "0.0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(121, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 28);
            this.label12.TabIndex = 37;
            this.label12.Tag = "2;2;0";
            this.label12.Text = "0";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(391, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 28);
            this.label5.TabIndex = 44;
            this.label5.Tag = "6;20;0";
            this.label5.Text = "0.0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(256, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 28);
            this.label11.TabIndex = 38;
            this.label11.Tag = "2;4;0";
            this.label11.Text = "0";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(256, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 28);
            this.label6.TabIndex = 43;
            this.label6.Tag = "6;16;0";
            this.label6.Text = "0.0";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(391, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 28);
            this.label10.TabIndex = 39;
            this.label10.Tag = "2;6;0";
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(121, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 28);
            this.label7.TabIndex = 42;
            this.label7.Tag = "6;12;0";
            this.label7.Text = "0.0";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(526, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 28);
            this.label9.TabIndex = 40;
            this.label9.Tag = "2;8;0";
            this.label9.Text = "0";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(661, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 28);
            this.label8.TabIndex = 41;
            this.label8.Tag = "2;10;0";
            this.label8.Text = "0";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.DoubleClick += new System.EventHandler(this.CommonModify_DoubleClick);
            // 
            // FrmSiemens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 832);
            this.Controls.Add(this.gx_Write);
            this.Controls.Add(this.gx_Read);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSiemens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于ModbusTCP实现西门子通信";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gx_Read.ResumeLayout(false);
            this.gx_Read.PerformLayout();
            this.gx_Write.ResumeLayout(false);
            this.gx_Write.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.GroupBox gx_Read;
        private System.Windows.Forms.Label lblReadBool;
        private System.Windows.Forms.Label lblReadBool1;
        private System.Windows.Forms.Label lblReadBool5;
        private System.Windows.Forms.Label lblReadBool4;
        private System.Windows.Forms.Label lblReadBool3;
        private System.Windows.Forms.Label lblReadBool2;
        private System.Windows.Forms.Label lblInt1;
        private System.Windows.Forms.Label lblReadInt;
        private System.Windows.Forms.Label lblReadString;
        private System.Windows.Forms.Label lblReadFloat;
        private System.Windows.Forms.Label lblInt4;
        private System.Windows.Forms.Label lblInt3;
        private System.Windows.Forms.Label lblInt2;
        private System.Windows.Forms.Label lblString2;
        private System.Windows.Forms.Label lblString1;
        private System.Windows.Forms.Label lblFloat5;
        private System.Windows.Forms.Label lblFloat4;
        private System.Windows.Forms.Label lblFloat3;
        private System.Windows.Forms.Label lblFloat2;
        private System.Windows.Forms.Label lblFloat1;
        private System.Windows.Forms.Label lblInt5;
        private System.Windows.Forms.GroupBox gx_Write;
        private System.Windows.Forms.Label lblWriteString;
        private System.Windows.Forms.Label lblWriteFloat;
        private System.Windows.Forms.Label lblWriteInt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}