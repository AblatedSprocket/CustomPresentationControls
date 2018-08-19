using System.Collections.Generic;

namespace CustomPresentationControls.FileExplorer
{
    public class FileExtensions : List<string>
    {
        public FileExtensions()
        {
            Add(".txt");
            Add(".csv");
        }

    }
}
