using System;

namespace CustomPresentationControls.FileExplorer
{
    public sealed class ItemSelectedEventArgs : EventArgs
    {
        public string Path { get; set; }
        public ItemSelectedEventArgs(string path)
        {
            Path = path;
        }
    }
}
