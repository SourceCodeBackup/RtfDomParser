/***************************************************************************

  Rtf Dom Parser

  Copyright (c) 2010 sinosoft , written by yuans.
  http://www.sinoreport.net

  This program is free software; you can redistribute it and/or
  modify it under the terms of the GNU General Public License
  as published by the Free Software Foundation; either version 2
  of the License, or (at your option) any later version.
  
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.
  
  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XDesigner.RTF.Test
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
                    XDesigner.RTF.RTFDomDocument doc = new XDesigner.RTF.RTFDomDocument();
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
    }
}