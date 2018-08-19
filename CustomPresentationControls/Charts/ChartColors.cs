using System.Windows.Media;

namespace CustomPresentationControls.Charts
{
    internal static class ChartColors
    {
        private static Color _red = Color.FromRgb(235, 63, 39);
        private static Color _orange = Color.FromRgb(255, 164, 22);
        private static Color _yellow = Color.FromRgb(235, 235, 74);
        private static Color _green = Color.FromRgb(177, 235, 34);
        private static Color _aqua = Color.FromRgb(72, 235, 156);
        private static Color _blue = Color.FromRgb(28, 136, 235);
        private static Color _purple = Color.FromRgb(158, 69, 235);
        private static Color _pink = Color.FromRgb(235, 99, 174);

        public static SolidColorBrush Red { get { return new SolidColorBrush(_red); } }
        public static SolidColorBrush Orange { get { return new SolidColorBrush(_orange); } }
        public static SolidColorBrush Yellow { get { return new SolidColorBrush(_yellow); } }
        public static SolidColorBrush Green { get { return new SolidColorBrush(_green); } }
        public static SolidColorBrush Aqua { get { return new SolidColorBrush(_aqua); } }
        public static SolidColorBrush Blue { get { return new SolidColorBrush(_blue); } }
        public static SolidColorBrush Purple { get { return new SolidColorBrush(_purple); } }
        public static SolidColorBrush Pink { get { return new SolidColorBrush(_pink); } }
        public static SolidColorBrush[] Colors = new SolidColorBrush[]
        {
           new SolidColorBrush(_red),
           new SolidColorBrush(_orange),
           new SolidColorBrush(_yellow),
           new SolidColorBrush(_green),
           new SolidColorBrush(_aqua),
           new SolidColorBrush(_blue),
           new SolidColorBrush(_purple),
           new SolidColorBrush(_pink)
        };
    }
}
