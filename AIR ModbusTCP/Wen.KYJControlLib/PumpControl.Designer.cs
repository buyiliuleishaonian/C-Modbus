namespace Wen.KYJControlLib
{
    partial class PumpControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPic
            // 
            this.MainPic.BackColor = System.Drawing.Color.Transparent;
            this.MainPic.BackgroundImage = global::Wen.KYJControlLib.Properties.Resources.PumpStop;
            this.MainPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPic.Location = new System.Drawing.Point(0, 0);
            this.MainPic.Name = "MainPic";
            this.MainPic.Size = new System.Drawing.Size(126, 77);
            this.MainPic.TabIndex = 0;
            this.MainPic.TabStop = false;
            this.MainPic.DoubleClick += new System.EventHandler(this.MainPic_DoubleClick);
            // 
            // PumpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.MainPic);
            this.Name = "PumpControl";
            this.Size = new System.Drawing.Size(126, 77);
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPic;
    }
}
