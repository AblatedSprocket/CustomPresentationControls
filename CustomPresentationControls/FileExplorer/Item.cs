using CustomPresentationControls.Utilities;

namespace CustomPresentationControls.FileExplorer
{
    public class Item : ObservableObject
    {
        private string _name;
        private string _path;
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }
        public string Path
        {
            get { return _path; }
            set { OnPropertyChanged(ref _path, value); }
        }
    }

}
