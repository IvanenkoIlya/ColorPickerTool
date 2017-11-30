using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;

namespace ColorSelector
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        WinForms.NotifyIcon ni;
        public static Color SelectedColor { get; set; }

        public ColorPicker()
        {
            InitializeComponent();

            ni = new WinForms.NotifyIcon
            {
                Icon = new Icon(Application.GetResourceStream(new Uri("/Resources/main_QUO_icon.ico", UriKind.Relative)).Stream),
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
                ContextMenu cm = (ContextMenu)FindResource("NotifyIconContextMenu");
                cm.IsOpen = true;
            }
        }
        
        private void PickColor(object sender, EventArgs e)
        {
            ScreenWindow colorPicker = new ScreenWindow();
            colorPicker.ShowDialog();
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
