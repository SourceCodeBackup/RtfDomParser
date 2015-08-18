/*
 * 
 *   DCSoft RTF DOM v1.0
 *   Author : Yuan yong fu.
 *   Email  : yyf9989@hotmail.com
 *   blog site:http://www.cnblogs.com/xdesigner.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RtfDomParser;

namespace RtfDomParser.Test
{
    public partial class frmRTFTest : Form
    {
        public frmRTFTest()
        {
            InitializeComponent();
        }

        private void btnLoadRTF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.RTF|*.rtf";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    this.Update();
                    RtfDomParser.RTFDomDocument doc = new RtfDomParser.RTFDomDocument();
                    doc.Progress += new ProgressEventHandler(doc_Progress);
                    doc.Load(dlg.FileName);
                    txtRTFDom.Text = doc.ToDomString();
                    this.Text = dlg.FileName;
                    myProgress.Value = 0;
                }
            }
        }

        void doc_Progress(object sender, ProgressEventArgs args)
        {
            myProgress.Maximum = args.MaxValue;
            myProgress.Value = args.Value;
        }

        private void btnLoadClipboardRTF_Click(object sender, EventArgs e)
        {
            IDataObject ido = Clipboard.GetDataObject();
            if (ido.GetDataPresent(DataFormats.Rtf))
            {
                string rtf = ( string ) ido.GetData(DataFormats.Rtf);
                RTFDomDocument doc = new RTFDomDocument();
                doc.Progress +=new ProgressEventHandler(doc_Progress);
                doc.LoadRTFText(rtf);
                txtRTFDom.Text = doc.ToDomString();
                this.Text = "";
                myProgress.Value = 0;

            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.RTF|*.rtf";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(dlg.FileName, Encoding.ASCII))
                    {
                        txtRTFSource.Text = reader.ReadToEnd();
                        this.Text = dlg.FileName;
                    }
                }
            }
        }

        private void btnCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, txtRTFSource.Text);
        }

        private void btnCopyRTF_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Rtf, txtRTFSource.Text);
        }
    }
}