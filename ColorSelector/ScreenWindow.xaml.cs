using System.Drawing;
using System.Windows;
using System.Windows.Input;
using Media = System.Windows.Media;
using Windows = System.Windows;
using Imaging = System.Drawing.Imaging;
using System.Windows.Media;
using System;

namespace ColorSelector
{
    /// <summary>
    /// Interaction logic for ScreenWindow.xaml
    /// </summary>
    public partial class ScreenWindow : Window
    {
        public ScreenWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePos = Windows.Forms.Cursor.Position;

            Magnifier.Fill = new SolidColorBrush(GetPixelColor(mousePos.X, mousePos.Y));

            // Code for magnifing glass
        }

        public void PickColor(object sender, MouseEventArgs e)
        {
            var clickPoint = Windows.Forms.Cursor.Position;

            GetPixelColor(clickPoint.X, clickPoint.Y);

            Close();
        }

        private Media.Color GetPixelColor(int x, int y)
        {
            Bitmap bmp = new Bitmap(3, 3, Imaging.PixelFormat.Format32bppArgb);
            Graphics gfx = Graphics.FromImage(bmp);

            gfx.CopyFromScreen(x - 1, y - 1, 0, 0, new System.Drawing.Size(3, 3), CopyPixelOperation.SourceCopy);

            // TODO get dominant color instead of average color
            // Average color tends to blend around borders, no average gives strange colors for black edges as edges are usually a combination of colors
            return GetAverageColor(bmp);
        }

        private Media.Color GetAverageColor(Bitmap bmp)
        {
            int r = 0, g = 0, b = 0;
            int total = 0;
            
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    var color = bmp.GetPixel(i, j);
                    r += color.R;
                    g += color.G;
                    b += color.B;

                    total++;
                }
            }

            return Media.Color.FromRgb(
                Convert.ToByte(r / total),
                Convert.ToByte(g / total),
                Convert.ToByte(b / total));
        }
    }
}


/*
 * https://stackoverflow.com/questions/1483928/how-to-read-the-color-of-a-screen-pixel
 * 
IntPtr desk = GetDesktopWindow();
IntPtr dc = GetWindowDC(desk);
int a = (int)GetPixel(dc, (int)clickPoint.X, (int)clickPoint.Y);
ReleaseDC(desk, dc);
System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(255, Convert.ToByte((a >> 0) & 0xff), Convert.ToByte((a >> 8) & 0xff), Convert.ToByte((a >> 16) & 0xff));

Magnifier.Fill = new SolidColorBrush(color);
*/

/*
 * 
 * 
Point mousePos = e.GetPosition(this);
double x = mousePos.X;
double y = mousePos.Y;

double length = Magnifier.Width * _factor;
double radius = length / 2;

Rect viewboxRect = new Rect(x - radius, y - radius, length, length);
MagnifierBrush.Viewbox = viewboxRect;

Magnifier.SetValue(Canvas.LeftProperty, x - Magnifier.ActualWidth / 2);
Magnifier.SetValue(Canvas.TopProperty, y - Magnifier.ActualHeight / 2);

Canvas.SetLeft(Magnifier, x);
Canvas.SetTop(Magnifier, y); 
*/

/*
 * https://stackoverflow.com/questions/1483928/how-to-read-the-color-of-a-screen-pixel
 * 
IntPtr desk = GetDesktopWindow();
IntPtr dc = GetWindowDC(desk);
int a = (int)GetPixel(dc, (int) clickPoint.X, (int) clickPoint.Y);
ReleaseDC(desk, dc);
System.Drawing.Color color = System.Drawing.Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
*/

/*
 * https://stackoverflow.com/questions/1483928/how-to-read-the-color-of-a-screen-pixel
 * 
Bitmap screenPixel = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

using ( Graphics gdest = Graphics.FromImage(screenPixel))
{
    using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
    {
        IntPtr hSrcDC = gsrc.GetHdc();
        IntPtr hDC = gdest.GetHdc();
        int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, (int) clickPoint.X, (int) clickPoint.Y, (int)CopyPixelOperation.SourceCopy);
        gdest.ReleaseHdc();
        gsrc.ReleaseHdc();
    }
}

System.Drawing.Color color = screenPixel.GetPixel(0, 0);
*/

//[DllImport("user32.dll")]
//static extern bool GetCursorPos(ref System.Drawing.Point lpPoint);

//[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
//public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

//[DllImport("user32.dll")]
//public static extern IntPtr GetDesktopWindow();
//[DllImport("user32.dll")]
//public static extern IntPtr GetWindowDC(IntPtr window);
//[DllImport("user32.dll")]
//public static extern int ReleaseDC(IntPtr window, IntPtr dc);
//[DllImport("gdi32.dll")]
//public static extern uint GetPixel(IntPtr dc, int x, int y);