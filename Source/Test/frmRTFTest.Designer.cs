namespace DCSoft.RTF.Test
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
            this.btnLoadClipboardRTF = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.myProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.txtRTFDom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtRTFSource = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnLoadFile = new System.Windows.Forms.ToolStripButton();
            this.btnCopyText = new System.Windows.Forms.ToolStripButton();
            this.btnCopyRTF = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadRTF,
            this.btnLoadClipboardRTF,
            this.toolStripSeparator1,
            this.myProgress});
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            // 
            // btnLoadRTF
            // 
            resources.ApplyResources(this.btnLoadRTF, "btnLoadRTF");
            this.btnLoadRTF.Name = "btnLoadRTF";
            this.btnLoadRTF.Click += new System.EventHandler(this.btnLoadRTF_Click);
            // 
            // btnLoadClipboardRTF
            // 
            resources.ApplyResources(this.btnLoadClipboardRTF, "btnLoadClipboardRTF");
            this.btnLoadClipboardRTF.Name = "btnLoadClipboardRTF";
            this.btnLoadClipboardRTF.Click += new System.EventHandler(this.btnLoadClipboardRTF_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // myProgress
            // 
            resources.ApplyResources(this.myProgress, "myProgress");
            this.myProgress.Name = "myProgress";
            // 
            // txtRTFDom
            // 
            resources.ApplyResources(this.txtRTFDom, "txtRTFDom");
            this.txtRTFDom.Name = "txtRTFDom";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Name = "label1";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.txtRTFDom);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.txtRTFSource);
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtRTFSource
            // 
            resources.ApplyResources(this.txtRTFSource, "txtRTFSource");
            this.txtRTFSource.Name = "txtRTFSource";
            // 
            // toolStrip2
            // 
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadFile,
            this.btnCopyText,
            this.btnCopyRTF});
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.ShowItemToolTips = false;
            // 
            // btnLoadFile
            // 
            resources.ApplyResources(this.btnLoadFile, "btnLoadFile");
            this.btnLoadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnCopyText
            // 
            resources.ApplyResources(this.btnCopyText, "btnCopyText");
            this.btnCopyText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopyText.Name = "btnCopyText";
            this.btnCopyText.Click += new System.EventHandler(this.btnCopyText_Click);
            // 
            // btnCopyRTF
            // 
            resources.ApplyResources(this.btnCopyRTF, "btnCopyRTF");
            this.btnCopyRTF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopyRTF.Name = "btnCopyRTF";
            this.btnCopyRTF.Click += new System.EventHandler(this.btnCopyRTF_Click);
            // 
            // frmRTFTest
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "frmRTFTest";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLoadRTF;
        private System.Windows.Forms.TextBox txtRTFDom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar myProgress;
        private System.Windows.Forms.ToolStripButton btnLoadClipboardRTF;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtRTFSource;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnLoadFile;
        private System.Windows.Forms.ToolStripButton btnCopyText;
        private System.Windows.Forms.ToolStripButton btnCopyRTF;
    }
}

