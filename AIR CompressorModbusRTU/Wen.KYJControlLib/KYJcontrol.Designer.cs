namespace Wen.KYJControlLib
{
    partial class KYJcontrol
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
            this.KYJpic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.KYJpic)).BeginInit();
            this.SuspendLayout();
            // 
            // KYJpic
            // 
            this.KYJpic.BackgroundImage = global::Wen.KYJControlLib.Properties.Resources.KYJStop;
            this.KYJpic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KYJpic.Location = new System.Drawing.Point(0, 0);
            this.KYJpic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KYJpic.Name = "KYJpic";
            this.KYJpic.Size = new System.Drawing.Size(126, 100);
            this.KYJpic.TabIndex = 0;
            this.KYJpic.TabStop = false;
            // 
            // KYJcontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.KYJpic);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KYJcontrol";
            this.Size = new System.Drawing.Size(126, 100);
            ((System.ComponentModel.ISupportInitialize)(this.KYJpic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox KYJpic;
    }
}
