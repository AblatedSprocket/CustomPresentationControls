using System.Windows.Media;

namespace CustomPresentationControls.ColorPick
{
    class ColorSelectedEventArgs
    {
        public Color ChosenColor { get; set; }
        public ColorSelectedEventArgs() { }
        public ColorSelectedEventArgs(Color color)
        {
            ChosenColor = color;
        }
    }
}
