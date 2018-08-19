using System.Collections.Generic;

namespace CustomPresentationControls.FileExplorer
{
    public class DirectoryItem : Item
    {
        private List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get { return _items; }
            set { OnPropertyChanged(ref _items, value); }
        }
    }
}
