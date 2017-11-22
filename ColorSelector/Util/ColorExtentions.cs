using Drawing = System.Drawing;
using Media = System.Windows.Media;

namespace ColorSelector.Util
{
    public static class ColorExtentions
    {
        public static Media.Color ConvertToMediaColor(this Drawing.Color color)
        {
            return Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static Drawing.Color ConvertToDrawingColor(this Media.Color color)
        {
            return Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
