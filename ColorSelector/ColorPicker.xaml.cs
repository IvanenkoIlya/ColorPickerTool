using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace ColorSelector
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        NotifyIcon ni;

       public ColorPicker()
        {
            InitializeComponent();

            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add(new MenuItem("&Open", ReopenApplication));
            cm.MenuItems.Add(new MenuItem("&Pick color", PickColor));
            cm.MenuItems.Add("-");
            cm.MenuItems.Add(new MenuItem("&Exit", CloseApplication));

            ni = new NotifyIcon
            {
                Icon = new Icon(System.Windows.Application.GetResourceStream(new Uri("/Resources/main_QUO_icon.ico", UriKind.Relative)).Stream),
                Visible = true
            };
            ni.DoubleClick += delegate (object sender, EventArgs args)
            {
                Show();
                WindowState = WindowState.Normal;
            };
            ni.ContextMenu = cm;
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();

            base.OnStateChanged(e);
        }

        private void PickColor(object sender, EventArgs e)
        {
            ScreenWindow colorPicker = new ScreenWindow();
            colorPicker.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
