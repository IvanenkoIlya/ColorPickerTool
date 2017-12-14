using ColorSelector.Util;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Imaging = System.Drawing.Imaging;
using Windows = System.Windows;

namespace ColorSelector
{
    /// <summary>
    /// Interaction logic for ScreenWindow.xaml
    /// </summary>
    public partial class ScreenWindow : Window
    {
        public int EdgeOffset { get; set; }
        public bool AverageColor { get; set; }

        public ScreenWindow()
        {
            InitializeComponent();
            EdgeOffset = (int) Canvas.GetLeft(Magnifier);
            AverageColor = true;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePos = Windows.Forms.Cursor.Position;
            
            Magnifier.Fill = new SolidColorBrush(GetPixelColor(mousePos.X, mousePos.Y));
        }

        private void Magnifier_MouseOver(object sender, MouseEventArgs e)
        {
            if (Canvas.GetLeft(Magnifier) <= EdgeOffset)          
                Canvas.SetLeft(Magnifier, Window.Width - Magnifier.Width - EdgeOffset);
            else
                Canvas.SetLeft(Magnifier, EdgeOffset);
        }

        public void PickColor(object sender, MouseEventArgs e)
        {
            var clickPoint = Windows.Forms.Cursor.Position;

            var pixelColor = GetPixelColor(clickPoint.X, clickPoint.Y);

            ((ColorPicker) Application.Current.MainWindow).SelectedColor = pixelColor;

            Close();
        }

        private Color GetPixelColor(int x, int y)
        {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(3, 3, Imaging.PixelFormat.Format32bppArgb);
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(bmp);

            gfx.CopyFromScreen(x - 1, y - 1, 0, 0, new System.Drawing.Size(3, 3), System.Drawing.CopyPixelOperation.SourceCopy);

            if( AverageColor)
            {
                return GetAverageColor(bmp);
            } else
            {
                return GetDominantColor(bmp);
            }
        }

        private Color GetAverageColor(System.Drawing.Bitmap bmp)
        {
            int r = 0, g = 0, b = 0;
            int total = 0;
            
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    var color = bmp.GetPixel(x, y);
                    r += color.R;
                    g += color.G;
                    b += color.B;

                    total++;
                }
            }

            return Color.FromRgb(
                Convert.ToByte(r / total),
                Convert.ToByte(g / total),
                Convert.ToByte(b / total));
        }

        private Color GetDominantColor(System.Drawing.Bitmap bmp)
        {
            var list = new Dictionary<int, int>();
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    int rgb = bmp.GetPixel(x, y).ToArgb();

                    var added = false;
                    for (int i = 0; i < 10; i++)
                    {
                        if (list.ContainsKey(rgb + i))
                        {
                            list[rgb + i]++;
                            added = true;
                            break;
                        }
                        if (list.ContainsKey(rgb - i))
                        {
                            list[rgb - i]++;
                            added = true;
                            break;
                        }
                    }
                    if (!added)
                        list.Add(rgb, 1);
                }
            }

            System.Drawing.Color color = System.Drawing.Color.FromArgb(list.Aggregate((l, r) => l.Value > r.Value ? l : r).Key);

            return color.ConvertToMediaColor();
        }
    }
}