using CustomPresentationControls.FileExplorer;
using System.Windows;

namespace CustomPresentationControls
{
    /// <summary>
    /// Interaction logic for OpenFolderDialog.xaml
    /// </summary>
    public partial class OpenFolderDialog : Window
    {
        private FileNavigationViewModel _viewModel;
        public string Path { get; private set; }
        public OpenFolderDialog()
        {
            InitializeComponent();
            _viewModel = new FileNavigationViewModel(Mode.Open);
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
