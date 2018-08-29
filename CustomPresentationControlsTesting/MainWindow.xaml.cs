using CustomPresentationControls;
using CustomPresentationControls.Charts;
using CustomPresentationControls.FileExplorer;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomPresentationControlsTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AuthenticationViewModel ViewModel { get; set; }
        public ObservableCollection<PieSegment> Data { get; set; }
        public MainWindow()
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            Data = new ObservableCollection<PieSegment>
            {
                new PieSegment
                {
                    Name = "Fools",
                    Value = 66,
                    Color = new SolidColorBrush(Colors.Blue)
                },
                new PieSegment
                {
                    Name = "Errand",
                    Value = 66,
                    Color = new SolidColorBrush(Colors.Green)
    },
                new PieSegment
                {
                    Name = "Fools",
                    Value = 66,
                    Color = new SolidColorBrush(Colors.Red)
                },
                new PieSegment
                {
                    Name = "Fools",
                    Value = 66,
                    Color = new SolidColorBrush(Colors.Purple)
                }
            };
            DataContext = this;
            ViewModel = new AuthenticationViewModel();
            FileNavigationDialog dialog = new FileNavigationDialog(Mode.Save);
            //dialog.ShowDialog();
            InitializeComponent();
        }
    }
}
