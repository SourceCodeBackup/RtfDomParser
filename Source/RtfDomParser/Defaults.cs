using System.Text;

namespace RtfDomParser
{
    public static class Defaults
    {
        public static string FontName { get; set; } = "Times New Roman";

        public static void LoadEncodings()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}