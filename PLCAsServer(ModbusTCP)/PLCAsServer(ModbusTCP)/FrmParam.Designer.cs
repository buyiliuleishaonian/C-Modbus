namespace Wen.PLCAsClientProgram
{
    partial class FrmParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParam));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_CurrentValue = new System.Windows.Forms.Label();
            this.lbl_CurrentDataType = new System.Windows.Forms.Label();
            this.txt_SetValue = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前值:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "修改值:";
            // 
            // lbl_CurrentValue
            // 
            this.lbl_CurrentValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CurrentValue.Location = new System.Drawing.Point(150, 57);
            this.lbl_CurrentValue.Name = "lbl_CurrentValue";
            this.lbl_CurrentValue.Size = new System.Drawing.Size(110, 31);
            this.lbl_CurrentValue.TabIndex = 3;
            this.lbl_CurrentValue.Text = "0.0";
            this.lbl_CurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CurrentDataType
            // 
            this.lbl_CurrentDataType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CurrentDataType.Location = new System.Drawing.Point(150, 120);
            this.lbl_CurrentDataType.Name = "lbl_CurrentDataType";
            this.lbl_CurrentDataType.Size = new System.Drawing.Size(110, 31);
            this.lbl_CurrentDataType.TabIndex = 4;
            this.lbl_CurrentDataType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_SetValue
            // 
            this.txt_SetValue.Location = new System.Drawing.Point(150, 178);
            this.txt_SetValue.Multiline = true;
            this.txt_SetValue.Name = "txt_SetValue";
            this.txt_SetValue.Size = new System.Drawing.Size(105, 35);
            this.txt_SetValue.TabIndex = 5;
            this.txt_SetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(58, 243);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 35);
            this.btn_Update.TabIndex = 6;
            this.btn_Update.Text = "确认修改";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(180, 243);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 35);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "取消修改";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 335);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.txt_SetValue);
            this.Controls.Add(this.lbl_CurrentDataType);
            this.Controls.Add(this.lbl_CurrentValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmParam";
            this.Text = "FrmParam";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmParam_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_CurrentValue;
        private System.Windows.Forms.Label lbl_CurrentDataType;
        private System.Windows.Forms.TextBox txt_SetValue;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Cancel;
    }
}