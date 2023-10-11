namespace Wen.ControlLibs
{
    partial class THMonitor
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
            this.gb_Control = new System.Windows.Forms.GroupBox();
            this.lblTem = new System.Windows.Forms.Label();
            this.lblHum = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.gb_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Control
            // 
            this.gb_Control.Controls.Add(this.lblTem);
            this.gb_Control.Controls.Add(this.lblHum);
            this.gb_Control.Controls.Add(this.lbl2);
            this.gb_Control.Controls.Add(this.lbl1);
            this.gb_Control.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_Control.Location = new System.Drawing.Point(17, 15);
            this.gb_Control.Name = "gb_Control";
            this.gb_Control.Size = new System.Drawing.Size(220, 156);
            this.gb_Control.TabIndex = 29;
            this.gb_Control.TabStop = false;
            this.gb_Control.Text = "温湿读模块1";
            // 
            // lblTem
            // 
            this.lblTem.AutoSize = true;
            this.lblTem.BackColor = System.Drawing.Color.Lime;
            this.lblTem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTem.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTem.Location = new System.Drawing.Point(112, 100);
            this.lblTem.Name = "lblTem";
            this.lblTem.Size = new System.Drawing.Size(41, 21);
            this.lblTem.TabIndex = 18;
            this.lblTem.Text = "0.0";
            this.lblTem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHum
            // 
            this.lblHum.AutoSize = true;
            this.lblHum.BackColor = System.Drawing.Color.Lime;
            this.lblHum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHum.Location = new System.Drawing.Point(112, 52);
            this.lblHum.Name = "lblHum";
            this.lblHum.Size = new System.Drawing.Size(41, 21);
            this.lblHum.TabIndex = 17;
            this.lblHum.Text = "0.0";
            this.lblHum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2.Location = new System.Drawing.Point(21, 100);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(85, 19);
            this.lbl2.TabIndex = 16;
            this.lbl2.Text = "湿度值：";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1.Location = new System.Drawing.Point(21, 52);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(85, 19);
            this.lbl1.TabIndex = 15;
            this.lbl1.Text = "湿度值：";
            // 
            // THMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_Control);
            this.Name = "THMonitor";
            this.Size = new System.Drawing.Size(257, 185);
            this.gb_Control.ResumeLayout(false);
            this.gb_Control.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Control;
        private System.Windows.Forms.Label lblTem;
        private System.Windows.Forms.Label lblHum;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
    }
}
