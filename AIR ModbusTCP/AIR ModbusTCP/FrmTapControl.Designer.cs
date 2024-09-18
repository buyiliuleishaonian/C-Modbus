namespace AIR_ModbusTCP
{
    partial class FrmTapControl
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
            this.deviceControl9 = new Wen.KYJControlLib.DeviceControl();
            this.deviceControl10 = new Wen.KYJControlLib.DeviceControl();
            this.deviceControl7 = new Wen.KYJControlLib.DeviceControl();
            this.deviceControl8 = new Wen.KYJControlLib.DeviceControl();
            this.deviceControl5 = new Wen.KYJControlLib.DeviceControl();
            this.deviceControl6 = new Wen.KYJControlLib.DeviceControl();
            this.deviceControl3 = new Wen.KYJControlLib.DeviceControl();
            this.deviceControl4 = new Wen.KYJControlLib.DeviceControl();
            this.deviceControl2 = new Wen.KYJControlLib.DeviceControl();
            this.deviceControl1 = new Wen.KYJControlLib.DeviceControl();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::AIR_ModbusTCP.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.deviceControl9);
            this.panelEnhanced1.Controls.Add(this.deviceControl10);
            this.panelEnhanced1.Controls.Add(this.deviceControl7);
            this.panelEnhanced1.Controls.Add(this.deviceControl8);
            this.panelEnhanced1.Controls.Add(this.deviceControl5);
            this.panelEnhanced1.Controls.Add(this.deviceControl6);
            this.panelEnhanced1.Controls.Add(this.deviceControl3);
            this.panelEnhanced1.Controls.Add(this.deviceControl4);
            this.panelEnhanced1.Controls.Add(this.deviceControl2);
            this.panelEnhanced1.Controls.Add(this.deviceControl1);
            this.panelEnhanced1.Controls.Add(this.btn_Close);
            this.panelEnhanced1.Controls.Add(this.lbl_Title);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(781, 383);
            this.panelEnhanced1.TabIndex = 0;
            // 
            // deviceControl9
            // 
            this.deviceControl9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl9.BindVarName = "3#储气罐出气阀";
            this.deviceControl9.CloseAddress = "CQG3Out_Close";
            this.deviceControl9.DeviceState = "CQG3Out_State";
            this.deviceControl9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl9.Location = new System.Drawing.Point(388, 319);
            this.deviceControl9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl9.Name = "deviceControl9";
            this.deviceControl9.OpenAddress = "CQG3Out_Open";
            this.deviceControl9.Size = new System.Drawing.Size(360, 44);
            this.deviceControl9.State = ((byte)(0));
            this.deviceControl9.TabIndex = 74;
            this.deviceControl9.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
            // 
            // deviceControl10
            // 
            this.deviceControl10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl10.BindVarName = "3#干燥机进液阀";
            this.deviceControl10.CloseAddress = "GZQ3Out_Close";
            this.deviceControl10.DeviceState = "GZQ3Out_State";
            this.deviceControl10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl10.Location = new System.Drawing.Point(6, 319);
            this.deviceControl10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl10.Name = "deviceControl10";
            this.deviceControl10.OpenAddress = "GZQ3Out_Open";
            this.deviceControl10.Size = new System.Drawing.Size(360, 44);
            this.deviceControl10.State = ((byte)(0));
            this.deviceControl10.TabIndex = 73;
            this.deviceControl10.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
            // 
            // deviceControl7
            // 
            this.deviceControl7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl7.BindVarName = "2#储气罐出气阀";
            this.deviceControl7.CloseAddress = "CQG2Out_Close";
            this.deviceControl7.DeviceState = "CQG2Out_State";
            this.deviceControl7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl7.Location = new System.Drawing.Point(388, 257);
            this.deviceControl7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl7.Name = "deviceControl7";
            this.deviceControl7.OpenAddress = "CQG2Out_Open";
            this.deviceControl7.Size = new System.Drawing.Size(360, 44);
            this.deviceControl7.State = ((byte)(0));
            this.deviceControl7.TabIndex = 72;
            this.deviceControl7.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
            // 
            // deviceControl8
            // 
            this.deviceControl8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl8.BindVarName = "2#干燥机进液阀";
            this.deviceControl8.CloseAddress = "GZQ2Out_Close";
            this.deviceControl8.DeviceState = "GZQ2Out_State";
            this.deviceControl8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl8.Location = new System.Drawing.Point(6, 257);
            this.deviceControl8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl8.Name = "deviceControl8";
            this.deviceControl8.OpenAddress = "GZQ2Out_Open";
            this.deviceControl8.Size = new System.Drawing.Size(360, 44);
            this.deviceControl8.State = ((byte)(0));
            this.deviceControl8.TabIndex = 71;
            this.deviceControl8.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
            // 
            // deviceControl5
            // 
            this.deviceControl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl5.BindVarName = "1#储气罐出气阀";
            this.deviceControl5.CloseAddress = "CQG1Out_Close";
            this.deviceControl5.DeviceState = "CQG1Out_State";
            this.deviceControl5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl5.Location = new System.Drawing.Point(388, 195);
            this.deviceControl5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl5.Name = "deviceControl5";
            this.deviceControl5.OpenAddress = "CQG1Out_Open";
            this.deviceControl5.Size = new System.Drawing.Size(360, 44);
            this.deviceControl5.State = ((byte)(0));
            this.deviceControl5.TabIndex = 70;
            this.deviceControl5.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
            // 
            // deviceControl6
            // 
            this.deviceControl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl6.BindVarName = "1#干燥机进液阀";
            this.deviceControl6.CloseAddress = "GZQ1Out_Close";
            this.deviceControl6.DeviceState = "GZQ1Out_State";
            this.deviceControl6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl6.Location = new System.Drawing.Point(6, 195);
            this.deviceControl6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl6.Name = "deviceControl6";
            this.deviceControl6.OpenAddress = "GZQ1Out_Open";
            this.deviceControl6.Size = new System.Drawing.Size(360, 44);
            this.deviceControl6.State = ((byte)(0));
            this.deviceControl6.TabIndex = 69;
            this.deviceControl6.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
            // 
            // deviceControl3
            // 
            this.deviceControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl3.BindVarName = "4#空压机进液阀";
            this.deviceControl3.CloseAddress = "KYJ4In_Close";
            this.deviceControl3.DeviceState = "KYJ4In_State";
            this.deviceControl3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl3.Location = new System.Drawing.Point(388, 133);
            this.deviceControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl3.Name = "deviceControl3";
            this.deviceControl3.OpenAddress = "KYJ4In_Open";
            this.deviceControl3.Size = new System.Drawing.Size(360, 44);
            this.deviceControl3.State = ((byte)(0));
            this.deviceControl3.TabIndex = 68;
            this.deviceControl3.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
            // 
            // deviceControl4
            // 
            this.deviceControl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl4.BindVarName = "3#空压机进液阀";
            this.deviceControl4.CloseAddress = "KYJ3In_Close";
            this.deviceControl4.DeviceState = "KYJ3In_State";
            this.deviceControl4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl4.Location = new System.Drawing.Point(6, 133);
            this.deviceControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl4.Name = "deviceControl4";
            this.deviceControl4.OpenAddress = "KYJ3In_Open";
            this.deviceControl4.Size = new System.Drawing.Size(360, 44);
            this.deviceControl4.State = ((byte)(0));
            this.deviceControl4.TabIndex = 67;
            this.deviceControl4.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
            // 
            // deviceControl2
            // 
            this.deviceControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl2.BindVarName = "2#空压机进液阀";
            this.deviceControl2.CloseAddress = "KYJ2In_Close";
            this.deviceControl2.DeviceState = "KYJ2In_State";
            this.deviceControl2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl2.Location = new System.Drawing.Point(388, 71);
            this.deviceControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl2.Name = "deviceControl2";
            this.deviceControl2.OpenAddress = "KYJ2In_Open";
            this.deviceControl2.Size = new System.Drawing.Size(360, 44);
            this.deviceControl2.State = ((byte)(0));
            this.deviceControl2.TabIndex = 66;
            this.deviceControl2.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
            // 
            // deviceControl1
            // 
            this.deviceControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deviceControl1.BindVarName = "1#空压机进液阀";
            this.deviceControl1.CloseAddress = "KYJ1In_Close";
            this.deviceControl1.DeviceState = "KYJ1In_State";
            this.deviceControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceControl1.Location = new System.Drawing.Point(6, 71);
            this.deviceControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceControl1.Name = "deviceControl1";
            this.deviceControl1.OpenAddress = "KYJ1In_Open";
            this.deviceControl1.Size = new System.Drawing.Size(360, 44);
            this.deviceControl1.State = ((byte)(0));
            this.deviceControl1.TabIndex = 65;
            this.deviceControl1.DeviceControlClick += new System.EventHandler(this.DeviceCommon_DeviceControlClick);
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
            this.btn_Close.Location = new System.Drawing.Point(722, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(56, 46);
            this.btn_Close.TabIndex = 64;
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
            this.lbl_Title.Location = new System.Drawing.Point(12, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(131, 26);
            this.lbl_Title.TabIndex = 63;
            this.lbl_Title.Text = "1#冷却循环泵";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmTapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 383);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmTapControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTapControl";
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEnhanced1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private Wen.KYJControlLib.DeviceControl deviceControl9;
        private Wen.KYJControlLib.DeviceControl deviceControl10;
        private Wen.KYJControlLib.DeviceControl deviceControl7;
        private Wen.KYJControlLib.DeviceControl deviceControl8;
        private Wen.KYJControlLib.DeviceControl deviceControl5;
        private Wen.KYJControlLib.DeviceControl deviceControl6;
        private Wen.KYJControlLib.DeviceControl deviceControl3;
        private Wen.KYJControlLib.DeviceControl deviceControl4;
        private Wen.KYJControlLib.DeviceControl deviceControl2;
        private Wen.KYJControlLib.DeviceControl deviceControl1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_Title;
    }
}