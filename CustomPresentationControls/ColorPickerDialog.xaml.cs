using CustomPresentationControls.ColorPick;
using System.Windows;
using System.Windows.Media;

namespace CustomPresentationControls
{
    /// <summary>
    /// Interaction logic for ColorPickerDialog.xaml
    /// </summary>
    public partial class ColorPickerDialog : Window
    {
        private ColorPickerViewModel _viewModel;
        public Color Color {get;set;}
        public ColorPickerDialog()
        {
            InitializeComponent();
            _viewModel = new ColorPickerViewModel();
            _viewModel.ColorSelected += OnColorSelected;
            DataContext = _viewModel;
        }
        private void OnColorSelected(object sender, ColorSelectedEventArgs e)
        {
            if (e.ChosenColor != null)
            {
                Color = e.ChosenColor;
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
        }
    }
}
