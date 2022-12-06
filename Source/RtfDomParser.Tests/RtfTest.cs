using System.IO;
using System.Threading;
using NUnit.Framework;

namespace RtfDomParser.Tests
{
    [TestFixture]
    public class RtfTest
    {
        [SetUp]
        public void Setup()
        {
            Defaults.FontName = System.Windows.Forms.Control.DefaultFont.Name;
        }

        /// <summary>
        /// Test generate rtf file
        /// after execute this function you can open c:\a.rtf
        /// </summary>
        [Test]
        public void TestWriteFile()
        {
            string file = Path.GetFullPath("a.rtf");
            RTFWriter w = new RTFWriter(file);
            Helper.TestBuildRTF(w);
            w.Close();
            System.Windows.Forms.MessageBox.Show($"OK, you can open file {file} now.");
        }

        /// <summary>
        /// Test generate rtf text and copy to windows clipboard
        /// after execute this function , you can paste rtf text in MS Word
        /// </summary>
        [Test]
        [RequiresThread(ApartmentState.STA)]
        public void TestClipboard()
        {
            System.IO.StringWriter myStr = new System.IO.StringWriter();
            RTFWriter w = new RTFWriter(myStr);
            Helper.TestBuildRTF(w);
            w.Close();
            System.Windows.Forms.DataObject data = new System.Windows.Forms.DataObject();
            data.SetData(System.Windows.Forms.DataFormats.Rtf, myStr.ToString());
            System.Windows.Forms.Clipboard.SetDataObject(data, true);
            System.Windows.Forms.MessageBox.Show("OK, you can paste words in MS Word.");
        }
    }
}