using System;
using System.Globalization;
using System.Windows.Data;

namespace CustomPresentationControls.FileExplorer
{
    class ItemToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is DirectoryItem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
