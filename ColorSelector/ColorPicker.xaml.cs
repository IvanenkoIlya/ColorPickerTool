using ColorSelector.Util;
using System;
using System.ComponentModel;
using System.Diagnostics;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WinForms = System.Windows.Forms;

namespace ColorSelector
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        WinForms.NotifyIcon ni;
        private Color selectedColor;
        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                selectedColor = value;
                Bindings.GetInstance().SelectedColor = new SolidColorBrush(selectedColor);
            }
        }

        public ColorPicker()
        {
            InitializeComponent();

            ni = new WinForms.NotifyIcon
            {
                Icon = new System.Drawing.Icon(Application.GetResourceStream(new Uri("/Resources/main_QUO_icon.ico", UriKind.Relative)).Stream),
                Visible = true
            };
            ni.DoubleClick += delegate (object sender, EventArgs args)
            {
                Show();
                Focus();
                WindowState = WindowState.Normal;
            };
            ni.MouseDown += new WinForms.MouseEventHandler(NotifyIcon_ContextMenu);
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();

            base.OnStateChanged(e);
        }

        private void NotifyIcon_ContextMenu(object sender, WinForms.MouseEventArgs e)
        {
            if(e.Button == WinForms.MouseButtons.Right)
            {
                ContextMenu cm = (ContextMenu)ColorSelectorGrid.FindResource("NotifyIconContextMenu");
                cm.IsOpen = true;
            }
        }
        
        private void PickColor(object sender, EventArgs e)
        {
            ScreenWindow colorPicker = new ScreenWindow();
            colorPicker.ShowDialog();
        }

        private void MouseEnter_ColorGrid(object sender, EventArgs e)
        {
           Bindings.GetInstance().SelectedColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(((Path)sender).Tag.ToString()));
        }

        public void ResetSelectedColorDisplay(object sender, EventArgs e)
        {
            Bindings.GetInstance().SelectedColor = new SolidColorBrush(selectedColor);
        }

        private void MouseClick_ColorGrid(object sender, EventArgs e)
        {
            SelectedColor = (Color) ColorConverter.ConvertFromString(((Path) sender).Tag.ToString());
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            ni.Dispose();
        }

        private void ReopenApplication(object sends, EventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
        }

        private void CloseApplication(object sender, EventArgs e)
        {
            Close();
        }
    }
}
