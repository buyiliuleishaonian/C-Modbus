﻿namespace AIR_ModbusTCP
{
    partial class FrmPump
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPump));
            this.panelEnhanced1 = new thinger.ControlLib.PanelEnhanced();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.simpleLed2 = new thinger.ControlLib.SimpleLed();
            this.simpleLed1 = new thinger.ControlLib.SimpleLed();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Mode = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.textShow4 = new thinger.ControlLib.TextShow();
            this.btn_Run = new System.Windows.Forms.Button();
            this.textShow3 = new thinger.ControlLib.TextShow();
            this.label9 = new System.Windows.Forms.Label();
            this.textShow2 = new thinger.ControlLib.TextShow();
            this.label8 = new System.Windows.Forms.Label();
            this.textShow1 = new thinger.ControlLib.TextShow();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textShow5 = new thinger.ControlLib.TextShow();
            this.label5 = new System.Windows.Forms.Label();
            this.textShow6 = new thinger.ControlLib.TextShow();
            this.label4 = new System.Windows.Forms.Label();
            this.textShow7 = new thinger.ControlLib.TextShow();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::AIR_ModbusTCP.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.btn_Close);
            this.panelEnhanced1.Controls.Add(this.lbl_Title);
            this.panelEnhanced1.Controls.Add(this.simpleLed2);
            this.panelEnhanced1.Controls.Add(this.simpleLed1);
            this.panelEnhanced1.Controls.Add(this.label10);
            this.panelEnhanced1.Controls.Add(this.btn_Mode);
            this.panelEnhanced1.Controls.Add(this.btn_Stop);
            this.panelEnhanced1.Controls.Add(this.textShow4);
            this.panelEnhanced1.Controls.Add(this.btn_Run);
            this.panelEnhanced1.Controls.Add(this.textShow3);
            this.panelEnhanced1.Controls.Add(this.label9);
            this.panelEnhanced1.Controls.Add(this.textShow2);
            this.panelEnhanced1.Controls.Add(this.label8);
            this.panelEnhanced1.Controls.Add(this.textShow1);
            this.panelEnhanced1.Controls.Add(this.label7);
            this.panelEnhanced1.Controls.Add(this.label6);
            this.panelEnhanced1.Controls.Add(this.textShow5);
            this.panelEnhanced1.Controls.Add(this.label5);
            this.panelEnhanced1.Controls.Add(this.textShow6);
            this.panelEnhanced1.Controls.Add(this.label4);
            this.panelEnhanced1.Controls.Add(this.textShow7);
            this.panelEnhanced1.Controls.Add(this.label3);
            this.panelEnhanced1.Controls.Add(this.label2);
            this.panelEnhanced1.Controls.Add(this.label1);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(546, 453);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(487, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(56, 46);
            this.btn_Close.TabIndex = 110;
            this.btn_Close.Text = "×";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.lbl_Title.Location = new System.Drawing.Point(18, 18);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(131, 26);
            this.lbl_Title.TabIndex = 109;
            this.lbl_Title.Text = "1#冷却循环泵";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // simpleLed2
            // 
            this.simpleLed2.BackColor = System.Drawing.Color.Transparent;
            this.simpleLed2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleLed2.BackgroundImage")));
            this.simpleLed2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.simpleLed2.BindVarName = null;
            this.simpleLed2.Location = new System.Drawing.Point(427, 359);
            this.simpleLed2.Margin = new System.Windows.Forms.Padding(8, 14, 8, 14);
            this.simpleLed2.Name = "simpleLed2";
            this.simpleLed2.Size = new System.Drawing.Size(42, 46);
            this.simpleLed2.State = false;
            this.simpleLed2.TabIndex = 107;
            // 
            // simpleLed1
            // 
            this.simpleLed1.BackColor = System.Drawing.Color.Transparent;
            this.simpleLed1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleLed1.BackgroundImage")));
            this.simpleLed1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.simpleLed1.BindVarName = null;
            this.simpleLed1.Location = new System.Drawing.Point(179, 361);
            this.simpleLed1.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.simpleLed1.Name = "simpleLed1";
            this.simpleLed1.Size = new System.Drawing.Size(42, 46);
            this.simpleLed1.State = false;
            this.simpleLed1.TabIndex = 108;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(286, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 26);
            this.label10.TabIndex = 106;
            this.label10.Text = "故障状态";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Mode
            // 
            this.btn_Mode.BackColor = System.Drawing.Color.Transparent;
            this.btn_Mode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Mode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Mode.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Mode.ForeColor = System.Drawing.Color.White;
            this.btn_Mode.Location = new System.Drawing.Point(143, 296);
            this.btn_Mode.Name = "btn_Mode";
            this.btn_Mode.Size = new System.Drawing.Size(113, 46);
            this.btn_Mode.TabIndex = 107;
            this.btn_Mode.Text = "手动模式";
            this.btn_Mode.UseVisualStyleBackColor = false;
            this.btn_Mode.Click += new System.EventHandler(this.btn_Mode_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackColor = System.Drawing.Color.Transparent;
            this.btn_Stop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Stop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Stop.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Stop.ForeColor = System.Drawing.Color.White;
            this.btn_Stop.Location = new System.Drawing.Point(402, 296);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(113, 46);
            this.btn_Stop.TabIndex = 105;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // textShow4
            // 
            this.textShow4.BackColor = System.Drawing.Color.Transparent;
            this.textShow4.BindVarName = null;
            this.textShow4.BorderColor = System.Drawing.Color.Transparent;
            this.textShow4.BorderWidth = 2;
            this.textShow4.CurrentValue = "12.34";
            this.textShow4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textShow4.ForeColor = System.Drawing.Color.White;
            this.textShow4.Location = new System.Drawing.Point(143, 230);
            this.textShow4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow4.Name = "textShow4";
            this.textShow4.Size = new System.Drawing.Size(154, 62);
            this.textShow4.TabIndex = 106;
            this.textShow4.Unit = "℃";
            // 
            // btn_Run
            // 
            this.btn_Run.BackColor = System.Drawing.Color.Transparent;
            this.btn_Run.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Run.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Run.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Run.ForeColor = System.Drawing.Color.White;
            this.btn_Run.Location = new System.Drawing.Point(275, 296);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(113, 46);
            this.btn_Run.TabIndex = 104;
            this.btn_Run.Text = "启动";
            this.btn_Run.UseVisualStyleBackColor = false;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // textShow3
            // 
            this.textShow3.BackColor = System.Drawing.Color.Transparent;
            this.textShow3.BindVarName = null;
            this.textShow3.BorderColor = System.Drawing.Color.Transparent;
            this.textShow3.BorderWidth = 2;
            this.textShow3.CurrentValue = "12.34";
            this.textShow3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textShow3.ForeColor = System.Drawing.Color.White;
            this.textShow3.Location = new System.Drawing.Point(143, 183);
            this.textShow3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow3.Name = "textShow3";
            this.textShow3.Size = new System.Drawing.Size(154, 52);
            this.textShow3.TabIndex = 105;
            this.textShow3.Unit = "Kwh";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(292, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 26);
            this.label9.TabIndex = 100;
            this.label9.Text = "冷却泵运行事件";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textShow2
            // 
            this.textShow2.BackColor = System.Drawing.Color.Transparent;
            this.textShow2.BindVarName = null;
            this.textShow2.BorderColor = System.Drawing.Color.Transparent;
            this.textShow2.BorderWidth = 2;
            this.textShow2.CurrentValue = "12.34";
            this.textShow2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textShow2.ForeColor = System.Drawing.Color.White;
            this.textShow2.Location = new System.Drawing.Point(143, 134);
            this.textShow2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow2.Name = "textShow2";
            this.textShow2.Size = new System.Drawing.Size(154, 52);
            this.textShow2.TabIndex = 104;
            this.textShow2.Unit = "r/min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(294, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 26);
            this.label8.TabIndex = 99;
            this.label8.Text = "冷却泵功率";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textShow1
            // 
            this.textShow1.BackColor = System.Drawing.Color.Transparent;
            this.textShow1.BindVarName = "LQB1_Current";
            this.textShow1.BorderColor = System.Drawing.Color.Transparent;
            this.textShow1.BorderWidth = 2;
            this.textShow1.CurrentValue = "12.34";
            this.textShow1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textShow1.ForeColor = System.Drawing.Color.White;
            this.textShow1.Location = new System.Drawing.Point(143, 79);
            this.textShow1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow1.Name = "textShow1";
            this.textShow1.Size = new System.Drawing.Size(154, 52);
            this.textShow1.TabIndex = 103;
            this.textShow1.Unit = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(295, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 26);
            this.label7.TabIndex = 98;
            this.label7.Text = "冷却泵频率";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(23, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 26);
            this.label6.TabIndex = 102;
            this.label6.Text = "运行状态";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textShow5
            // 
            this.textShow5.BackColor = System.Drawing.Color.Transparent;
            this.textShow5.BindVarName = "LQB1_Fre";
            this.textShow5.BorderColor = System.Drawing.Color.Transparent;
            this.textShow5.BorderWidth = 2;
            this.textShow5.CurrentValue = "12.34";
            this.textShow5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textShow5.ForeColor = System.Drawing.Color.White;
            this.textShow5.Location = new System.Drawing.Point(403, 83);
            this.textShow5.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow5.Name = "textShow5";
            this.textShow5.Size = new System.Drawing.Size(154, 52);
            this.textShow5.TabIndex = 101;
            this.textShow5.Unit = "Hz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(23, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 26);
            this.label5.TabIndex = 101;
            this.label5.Text = "模式切换";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textShow6
            // 
            this.textShow6.BackColor = System.Drawing.Color.Transparent;
            this.textShow6.BindVarName = null;
            this.textShow6.BorderColor = System.Drawing.Color.Transparent;
            this.textShow6.BorderWidth = 2;
            this.textShow6.CurrentValue = "12.34";
            this.textShow6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textShow6.ForeColor = System.Drawing.Color.White;
            this.textShow6.Location = new System.Drawing.Point(403, 141);
            this.textShow6.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow6.Name = "textShow6";
            this.textShow6.Size = new System.Drawing.Size(154, 52);
            this.textShow6.TabIndex = 102;
            this.textShow6.Unit = "KW";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(23, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 26);
            this.label4.TabIndex = 100;
            this.label4.Text = "加热器温度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textShow7
            // 
            this.textShow7.BackColor = System.Drawing.Color.Transparent;
            this.textShow7.BindVarName = null;
            this.textShow7.BorderColor = System.Drawing.Color.Transparent;
            this.textShow7.BorderWidth = 2;
            this.textShow7.CurrentValue = "12.34";
            this.textShow7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textShow7.ForeColor = System.Drawing.Color.White;
            this.textShow7.Location = new System.Drawing.Point(403, 199);
            this.textShow7.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow7.Name = "textShow7";
            this.textShow7.Size = new System.Drawing.Size(154, 52);
            this.textShow7.TabIndex = 103;
            this.textShow7.Unit = "h";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(23, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 26);
            this.label3.TabIndex = 99;
            this.label3.Text = "冷却泵耗电量";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(23, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 26);
            this.label2.TabIndex = 98;
            this.label2.Text = "冷却泵转速";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(23, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 97;
            this.label1.Text = "冷却泵电流";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 453);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmPump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmPumpControl";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEnhanced1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_Title;
        private thinger.ControlLib.SimpleLed simpleLed2;
        private thinger.ControlLib.SimpleLed simpleLed1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Mode;
        private System.Windows.Forms.Button btn_Stop;
        private thinger.ControlLib.TextShow textShow4;
        private System.Windows.Forms.Button btn_Run;
        private thinger.ControlLib.TextShow textShow3;
        private System.Windows.Forms.Label label9;
        private thinger.ControlLib.TextShow textShow2;
        private System.Windows.Forms.Label label8;
        private thinger.ControlLib.TextShow textShow1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private thinger.ControlLib.TextShow textShow5;
        private System.Windows.Forms.Label label5;
        private thinger.ControlLib.TextShow textShow6;
        private System.Windows.Forms.Label label4;
        private thinger.ControlLib.TextShow textShow7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}