using CustomPresentationControls.FileExplorer;
using System.Windows;

namespace CustomPresentationControls
{
    /// <summary>
    /// Interaction logic for SaveFileDialog.xaml
    /// </summary>
    public partial class SaveFileDialog : Window
    {
        private FileNavigationViewModel _viewModel;
        public string Path { get; private set; }
        public SaveFileDialog()
        {
            InitializeComponent();
            _viewModel = new FileNavigationViewModel(Mode.Save);
            _viewModel.ItemSelected += OnItemSelected;
            DataContext = _viewModel;
        }
        private void OnItemSelected(object sender, ItemSelectedEventArgs e)
        {
            if (e.Path != null)
            {
                Path = e.Path;
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
        }
    }
}
