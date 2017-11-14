using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ColorSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        public ColorPicker()
        {
            InitializeComponent();

            NotifyIcon ni = new NotifyIcon
            {
                Icon = new Icon(System.Windows.Application.GetResourceStream(new Uri("/Resources/main_QUO_icon.ico", UriKind.Relative)).Stream),
                Visible = true
            };
            ni.DoubleClick += delegate (object sender, EventArgs args)
            {
                Show();
                WindowState = WindowState.Normal;
            };
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

        private void MouseMoveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //if (Captured)
            //{
            //    var absmouseXpos = e.GetPosition(this).X;
            //    var absmouseYpos = e.GetPosition(this).Y;
            //}
        }
    }
}
