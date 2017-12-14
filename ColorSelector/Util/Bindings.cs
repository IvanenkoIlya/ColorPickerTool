using System.ComponentModel;
using Drawing = System.Drawing;
using System.Windows.Media;

namespace ColorSelector.Util
{
    public class Bindings : INotifyPropertyChanged
    {
        private static Bindings instance;

        private Bindings() { }

        public static Bindings GetInstance()
        {
            if (instance == null) instance = new Bindings();
            return instance;
        }

        private SolidColorBrush selectedColor = new SolidColorBrush(Drawing.Color.White.ConvertToMediaColor());

        public SolidColorBrush SelectedColor
        {
            get { return selectedColor; }
            set
            {
                if (value != selectedColor)
                {
                    selectedColor = value;
                    OnPropertyChanged("SelectedColor");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}