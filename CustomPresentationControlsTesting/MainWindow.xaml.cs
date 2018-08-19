using CustomPresentationControls;
using CustomPresentationControls.FileExplorer;
using System.Windows;

namespace CustomPresentationControlsTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AuthenticationViewModel ViewModel { get; set; }
        public MainWindow()
        {
            DataContext = this;
            ViewModel = new AuthenticationViewModel();
            FileNavigationDialog dialog = new FileNavigationDialog(Mode.Save);
            dialog.ShowDialog();
            InitializeComponent();
        }
    }
}
