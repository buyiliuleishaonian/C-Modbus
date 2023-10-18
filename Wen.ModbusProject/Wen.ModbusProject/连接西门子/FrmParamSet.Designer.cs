namespace Wen.ModbusProject.连接西门子
{
    partial class FrmParamSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParamSet));
            this.lbl_Value = new System.Windows.Forms.Label();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.lbl_SetParam = new System.Windows.Forms.Label();
            this.txtPerSet = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_VarValue = new System.Windows.Forms.Label();
            this.lbl_VarDataType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Value
            // 
            this.lbl_Value.AutoSize = true;
            this.lbl_Value.Location = new System.Drawing.Point(27, 36);
            this.lbl_Value.Name = "lbl_Value";
            this.lbl_Value.Size = new System.Drawing.Size(94, 21);
            this.lbl_Value.TabIndex = 0;
            this.lbl_Value.Text = "数据参数";
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Location = new System.Drawing.Point(27, 93);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(94, 21);
            this.lbl_Type.TabIndex = 1;
            this.lbl_Type.Text = "数据类型";
            // 
            // lbl_SetParam
            // 
            this.lbl_SetParam.AutoSize = true;
            this.lbl_SetParam.Location = new System.Drawing.Point(27, 150);
            this.lbl_SetParam.Name = "lbl_SetParam";
            this.lbl_SetParam.Size = new System.Drawing.Size(94, 21);
            this.lbl_SetParam.TabIndex = 2;
            this.lbl_SetParam.Text = "设置参数";
            // 
            // txtPerSet
            // 
            this.txtPerSet.Location = new System.Drawing.Point(154, 140);
            this.txtPerSet.Name = "txtPerSet";
            this.txtPerSet.Size = new System.Drawing.Size(133, 31);
            this.txtPerSet.TabIndex = 3;
            this.txtPerSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPerSet_KeyDown);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(14, 211);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(107, 40);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "写入";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(194, 211);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(107, 40);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_VarValue
            // 
            this.lbl_VarValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_VarValue.Location = new System.Drawing.Point(154, 36);
            this.lbl_VarValue.Name = "lbl_VarValue";
            this.lbl_VarValue.Size = new System.Drawing.Size(133, 36);
            this.lbl_VarValue.TabIndex = 6;
            this.lbl_VarValue.Text = "0.0";
            this.lbl_VarValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_VarDataType
            // 
            this.lbl_VarDataType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_VarDataType.Location = new System.Drawing.Point(154, 88);
            this.lbl_VarDataType.Name = "lbl_VarDataType";
            this.lbl_VarDataType.Size = new System.Drawing.Size(133, 36);
            this.lbl_VarDataType.TabIndex = 7;
            this.lbl_VarDataType.Text = "float";
            this.lbl_VarDataType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmParamSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 287);
            this.Controls.Add(this.lbl_VarDataType);
            this.Controls.Add(this.lbl_VarValue);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txtPerSet);
            this.Controls.Add(this.lbl_SetParam);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.lbl_Value);
            this.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "FrmParamSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Value;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.Label lbl_SetParam;
        private System.Windows.Forms.TextBox txtPerSet;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_VarValue;
        private System.Windows.Forms.Label lbl_VarDataType;
    }
}