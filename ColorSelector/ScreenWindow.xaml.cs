using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

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

            Debug.WriteLine("Initialized");
        }

        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(this);
            double x = mousePos.X;
            double y = mousePos.Y;

            Bitmap _bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                               Screen.PrimaryScreen.Bounds.Height,
                               System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            System.Drawing.Color _color = _bitmap.GetPixel((int) x, (int) y);

            System.Windows.Media.Color color = new System.Windows.Media.Color();
            color.A = _color.A;
            color.R = _color.R;
            color.G = _color.G;
            color.B = _color.B;

            ColorWindow.Fill = new SolidColorBrush(color);

            Canvas.SetLeft(ColorWindow, x);
            Canvas.SetTop(ColorWindow, y);
        }

        public void PickColor(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Debug.WriteLine("Color picked");

            System.Windows.Point clickPoint = e.GetPosition(this);

            Bitmap _bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                               Screen.PrimaryScreen.Bounds.Height,
                               System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            System.Drawing.Color _color = _bitmap.GetPixel((int)clickPoint.X, (int)clickPoint.Y);

            Close();
        }
    }
}
