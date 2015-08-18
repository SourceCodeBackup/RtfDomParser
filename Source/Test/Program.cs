using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XDesigner.RTF.Test
{
    static class Program
    {
        /// <summary>
        /// enter point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmRTFTest());
        }
    }
}