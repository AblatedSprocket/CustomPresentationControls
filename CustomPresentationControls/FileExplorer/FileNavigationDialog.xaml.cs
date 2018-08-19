using System.Windows;

namespace CustomPresentationControls.FileExplorer
{
    /// <summary>
    /// Interaction logic for FileNavigationDialog.xaml
    /// </summary>
    public partial class FileNavigationDialog : Window
    {
        private FileNavigationViewModel _viewModel;
        public string Path { get; private set; }
        public FileNavigationDialog(Mode mode)
        {
            InitializeComponent();
            _viewModel = new FileNavigationViewModel(mode);
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
