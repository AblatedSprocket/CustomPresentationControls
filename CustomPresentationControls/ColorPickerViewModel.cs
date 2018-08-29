using CustomPresentationControls.ColorPick;
using CustomPresentationControls.Utilities;
using System;
using System.Windows.Media;

namespace CustomPresentationControls
{
    class ColorPickerViewModel : ViewModel
    {
        #region Fields
        private bool _updateBusy;
        private Color _color;
        private int _redPick;
        private int _greenPick;
        private int _bluePick;
        private string _hexValue;
        private LinearGradientBrush _redGradient;
        private LinearGradientBrush _greenGradient;
        private LinearGradientBrush _blueGradient;
        #endregion
        #region Properties
        public Color Color
        {
            get { return _color; }
            set
            {
                OnPropertyChanged(ref _color, value);
            }
        }
        public int RedPick
        {
            get { return _redPick; }
            set
            {
                _updateBusy = true;
                OnPropertyChanged(ref _redPick, value);
                Color = Color.FromRgb(Convert.ToByte(_redPick), Convert.ToByte(_greenPick), Convert.ToByte(_bluePick));
                HexValue = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", _color.A, _color.R, _color.G, _color.B);
                GreenGradient = new LinearGradientBrush(Color.FromRgb(Convert.ToByte(_redPick), 0, Convert.ToByte(_bluePick)), Color.FromRgb(Convert.ToByte(_redPick), 255, Convert.ToByte(_bluePick)), 0);
                BlueGradient = new LinearGradientBrush(Color.FromRgb(Convert.ToByte(_redPick), Convert.ToByte(_greenPick), 0), Color.FromRgb(Convert.ToByte(_redPick), Convert.ToByte(_greenPick), 255), 0);
            }
        }
        public int GreenPick
        {
            get { return _greenPick; }
            set
            {
                _updateBusy = true;
                OnPropertyChanged(ref _greenPick, value);
                Color = Color.FromRgb(Convert.ToByte(_redPick), Convert.ToByte(_greenPick), Convert.ToByte(_bluePick));
                HexValue = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", _color.A, _color.R, _color.G, _color.B);
                RedGradient = new LinearGradientBrush(Color.FromRgb(0, Convert.ToByte(_greenPick), Convert.ToByte(_bluePick)), Color.FromRgb(255, Convert.ToByte(_greenPick), Convert.ToByte(_bluePick)), 0);
                BlueGradient = new LinearGradientBrush(Color.FromRgb(Convert.ToByte(_redPick), Convert.ToByte(_greenPick), 0), Color.FromRgb(Convert.ToByte(_redPick), Convert.ToByte(_greenPick), 255), 0);
            }
        }
        public int BluePick
        {
            get { return _bluePick; }
            set
            {
                _updateBusy = true;
                OnPropertyChanged(ref _bluePick, value);
                Color = Color.FromRgb(Convert.ToByte(_redPick), Convert.ToByte(_greenPick), Convert.ToByte(_bluePick));
                HexValue = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", _color.A, _color.R, _color.G, _color.B);
                RedGradient = new LinearGradientBrush(Color.FromRgb(0, Convert.ToByte(_greenPick), Convert.ToByte(_bluePick)), Color.FromRgb(255, Convert.ToByte(_greenPick), Convert.ToByte(_bluePick)), 0);
                GreenGradient = new LinearGradientBrush(Color.FromRgb(Convert.ToByte(_redPick), 0, Convert.ToByte(_bluePick)), Color.FromRgb(Convert.ToByte(_redPick), 255, Convert.ToByte(_bluePick)), 0);
            }
        }
        public string HexValue
        {
            get { return _hexValue; }
            set
            {
                OnPropertyChanged(ref _hexValue, value);
                if (!_updateBusy)
                {
                    Color color = (Color)ColorConverter.ConvertFromString(value);
                    RedPick = color.R;
                    GreenPick = color.G;
                    BluePick = color.B;
                }
                _updateBusy = false;
            }

        }
        public LinearGradientBrush RedGradient
        {
            get { return _redGradient; }
            set { OnPropertyChanged(ref _redGradient, value); }
        }
        public LinearGradientBrush GreenGradient
        {
            get { return _greenGradient; }
            set { OnPropertyChanged(ref _greenGradient, value); }
        }
        public LinearGradientBrush BlueGradient
        {
            get { return _blueGradient; }
            set { OnPropertyChanged(ref _blueGradient, value); }
        }
        #endregion
        #region Commands
        public RelayCommand CancelCommand { get; }
        public RelayCommand CommitCommand { get; }
        #endregion
        #region Events
        public EventHandler<ColorSelectedEventArgs> ColorSelected = delegate { };
        #endregion
        public ColorPickerViewModel()
        {
            CancelCommand = new RelayCommand(OnCanceled);
            CommitCommand = new RelayCommand(OnCommitted);
            RedPick = 0;
            GreenPick = 0;
            BluePick = 0;
        }
        #region Command Methods
        private void OnCanceled()
        {
            ColorSelected(this, new ColorSelectedEventArgs());
        }
        private void OnCommitted()
        {
            ColorSelected(this, new ColorSelectedEventArgs(Color));
        }
        #endregion
    }
}
