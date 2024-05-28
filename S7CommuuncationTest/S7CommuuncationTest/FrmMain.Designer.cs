namespace S7CommuuncationTest
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Conn = new System.Windows.Forms.Button();
            this.btn_FristComfirm = new System.Windows.Forms.Button();
            this.btn_SecondComfirm = new System.Windows.Forms.Button();
            this.btn_DisConn = new System.Windows.Forms.Button();
            this.btn_ReadVariable = new System.Windows.Forms.Button();
            this.rtb_Info = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_Conn
            // 
            this.btn_Conn.Location = new System.Drawing.Point(33, 68);
            this.btn_Conn.Name = "btn_Conn";
            this.btn_Conn.Size = new System.Drawing.Size(126, 39);
            this.btn_Conn.TabIndex = 0;
            this.btn_Conn.Text = "Socket连接";
            this.btn_Conn.UseVisualStyleBackColor = true;
            this.btn_Conn.Click += new System.EventHandler(this.btn_Conn_Click);
            // 
            // btn_FristComfirm
            // 
            this.btn_FristComfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_FristComfirm.Location = new System.Drawing.Point(33, 152);
            this.btn_FristComfirm.Name = "btn_FristComfirm";
            this.btn_FristComfirm.Size = new System.Drawing.Size(126, 39);
            this.btn_FristComfirm.TabIndex = 1;
            this.btn_FristComfirm.Text = "一次认证";
            this.btn_FristComfirm.UseVisualStyleBackColor = true;
            this.btn_FristComfirm.Click += new System.EventHandler(this.btn_FristComfirm_Click);
            // 
            // btn_SecondComfirm
            // 
            this.btn_SecondComfirm.Location = new System.Drawing.Point(33, 236);
            this.btn_SecondComfirm.Name = "btn_SecondComfirm";
            this.btn_SecondComfirm.Size = new System.Drawing.Size(126, 39);
            this.btn_SecondComfirm.TabIndex = 2;
            this.btn_SecondComfirm.Text = "二次认证";
            this.btn_SecondComfirm.UseVisualStyleBackColor = true;
            this.btn_SecondComfirm.Click += new System.EventHandler(this.btn_SecondComfirm_Click);
            // 
            // btn_DisConn
            // 
            this.btn_DisConn.Location = new System.Drawing.Point(33, 404);
            this.btn_DisConn.Name = "btn_DisConn";
            this.btn_DisConn.Size = new System.Drawing.Size(126, 39);
            this.btn_DisConn.TabIndex = 3;
            this.btn_DisConn.Text = "Socket断开";
            this.btn_DisConn.UseVisualStyleBackColor = true;
            // 
            // btn_ReadVariable
            // 
            this.btn_ReadVariable.Location = new System.Drawing.Point(33, 320);
            this.btn_ReadVariable.Name = "btn_ReadVariable";
            this.btn_ReadVariable.Size = new System.Drawing.Size(126, 39);
            this.btn_ReadVariable.TabIndex = 4;
            this.btn_ReadVariable.Text = "读取变量";
            this.btn_ReadVariable.UseVisualStyleBackColor = true;
            this.btn_ReadVariable.Click += new System.EventHandler(this.btn_ReadVariable_Click);
            // 
            // rtb_Info
            // 
            this.rtb_Info.Location = new System.Drawing.Point(203, 74);
            this.rtb_Info.Name = "rtb_Info";
            this.rtb_Info.Size = new System.Drawing.Size(432, 368);
            this.rtb_Info.TabIndex = 5;
            this.rtb_Info.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 570);
            this.Controls.Add(this.rtb_Info);
            this.Controls.Add(this.btn_ReadVariable);
            this.Controls.Add(this.btn_DisConn);
            this.Controls.Add(this.btn_SecondComfirm);
            this.Controls.Add(this.btn_FristComfirm);
            this.Controls.Add(this.btn_Conn);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FrmMain";
            this.Text = "S7通信";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Conn;
        private System.Windows.Forms.Button btn_FristComfirm;
        private System.Windows.Forms.Button btn_SecondComfirm;
        private System.Windows.Forms.Button btn_DisConn;
        private System.Windows.Forms.Button btn_ReadVariable;
        private System.Windows.Forms.RichTextBox rtb_Info;
    }
}

