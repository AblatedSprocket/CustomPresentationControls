using CustomPresentationControls.Utilities;
using System.Windows;
using System.Windows.Media;

namespace CustomPresentationControls.Charts
{
    public class DataBin : ObservableObject
    {
        private string _name;
        private double _value;
        private Point _coordinates;
        private SolidColorBrush _color;
        public string Name
        {
            get { return _name; }
            set
            {
                OnPropertyChanged(ref _name, value);
            }
        }
        public double Value
        {
            get { return _value; }
            set
            {
                OnPropertyChanged(ref _value, value);
            }
        }
        public SolidColorBrush Color
        {
            get { return _color; }
            set
            {
                OnPropertyChanged(ref _color, value);
            }
        }
    }
}
