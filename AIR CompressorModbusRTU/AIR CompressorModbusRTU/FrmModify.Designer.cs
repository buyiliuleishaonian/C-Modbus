﻿namespace AIR_CompressorModbusRTU
{
    partial class FrmModify
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
            this.btn_No = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_VarName = new System.Windows.Forms.Label();
            this.lbl_CurrentValue = new System.Windows.Forms.Label();
            this.txt_VarValueSet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEnhanced1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::AIR_CompressorModbusRTU.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.btn_No);
            this.panelEnhanced1.Controls.Add(this.btn_OK);
            this.panelEnhanced1.Controls.Add(this.btn_Close);
            this.panelEnhanced1.Controls.Add(this.lbl_VarName);
            this.panelEnhanced1.Controls.Add(this.lbl_CurrentValue);
            this.panelEnhanced1.Controls.Add(this.txt_VarValueSet);
            this.panelEnhanced1.Controls.Add(this.label4);
            this.panelEnhanced1.Controls.Add(this.label2);
            this.panelEnhanced1.Controls.Add(this.label1);
            this.panelEnhanced1.Controls.Add(this.label3);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(427, 389);
            this.panelEnhanced1.TabIndex = 0;
            this.panelEnhanced1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseDown);
            this.panelEnhanced1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FraMain_MouseMove);
            // 
            // btn_No
            // 
            this.btn_No.BackColor = System.Drawing.Color.Transparent;
            this.btn_No.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_No.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_No.ForeColor = System.Drawing.Color.White;
            this.btn_No.Location = new System.Drawing.Point(213, 298);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(95, 31);
            this.btn_No.TabIndex = 55;
            this.btn_No.Text = "取消";
            this.btn_No.UseVisualStyleBackColor = false;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.ForeColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(54, 298);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(95, 31);
            this.btn_OK.TabIndex = 54;
            this.btn_OK.Text = "确认";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
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
            this.btn_Close.Location = new System.Drawing.Point(368, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(56, 46);
            this.btn_Close.TabIndex = 53;
            this.btn_Close.Text = "×";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_VarName
            // 
            this.lbl_VarName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_VarName.ForeColor = System.Drawing.Color.White;
            this.lbl_VarName.Location = new System.Drawing.Point(160, 67);
            this.lbl_VarName.Name = "lbl_VarName";
            this.lbl_VarName.Size = new System.Drawing.Size(206, 60);
            this.lbl_VarName.TabIndex = 8;
            this.lbl_VarName.Text = "冷却塔进口压力高限";
            this.lbl_VarName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CurrentValue
            // 
            this.lbl_CurrentValue.AutoSize = true;
            this.lbl_CurrentValue.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CurrentValue.ForeColor = System.Drawing.Color.White;
            this.lbl_CurrentValue.Location = new System.Drawing.Point(217, 163);
            this.lbl_CurrentValue.Name = "lbl_CurrentValue";
            this.lbl_CurrentValue.Size = new System.Drawing.Size(39, 25);
            this.lbl_CurrentValue.TabIndex = 7;
            this.lbl_CurrentValue.Text = "0.0";
            // 
            // txt_VarValueSet
            // 
            this.txt_VarValueSet.Location = new System.Drawing.Point(199, 236);
            this.txt_VarValueSet.Name = "txt_VarValueSet";
            this.txt_VarValueSet.Size = new System.Drawing.Size(100, 33);
            this.txt_VarValueSet.TabIndex = 6;
            this.txt_VarValueSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_VarValueSet.Click += new System.EventHandler(this.txt_VarValueSet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(49, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "修改值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(49, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "当前值";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "参数名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "参数修改";
            // 
            // FrmModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 389);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmModify";
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEnhanced1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_VarName;
        private System.Windows.Forms.Label lbl_CurrentValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_OK;
        internal System.Windows.Forms.TextBox txt_VarValueSet;
    }
}