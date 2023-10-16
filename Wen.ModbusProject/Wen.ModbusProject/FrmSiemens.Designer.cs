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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblWriteString2 = new System.Windows.Forms.Label();
            this.lblWriteString1 = new System.Windows.Forms.Label();
            this.lblWriteFloat5 = new System.Windows.Forms.Label();
            this.lblWriteFloat4 = new System.Windows.Forms.Label();
            this.lblWriteFloat3 = new System.Windows.Forms.Label();
            this.lblWriteFloat2 = new System.Windows.Forms.Label();
            this.lblWriteFloat1 = new System.Windows.Forms.Label();
            this.lblWriteInt5 = new System.Windows.Forms.Label();
            this.lblWriteInt4 = new System.Windows.Forms.Label();
            this.lblWriteInt3 = new System.Windows.Forms.Label();
            this.lblWriteInt2 = new System.Windows.Forms.Label();
            this.lblWriteString = new System.Windows.Forms.Label();
            this.lblWriteFloat = new System.Windows.Forms.Label();
            this.lblWriteInt1 = new System.Windows.Forms.Label();
            this.lblWriteInt = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.groupBox2.Controls.Add(this.lblString2);
            this.groupBox2.Controls.Add(this.lblString1);
            this.groupBox2.Controls.Add(this.lblFloat5);
            this.groupBox2.Controls.Add(this.lblFloat4);
            this.groupBox2.Controls.Add(this.lblFloat3);
            this.groupBox2.Controls.Add(this.lblFloat2);
            this.groupBox2.Controls.Add(this.lblFloat1);
            this.groupBox2.Controls.Add(this.lblInt5);
            this.groupBox2.Controls.Add(this.lblInt4);
            this.groupBox2.Controls.Add(this.lblInt3);
            this.groupBox2.Controls.Add(this.lblInt2);
            this.groupBox2.Controls.Add(this.lblReadString);
            this.groupBox2.Controls.Add(this.lblReadFloat);
            this.groupBox2.Controls.Add(this.lblInt1);
            this.groupBox2.Controls.Add(this.lblReadInt);
            this.groupBox2.Controls.Add(this.lblReadBool5);
            this.groupBox2.Controls.Add(this.lblReadBool4);
            this.groupBox2.Controls.Add(this.lblReadBool3);
            this.groupBox2.Controls.Add(this.lblReadBool2);
            this.groupBox2.Controls.Add(this.lblReadBool1);
            this.groupBox2.Controls.Add(this.lblReadBool);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(859, 299);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据读取";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblWriteString2);
            this.groupBox3.Controls.Add(this.lblWriteString1);
            this.groupBox3.Controls.Add(this.lblWriteFloat5);
            this.groupBox3.Controls.Add(this.lblWriteFloat4);
            this.groupBox3.Controls.Add(this.lblWriteFloat3);
            this.groupBox3.Controls.Add(this.lblWriteFloat2);
            this.groupBox3.Controls.Add(this.lblWriteFloat1);
            this.groupBox3.Controls.Add(this.lblWriteInt5);
            this.groupBox3.Controls.Add(this.lblWriteInt4);
            this.groupBox3.Controls.Add(this.lblWriteInt3);
            this.groupBox3.Controls.Add(this.lblWriteInt2);
            this.groupBox3.Controls.Add(this.lblWriteString);
            this.groupBox3.Controls.Add(this.lblWriteFloat);
            this.groupBox3.Controls.Add(this.lblWriteInt1);
            this.groupBox3.Controls.Add(this.lblWriteInt);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(12, 492);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(859, 299);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据写入";
            // 
            // lblWriteString2
            // 
            this.lblWriteString2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteString2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteString2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteString2.ForeColor = System.Drawing.Color.Black;
            this.lblWriteString2.Location = new System.Drawing.Point(495, 188);
            this.lblWriteString2.Name = "lblWriteString2";
            this.lblWriteString2.Size = new System.Drawing.Size(273, 28);
            this.lblWriteString2.TabIndex = 36;
            this.lblWriteString2.Text = "0.0";
            this.lblWriteString2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteString1
            // 
            this.lblWriteString1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteString1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteString1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteString1.ForeColor = System.Drawing.Color.Black;
            this.lblWriteString1.Location = new System.Drawing.Point(142, 188);
            this.lblWriteString1.Name = "lblWriteString1";
            this.lblWriteString1.Size = new System.Drawing.Size(273, 28);
            this.lblWriteString1.TabIndex = 35;
            this.lblWriteString1.Text = "0.0";
            this.lblWriteString1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteFloat5
            // 
            this.lblWriteFloat5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteFloat5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteFloat5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteFloat5.ForeColor = System.Drawing.Color.Black;
            this.lblWriteFloat5.Location = new System.Drawing.Point(661, 127);
            this.lblWriteFloat5.Name = "lblWriteFloat5";
            this.lblWriteFloat5.Size = new System.Drawing.Size(93, 28);
            this.lblWriteFloat5.TabIndex = 34;
            this.lblWriteFloat5.Text = "0.0";
            this.lblWriteFloat5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteFloat4
            // 
            this.lblWriteFloat4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteFloat4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteFloat4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteFloat4.ForeColor = System.Drawing.Color.Black;
            this.lblWriteFloat4.Location = new System.Drawing.Point(526, 127);
            this.lblWriteFloat4.Name = "lblWriteFloat4";
            this.lblWriteFloat4.Size = new System.Drawing.Size(93, 28);
            this.lblWriteFloat4.TabIndex = 33;
            this.lblWriteFloat4.Text = "0.0";
            this.lblWriteFloat4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteFloat3
            // 
            this.lblWriteFloat3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteFloat3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteFloat3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteFloat3.ForeColor = System.Drawing.Color.Black;
            this.lblWriteFloat3.Location = new System.Drawing.Point(391, 127);
            this.lblWriteFloat3.Name = "lblWriteFloat3";
            this.lblWriteFloat3.Size = new System.Drawing.Size(93, 28);
            this.lblWriteFloat3.TabIndex = 32;
            this.lblWriteFloat3.Text = "0.0";
            this.lblWriteFloat3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteFloat2
            // 
            this.lblWriteFloat2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteFloat2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteFloat2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteFloat2.ForeColor = System.Drawing.Color.Black;
            this.lblWriteFloat2.Location = new System.Drawing.Point(256, 127);
            this.lblWriteFloat2.Name = "lblWriteFloat2";
            this.lblWriteFloat2.Size = new System.Drawing.Size(93, 28);
            this.lblWriteFloat2.TabIndex = 31;
            this.lblWriteFloat2.Text = "0.0";
            this.lblWriteFloat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteFloat1
            // 
            this.lblWriteFloat1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteFloat1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteFloat1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteFloat1.ForeColor = System.Drawing.Color.Black;
            this.lblWriteFloat1.Location = new System.Drawing.Point(121, 127);
            this.lblWriteFloat1.Name = "lblWriteFloat1";
            this.lblWriteFloat1.Size = new System.Drawing.Size(93, 28);
            this.lblWriteFloat1.TabIndex = 30;
            this.lblWriteFloat1.Text = "0.0";
            this.lblWriteFloat1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteInt5
            // 
            this.lblWriteInt5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteInt5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteInt5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteInt5.ForeColor = System.Drawing.Color.Black;
            this.lblWriteInt5.Location = new System.Drawing.Point(661, 61);
            this.lblWriteInt5.Name = "lblWriteInt5";
            this.lblWriteInt5.Size = new System.Drawing.Size(93, 28);
            this.lblWriteInt5.TabIndex = 29;
            this.lblWriteInt5.Text = "0";
            this.lblWriteInt5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteInt4
            // 
            this.lblWriteInt4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteInt4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteInt4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteInt4.ForeColor = System.Drawing.Color.Black;
            this.lblWriteInt4.Location = new System.Drawing.Point(526, 61);
            this.lblWriteInt4.Name = "lblWriteInt4";
            this.lblWriteInt4.Size = new System.Drawing.Size(93, 28);
            this.lblWriteInt4.TabIndex = 28;
            this.lblWriteInt4.Text = "0";
            this.lblWriteInt4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteInt3
            // 
            this.lblWriteInt3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteInt3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteInt3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteInt3.ForeColor = System.Drawing.Color.Black;
            this.lblWriteInt3.Location = new System.Drawing.Point(391, 61);
            this.lblWriteInt3.Name = "lblWriteInt3";
            this.lblWriteInt3.Size = new System.Drawing.Size(93, 28);
            this.lblWriteInt3.TabIndex = 27;
            this.lblWriteInt3.Text = "0";
            this.lblWriteInt3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWriteInt2
            // 
            this.lblWriteInt2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteInt2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteInt2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteInt2.ForeColor = System.Drawing.Color.Black;
            this.lblWriteInt2.Location = new System.Drawing.Point(256, 61);
            this.lblWriteInt2.Name = "lblWriteInt2";
            this.lblWriteInt2.Size = new System.Drawing.Size(93, 28);
            this.lblWriteInt2.TabIndex = 26;
            this.lblWriteInt2.Text = "0";
            this.lblWriteInt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lblWriteInt1
            // 
            this.lblWriteInt1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWriteInt1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWriteInt1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWriteInt1.ForeColor = System.Drawing.Color.Black;
            this.lblWriteInt1.Location = new System.Drawing.Point(121, 61);
            this.lblWriteInt1.Name = "lblWriteInt1";
            this.lblWriteInt1.Size = new System.Drawing.Size(93, 28);
            this.lblWriteInt1.TabIndex = 9;
            this.lblWriteInt1.Text = "0";
            this.lblWriteInt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // FrmSiemens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 832);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSiemens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "基于ModbusTCP实现西门子通信";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblWriteString2;
        private System.Windows.Forms.Label lblWriteString1;
        private System.Windows.Forms.Label lblWriteFloat5;
        private System.Windows.Forms.Label lblWriteFloat4;
        private System.Windows.Forms.Label lblWriteFloat3;
        private System.Windows.Forms.Label lblWriteFloat2;
        private System.Windows.Forms.Label lblWriteFloat1;
        private System.Windows.Forms.Label lblWriteInt5;
        private System.Windows.Forms.Label lblWriteInt4;
        private System.Windows.Forms.Label lblWriteInt3;
        private System.Windows.Forms.Label lblWriteInt2;
        private System.Windows.Forms.Label lblWriteString;
        private System.Windows.Forms.Label lblWriteFloat;
        private System.Windows.Forms.Label lblWriteInt1;
        private System.Windows.Forms.Label lblWriteInt;
    }
}