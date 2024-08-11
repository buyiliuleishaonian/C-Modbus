namespace AIR_CompressorModbusRTU
{
    partial class FrmSelectParam
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
            this.btn_DelAll = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_AddAll = new System.Windows.Forms.Button();
            this.btN_Add = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lst_Selectparam = new System.Windows.Forms.ListBox();
            this.lst_UnListparam = new System.Windows.Forms.ListBox();
            this.panelEnhanced1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnhanced1
            // 
            this.panelEnhanced1.BackgroundImage = global::AIR_CompressorModbusRTU.Properties.Resources.background;
            this.panelEnhanced1.Controls.Add(this.btn_No);
            this.panelEnhanced1.Controls.Add(this.btn_OK);
            this.panelEnhanced1.Controls.Add(this.btn_DelAll);
            this.panelEnhanced1.Controls.Add(this.btn_Delete);
            this.panelEnhanced1.Controls.Add(this.btn_AddAll);
            this.panelEnhanced1.Controls.Add(this.btN_Add);
            this.panelEnhanced1.Controls.Add(this.lbl_Title);
            this.panelEnhanced1.Controls.Add(this.lst_Selectparam);
            this.panelEnhanced1.Controls.Add(this.lst_UnListparam);
            this.panelEnhanced1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.panelEnhanced1.Name = "panelEnhanced1";
            this.panelEnhanced1.Size = new System.Drawing.Size(557, 453);
            this.panelEnhanced1.TabIndex = 0;
            this.panelEnhanced1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panelEnhanced1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_No
            // 
            this.btn_No.BackColor = System.Drawing.Color.Transparent;
            this.btn_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_No.ForeColor = System.Drawing.Color.White;
            this.btn_No.Location = new System.Drawing.Point(335, 395);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(150, 46);
            this.btn_No.TabIndex = 8;
            this.btn_No.Text = "取消选择";
            this.btn_No.UseVisualStyleBackColor = false;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.ForeColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(63, 395);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(150, 46);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "确认参数";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_DelAll
            // 
            this.btn_DelAll.BackColor = System.Drawing.Color.Transparent;
            this.btn_DelAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DelAll.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DelAll.ForeColor = System.Drawing.Color.White;
            this.btn_DelAll.Location = new System.Drawing.Point(244, 306);
            this.btn_DelAll.Name = "btn_DelAll";
            this.btn_DelAll.Size = new System.Drawing.Size(65, 65);
            this.btn_DelAll.TabIndex = 6;
            this.btn_DelAll.Text = "＜＜";
            this.btn_DelAll.UseVisualStyleBackColor = false;
            this.btn_DelAll.Click += new System.EventHandler(this.btn_DelAll_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(244, 236);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(65, 65);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "＜";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_AddAll
            // 
            this.btn_AddAll.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddAll.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddAll.ForeColor = System.Drawing.Color.White;
            this.btn_AddAll.Location = new System.Drawing.Point(244, 166);
            this.btn_AddAll.Name = "btn_AddAll";
            this.btn_AddAll.Size = new System.Drawing.Size(65, 65);
            this.btn_AddAll.TabIndex = 4;
            this.btn_AddAll.Text = "＞＞";
            this.btn_AddAll.UseVisualStyleBackColor = false;
            this.btn_AddAll.Click += new System.EventHandler(this.btn_AddAll_Click);
            // 
            // btN_Add
            // 
            this.btN_Add.BackColor = System.Drawing.Color.Transparent;
            this.btN_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btN_Add.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btN_Add.ForeColor = System.Drawing.Color.White;
            this.btN_Add.Location = new System.Drawing.Point(244, 96);
            this.btN_Add.Name = "btN_Add";
            this.btN_Add.Size = new System.Drawing.Size(65, 65);
            this.btN_Add.TabIndex = 3;
            this.btN_Add.Text = "＞";
            this.btN_Add.UseVisualStyleBackColor = false;
            this.btN_Add.Click += new System.EventHandler(this.btN_Add_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(13, 25);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(88, 26);
            this.lbl_Title.TabIndex = 2;
            this.lbl_Title.Text = "参数选择";
            // 
            // lst_Selectparam
            // 
            this.lst_Selectparam.FormattingEnabled = true;
            this.lst_Selectparam.ItemHeight = 25;
            this.lst_Selectparam.Location = new System.Drawing.Point(346, 96);
            this.lst_Selectparam.Name = "lst_Selectparam";
            this.lst_Selectparam.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_Selectparam.Size = new System.Drawing.Size(199, 279);
            this.lst_Selectparam.TabIndex = 1;
            // 
            // lst_UnListparam
            // 
            this.lst_UnListparam.FormattingEnabled = true;
            this.lst_UnListparam.ItemHeight = 25;
            this.lst_UnListparam.Location = new System.Drawing.Point(14, 96);
            this.lst_UnListparam.Name = "lst_UnListparam";
            this.lst_UnListparam.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_UnListparam.Size = new System.Drawing.Size(199, 279);
            this.lst_UnListparam.TabIndex = 0;
            // 
            // FrmSelectParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 453);
            this.Controls.Add(this.panelEnhanced1);
            this.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmSelectParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmSelectParam";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.panelEnhanced1.ResumeLayout(false);
            this.panelEnhanced1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private thinger.ControlLib.PanelEnhanced panelEnhanced1;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.ListBox lst_Selectparam;
        private System.Windows.Forms.ListBox lst_UnListparam;
        private System.Windows.Forms.Button btN_Add;
        private System.Windows.Forms.Button btn_AddAll;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_DelAll;
    }
}