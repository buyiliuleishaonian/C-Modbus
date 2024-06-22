namespace AIR_CompressorModbusRTU
{
    partial class FrmPumpControl
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
            this.panelEnhanced1 = new thinger.ControlLib.PanelEnhanced();
            this.led2 = new thinger.ControlLib.Led();
            this.label10 = new System.Windows.Forms.Label();
            this.led1 = new thinger.ControlLib.Led();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Manual = new System.Windows.Forms.Button();
            this.textShow4 = new thinger.ControlLib.TextShow();
            this.textShow3 = new thinger.ControlLib.TextShow();
            this.textShow2 = new thinger.ControlLib.TextShow();
            this.textShow1 = new thinger.ControlLib.TextShow();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.textShow5 = new thinger.ControlLib.TextShow();
            this.textShow6 = new thinger.ControlLib.TextShow();
            this.textShow7 = new thinger.ControlLib.TextShow();
            this.panelEnhanced1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackColor = System.Drawing.Color.Transparent;
            this.panelEnhanced1.BackgroundImage = global::AIR_CompressorModbusRTU.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.led2);
            this.panelEnhanced1.Controls.Add(this.label10);
            this.panelEnhanced1.Controls.Add(this.led1);
            this.panelEnhanced1.Controls.Add(this.button3);
            this.panelEnhanced1.Controls.Add(this.button2);
            this.panelEnhanced1.Controls.Add(this.btn_Manual);
            this.panelEnhanced1.Controls.Add(this.textShow4);
            this.panelEnhanced1.Controls.Add(this.textShow3);
            this.panelEnhanced1.Controls.Add(this.textShow2);
            this.panelEnhanced1.Controls.Add(this.textShow1);
            this.panelEnhanced1.Controls.Add(this.label9);
            this.panelEnhanced1.Controls.Add(this.label8);
            this.panelEnhanced1.Controls.Add(this.label7);
            this.panelEnhanced1.Controls.Add(this.label6);
            this.panelEnhanced1.Controls.Add(this.label5);
            this.panelEnhanced1.Controls.Add(this.label4);
            this.panelEnhanced1.Controls.Add(this.label3);
            this.panelEnhanced1.Controls.Add(this.label2);
            this.panelEnhanced1.Controls.Add(this.label1);
            this.panelEnhanced1.Controls.Add(this.btn_Close);
            this.panelEnhanced1.Controls.Add(this.lbl_Title);
            this.panelEnhanced1.Controls.Add(this.textShow5);
            this.panelEnhanced1.Controls.Add(this.textShow6);
            this.panelEnhanced1.Controls.Add(this.textShow7);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(546, 435);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // led2
            // 
            this.led2.BackColor = System.Drawing.Color.Transparent;
            this.led2.BlinkVelocity = 200;
            this.led2.BorderWidth = 5;
            this.led2.CenterColor = System.Drawing.Color.White;
            this.led2.ColorList = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Green};
            this.led2.CurrentValue = 0;
            this.led2.DefaultColor = System.Drawing.Color.Gray;
            this.led2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.led2.GapWidth = 5;
            this.led2.IsBlink = false;
            this.led2.IsBorder = false;
            this.led2.IsHighLight = false;
            this.led2.Location = new System.Drawing.Point(447, 358);
            this.led2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(26, 26);
            this.led2.TabIndex = 96;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(294, 358);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 26);
            this.label10.TabIndex = 95;
            this.label10.Text = "故障状态";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // led1
            // 
            this.led1.BackColor = System.Drawing.Color.Transparent;
            this.led1.BlinkVelocity = 200;
            this.led1.BorderWidth = 5;
            this.led1.CenterColor = System.Drawing.Color.White;
            this.led1.ColorList = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Green};
            this.led1.CurrentValue = 0;
            this.led1.DefaultColor = System.Drawing.Color.Gray;
            this.led1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.led1.GapWidth = 5;
            this.led1.IsBlink = false;
            this.led1.IsBorder = false;
            this.led1.IsHighLight = false;
            this.led1.Location = new System.Drawing.Point(173, 358);
            this.led1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(26, 26);
            this.led1.TabIndex = 94;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(410, 293);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 46);
            this.button3.TabIndex = 93;
            this.button3.Text = "停止";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(271, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 46);
            this.button2.TabIndex = 92;
            this.button2.Text = "启动";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btn_Manual
            // 
            this.btn_Manual.BackColor = System.Drawing.Color.Transparent;
            this.btn_Manual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Manual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Manual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Manual.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Manual.ForeColor = System.Drawing.Color.White;
            this.btn_Manual.Location = new System.Drawing.Point(132, 293);
            this.btn_Manual.Name = "btn_Manual";
            this.btn_Manual.Size = new System.Drawing.Size(113, 46);
            this.btn_Manual.TabIndex = 91;
            this.btn_Manual.Text = "手动模式";
            this.btn_Manual.UseVisualStyleBackColor = false;
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
            this.textShow4.Location = new System.Drawing.Point(132, 227);
            this.textShow4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow4.Name = "textShow4";
            this.textShow4.Size = new System.Drawing.Size(154, 62);
            this.textShow4.TabIndex = 87;
            this.textShow4.Unit = "℃";
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
            this.textShow3.Location = new System.Drawing.Point(132, 180);
            this.textShow3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow3.Name = "textShow3";
            this.textShow3.Size = new System.Drawing.Size(154, 52);
            this.textShow3.TabIndex = 86;
            this.textShow3.Unit = "℃";
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
            this.textShow2.Location = new System.Drawing.Point(132, 131);
            this.textShow2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow2.Name = "textShow2";
            this.textShow2.Size = new System.Drawing.Size(154, 52);
            this.textShow2.TabIndex = 85;
            this.textShow2.Unit = "℃";
            // 
            // textShow1
            // 
            this.textShow1.BackColor = System.Drawing.Color.Transparent;
            this.textShow1.BindVarName = null;
            this.textShow1.BorderColor = System.Drawing.Color.Transparent;
            this.textShow1.BorderWidth = 2;
            this.textShow1.CurrentValue = "12.34";
            this.textShow1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textShow1.ForeColor = System.Drawing.Color.White;
            this.textShow1.Location = new System.Drawing.Point(132, 76);
            this.textShow1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow1.Name = "textShow1";
            this.textShow1.Size = new System.Drawing.Size(154, 52);
            this.textShow1.TabIndex = 84;
            this.textShow1.Unit = "℃";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(294, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 26);
            this.label9.TabIndex = 83;
            this.label9.Text = "冷却泵运行事件";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(294, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 26);
            this.label8.TabIndex = 82;
            this.label8.Text = "冷却泵功率";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(294, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 26);
            this.label7.TabIndex = 81;
            this.label7.Text = "冷却泵频率";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(12, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 26);
            this.label6.TabIndex = 80;
            this.label6.Text = "运行状态";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(12, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 26);
            this.label5.TabIndex = 79;
            this.label5.Text = "模式切换";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(12, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 26);
            this.label4.TabIndex = 78;
            this.label4.Text = "加热器温度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(12, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 26);
            this.label3.TabIndex = 77;
            this.label3.Text = "冷却泵耗电量";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 26);
            this.label2.TabIndex = 76;
            this.label2.Text = "冷却泵转速";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 75;
            this.label1.Text = "冷却泵电流";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btn_Close.Location = new System.Drawing.Point(489, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(56, 46);
            this.btn_Close.TabIndex = 74;
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
            this.lbl_Title.Location = new System.Drawing.Point(12, 13);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(131, 26);
            this.lbl_Title.TabIndex = 73;
            this.lbl_Title.Text = "1#冷却循环泵";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textShow5
            // 
            this.textShow5.BackColor = System.Drawing.Color.Transparent;
            this.textShow5.BindVarName = null;
            this.textShow5.BorderColor = System.Drawing.Color.Transparent;
            this.textShow5.BorderWidth = 2;
            this.textShow5.CurrentValue = "12.34";
            this.textShow5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textShow5.ForeColor = System.Drawing.Color.White;
            this.textShow5.Location = new System.Drawing.Point(411, 76);
            this.textShow5.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow5.Name = "textShow5";
            this.textShow5.Size = new System.Drawing.Size(154, 52);
            this.textShow5.TabIndex = 88;
            this.textShow5.Unit = "℃";
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
            this.textShow6.Location = new System.Drawing.Point(411, 134);
            this.textShow6.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow6.Name = "textShow6";
            this.textShow6.Size = new System.Drawing.Size(154, 52);
            this.textShow6.TabIndex = 89;
            this.textShow6.Unit = "℃";
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
            this.textShow7.Location = new System.Drawing.Point(411, 192);
            this.textShow7.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textShow7.Name = "textShow7";
            this.textShow7.Size = new System.Drawing.Size(154, 52);
            this.textShow7.TabIndex = 90;
            this.textShow7.Unit = "℃";
            // 
            // FrmPumpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AIR_CompressorModbusRTU.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(546, 435);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPumpControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPumpControl";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseMove);
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEnhanced1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private thinger.ControlLib.Led led2;
        private System.Windows.Forms.Label label10;
        private thinger.ControlLib.Led led1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_Manual;
        private thinger.ControlLib.TextShow textShow4;
        private thinger.ControlLib.TextShow textShow3;
        private thinger.ControlLib.TextShow textShow2;
        private thinger.ControlLib.TextShow textShow1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_Title;
        private thinger.ControlLib.TextShow textShow5;
        private thinger.ControlLib.TextShow textShow6;
        private thinger.ControlLib.TextShow textShow7;
    }
}