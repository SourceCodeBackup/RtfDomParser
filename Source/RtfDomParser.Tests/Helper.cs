namespace RtfDomParser.Tests
{
    internal static class Helper
    {
        /// <summary>
        /// Test to generate a little rtf document
        /// </summary>
        /// <param name="w">RTF text writer</param>
        internal static void TestBuildRTF(RTFWriter w)
        {
            w.Encoding = System.Text.Encoding.GetEncoding(936);
            // write header
            w.WriteStartGroup();
            w.WriteKeyword("rtf1");
            w.WriteKeyword("ansi");
            w.WriteKeyword("ansicpg" + w.Encoding.CodePage);
            // wirte font table
            w.WriteStartGroup();
            w.WriteKeyword("fonttbl");
            w.WriteStartGroup();
            w.WriteKeyword("f0");
            w.WriteText("Arial;");
            w.WriteEndGroup();
            w.WriteStartGroup();
            w.WriteKeyword("f1");
            w.WriteText("Times New Roman;");
            w.WriteEndGroup();
            w.WriteEndGroup();
            // write color table
            w.WriteStartGroup();
            w.WriteKeyword("colortbl");
            w.WriteText(";");
            w.WriteKeyword("red0");
            w.WriteKeyword("green0");
            w.WriteKeyword("blue255");
            w.WriteText(";");
            w.WriteEndGroup();
            // write content
            w.WriteKeyword("qc"); // set alignment center
            w.WriteKeyword("f0"); // set font
            w.WriteKeyword("fs30"); // set font size
            w.WriteText("This is the first paragraph text ");
            w.WriteKeyword("cf1"); // set text color
            w.WriteText("Arial ");
            w.WriteKeyword("cf0"); // set default color
            w.WriteKeyword("f1"); // set font
            w.WriteText("Align center ABC12345");
            w.WriteKeyword("par"); // new paragraph
            w.WriteKeyword("pard"); // clear format
            w.WriteKeyword("f1"); // set font 
            w.WriteKeyword("fs20"); // set font size
            w.WriteKeyword("cf1");
            w.WriteText("This is the secend paragraph Arial left alignment ABC12345");
            // finish
            w.WriteEndGroup();
        }
    }
}