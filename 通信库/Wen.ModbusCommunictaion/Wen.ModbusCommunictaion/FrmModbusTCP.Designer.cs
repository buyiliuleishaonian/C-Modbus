namespace Wen.ModbusCommunictaion
{
    partial class FrmModbusTCP
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
            this.chk_IsShortAddress = new System.Windows.Forms.CheckBox();
            this.txt_DevAddress = new System.Windows.Forms.TextBox();
            this.cmb_DataFormat = new System.Windows.Forms.ComboBox();
            this.cmb_Port = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_DisConn = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lst_Info = new System.Windows.Forms.ListView();
            this.InfoTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmb_DataType = new System.Windows.Forms.ComboBox();
            this.btn_Write = new System.Windows.Forms.Button();
            this.btn_Read = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Count = new System.Windows.Forms.TextBox();
            this.txt_SetValue = new System.Windows.Forms.TextBox();
            this.txt_Variable = new System.Windows.Forms.TextBox();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_IP);
            this.groupBox1.Controls.Add(this.chk_IsShortAddress);
            this.groupBox1.Controls.Add(this.txt_DevAddress);
            this.groupBox1.Controls.Add(this.cmb_DataFormat);
            this.groupBox1.Controls.Add(this.cmb_Port);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btn_DisConn);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 193);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通信参数";
            // 
            // chk_IsShortAddress
            // 
            this.chk_IsShortAddress.AutoSize = true;
            this.chk_IsShortAddress.Checked = true;
            this.chk_IsShortAddress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_IsShortAddress.Location = new System.Drawing.Point(439, 92);
            this.chk_IsShortAddress.Name = "chk_IsShortAddress";
            this.chk_IsShortAddress.Size = new System.Drawing.Size(96, 16);
            this.chk_IsShortAddress.TabIndex = 8;
            this.chk_IsShortAddress.Text = "是否为短地址";
            this.chk_IsShortAddress.UseVisualStyleBackColor = true;
            // 
            // txt_DevAddress
            // 
            this.txt_DevAddress.Location = new System.Drawing.Point(101, 144);
            this.txt_DevAddress.Name = "txt_DevAddress";
            this.txt_DevAddress.Size = new System.Drawing.Size(81, 21);
            this.txt_DevAddress.TabIndex = 3;
            this.txt_DevAddress.Text = "1";
            this.txt_DevAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_DataFormat
            // 
            this.cmb_DataFormat.FormattingEnabled = true;
            this.cmb_DataFormat.Location = new System.Drawing.Point(280, 141);
            this.cmb_DataFormat.Name = "cmb_DataFormat";
            this.cmb_DataFormat.Size = new System.Drawing.Size(88, 20);
            this.cmb_DataFormat.TabIndex = 4;
            // 
            // cmb_Port
            // 
            this.cmb_Port.FormattingEnabled = true;
            this.cmb_Port.Location = new System.Drawing.Point(101, 38);
            this.cmb_Port.Name = "cmb_Port";
            this.cmb_Port.Size = new System.Drawing.Size(81, 20);
            this.cmb_Port.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(206, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "大小端：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "站地址：";
            // 
            // btn_DisConn
            // 
            this.btn_DisConn.Location = new System.Drawing.Point(505, 140);
            this.btn_DisConn.Name = "btn_DisConn";
            this.btn_DisConn.Size = new System.Drawing.Size(81, 32);
            this.btn_DisConn.TabIndex = 7;
            this.btn_DisConn.Text = "断开连接";
            this.btn_DisConn.UseVisualStyleBackColor = true;
            this.btn_DisConn.Click += new System.EventHandler(this.btn_DisConn_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(413, 141);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(81, 32);
            this.btn_Connect.TabIndex = 6;
            this.btn_Connect.Text = "建立连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "端口号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lst_Info);
            this.groupBox2.Controls.Add(this.cmb_DataType);
            this.groupBox2.Controls.Add(this.btn_Write);
            this.groupBox2.Controls.Add(this.btn_Read);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_Count);
            this.groupBox2.Controls.Add(this.txt_SetValue);
            this.groupBox2.Controls.Add(this.txt_Variable);
            this.groupBox2.Location = new System.Drawing.Point(10, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 346);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读写测试";
            // 
            // lst_Info
            // 
            this.lst_Info.BackColor = System.Drawing.SystemColors.Control;
            this.lst_Info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InfoTime,
            this.Info});
            this.lst_Info.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_Info.HideSelection = false;
            this.lst_Info.Location = new System.Drawing.Point(25, 193);
            this.lst_Info.Name = "lst_Info";
            this.lst_Info.ShowItemToolTips = true;
            this.lst_Info.Size = new System.Drawing.Size(558, 138);
            this.lst_Info.TabIndex = 6;
            this.lst_Info.UseCompatibleStateImageBehavior = false;
            this.lst_Info.View = System.Windows.Forms.View.Details;
            // 
            // InfoTime
            // 
            this.InfoTime.Text = "日志时间";
            this.InfoTime.Width = 200;
            // 
            // Info
            // 
            this.Info.Text = "日志信息";
            this.Info.Width = 300;
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.FormattingEnabled = true;
            this.cmb_DataType.Location = new System.Drawing.Point(443, 37);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Size = new System.Drawing.Size(111, 20);
            this.cmb_DataType.TabIndex = 2;
            // 
            // btn_Write
            // 
            this.btn_Write.Location = new System.Drawing.Point(455, 130);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(101, 32);
            this.btn_Write.TabIndex = 7;
            this.btn_Write.Text = "写入";
            this.btn_Write.UseVisualStyleBackColor = true;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(455, 82);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(101, 32);
            this.btn_Read.TabIndex = 5;
            this.btn_Read.Text = "读取";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "变量类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "读取数量：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "写入数值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "变量地址：";
            // 
            // txt_Count
            // 
            this.txt_Count.Location = new System.Drawing.Point(133, 86);
            this.txt_Count.Name = "txt_Count";
            this.txt_Count.Size = new System.Drawing.Size(259, 21);
            this.txt_Count.TabIndex = 6;
            this.txt_Count.Text = "1";
            this.txt_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_SetValue
            // 
            this.txt_SetValue.Location = new System.Drawing.Point(133, 134);
            this.txt_SetValue.Name = "txt_SetValue";
            this.txt_SetValue.Size = new System.Drawing.Size(259, 21);
            this.txt_SetValue.TabIndex = 6;
            this.txt_SetValue.Text = "0";
            this.txt_SetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Variable
            // 
            this.txt_Variable.Location = new System.Drawing.Point(133, 38);
            this.txt_Variable.Name = "txt_Variable";
            this.txt_Variable.Size = new System.Drawing.Size(140, 21);
            this.txt_Variable.TabIndex = 3;
            this.txt_Variable.Text = "00001";
            this.txt_Variable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(241, 37);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(81, 21);
            this.txt_IP.TabIndex = 9;
            this.txt_IP.Text = "127.0.0.1";
            this.txt_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmModbusTCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 582);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmModbusTCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmModbusTCP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_IsShortAddress;
        private System.Windows.Forms.TextBox txt_DevAddress;
        private System.Windows.Forms.ComboBox cmb_DataFormat;
        private System.Windows.Forms.ComboBox cmb_Port;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_DisConn;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lst_Info;
        private System.Windows.Forms.ColumnHeader InfoTime;
        private System.Windows.Forms.ColumnHeader Info;
        private System.Windows.Forms.ComboBox cmb_DataType;
        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Count;
        private System.Windows.Forms.TextBox txt_SetValue;
        private System.Windows.Forms.TextBox txt_Variable;
        private System.Windows.Forms.TextBox txt_IP;
    }
}