namespace XDesigner.RTF.Test
{
    partial class frmRTFTest
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRTFTest));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLoadRTF = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.myProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.txtRTFDom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadRTF,
            this.toolStripSeparator1,
            this.myProgress});
            this.toolStrip1.Location = new System.Drawing.Point(0, 70);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(667, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLoadRTF
            // 
            this.btnLoadRTF.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadRTF.Image")));
            this.btnLoadRTF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadRTF.Name = "btnLoadRTF";
            this.btnLoadRTF.Size = new System.Drawing.Size(121, 22);
            this.btnLoadRTF.Text = "Load RTF file...";
            this.btnLoadRTF.Click += new System.EventHandler(this.btnLoadRTF_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // myProgress
            // 
            this.myProgress.Name = "myProgress";
            this.myProgress.Size = new System.Drawing.Size(200, 22);
            // 
            // txtRTFDom
            // 
            this.txtRTFDom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRTFDom.Location = new System.Drawing.Point(0, 95);
            this.txtRTFDom.Multiline = true;
            this.txtRTFDom.Name = "txtRTFDom";
            this.txtRTFDom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRTFDom.Size = new System.Drawing.Size(667, 472);
            this.txtRTFDom.TabIndex = 1;
            this.txtRTFDom.WordWrap = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(667, 70);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRTFTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 567);
            this.Controls.Add(this.txtRTFDom);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Name = "frmRTFTest";
            this.Text = "Rtf Dom Parser V1.0";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLoadRTF;
        private System.Windows.Forms.TextBox txtRTFDom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar myProgress;
    }
}

