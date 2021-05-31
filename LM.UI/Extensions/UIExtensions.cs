using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LM.UI.Extensions
{
    internal static class UIExtensions
    {
        public static byte[] ToByteArray(this Image image)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(image, typeof(byte[]));
        }

        public static Image ToImage(this byte[] byteArray)
        {
            using var ms = new MemoryStream(byteArray);
            return Image.FromStream(ms);
        }
    }
}
