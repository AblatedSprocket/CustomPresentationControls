using CustomPresentationControls.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPresentationControls.FileExplorer
{
    public enum Mode
    {
        Open,
        Save
    }
    class FileNavigationViewModel : ViewModel
    {

        #region Fields
        private string _path;
        private ItemProvider _provider;
        private Item _selectedItem;
        private ObservableCollection<Item> _pathItems = new ObservableCollection<Item>();
        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
        #endregion
        #region Properties
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { OnPropertyChanged(ref _items, value); }
        }
        public string Path
        {
            get { return _path; }
            set { OnPropertyChanged(ref _path, value); }
        }
        public ObservableCollection<Item> PathItems
        {
            get { return _pathItems; }
            set { OnPropertyChanged(ref _pathItems, value); }
        }
        #endregion
        #region Commands
        public RelayCommand CancelCommand { get; }
        public RelayCommand<string> CommitCommand { get; }
        public RelayCommand<Item> ListNavCommand { get; }
        public RelayCommand<DirectoryItem> MenuNavCommand { get; }
        public RelayCommand PreviousDirectoryCommand { get; }
        public RelayCommand<string> SetPathCommand { get; }
        #endregion
        #region Events
        public event EventHandler<ItemSelectedEventArgs> ItemSelected = delegate { };
        #endregion

        public FileNavigationViewModel(Mode mode)
        {
            _provider = new ItemProvider(mode);
            Items = new ObservableCollection<Item>(_provider.GetDrives());
            CancelCommand = new RelayCommand(OnCancel);
            CommitCommand = new RelayCommand<string>(OnCommit);
            ListNavCommand = new RelayCommand<Item>(OnFolderSelected);
            MenuNavCommand = new RelayCommand<DirectoryItem>(OnMenuItemSelected);
            PreviousDirectoryCommand = new RelayCommand(OnPreviousDirectoryRequested);
            SetPathCommand = new RelayCommand<string>(OnSetPath);
        }
        #region Command Methods
        private void OnCancel()
        {
            ItemSelected(this, new ItemSelectedEventArgs(null));
        }
        private void OnCommit(string path)
        {
            ItemSelected(this, new ItemSelectedEventArgs(Path));
        }
        private void OnFolderSelected(Item item)
        {
            if (item is DirectoryItem directory)
            {
                PathItems.Add(directory);
                Items = new ObservableCollection<Item>(_provider.GetItems(directory.Path));
            }
        }
        private void OnMenuItemSelected(DirectoryItem item)
        {
            int index = PathItems.IndexOf(item);
            for (int i = PathItems.Count - 1; i > PathItems.IndexOf(item); i--)
            {
                PathItems.RemoveAt(i);
            }
            Items = new ObservableCollection<Item>(_provider.GetItems(item.Path));
        }
        private void OnPreviousDirectoryRequested()
        {
            if (PathItems.Count > 1)
            {
                PathItems.RemoveAt(PathItems.Count - 1);
                Items = new ObservableCollection<Item>(_provider.GetItems(PathItems.Last().Path));
            }
            else if (PathItems.Count == 1)
            {
                PathItems.Clear();
                Items = new ObservableCollection<Item>(_provider.GetDrives());
            }
        }
        private void OnSetPath(string path)
        {
            Path = path;
        }
        #endregion
    }
}
