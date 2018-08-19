using System;
using System.Collections.Generic;
using System.IO;

namespace CustomPresentationControls.FileExplorer
{
    class ItemProvider
    {
        private Mode _mode;
        public ItemProvider(Mode mode)
        {
            _mode = mode;
        }
        public List<Item> GetDrives()
        {
            List<Item> items = new List<Item>();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                DirectoryItem directory = new DirectoryItem();
                directory.Name = drive.Name;
                directory.Path = drive.Name;
                directory.Items = GetItems(drive.Name);
                items.Add(directory);
            }
            return items;
        }
        public List<Item> GetItems(string path)
        {
            List<Item> items = new List<Item>();
            DirectoryInfo info = new DirectoryInfo(path);
            try
            {
                foreach (DirectoryInfo directory in info.GetDirectories())
                {
                    items.Add(new DirectoryItem
                    {
                        Name = directory.Name,
                        Path = directory.FullName,
                    });
                }
                if (_mode == Mode.Save)
                {
                    foreach (FileInfo file in info.GetFiles())
                    {
                        items.Add(new FileItem
                        {
                            Name = file.Name,
                            Path = file.FullName
                        });
                    }
                }
            }
            catch (Exception) { }
            return items;
        }
    }
}
