using CustomPresentationControls.ColorPick;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomPresentationControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomPresentationControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomPresentationControls;assembly=CustomPresentationControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ColorPicker/>
    ///
    /// </summary>
    public class ColorPicker : Control
    {
        public SolidColorBrush Color
        {
            get { return (SolidColorBrush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public int RedPick
        {
            get { return (int)GetValue(RedPickProperty); }
            set
            {
                SetValue(RedPickProperty, value);
            }
        }
        public int GreenPick
        {
            get { return (int)GetValue(GreenPickProperty); }
            set
            {
                SetValue(GreenPickProperty, value);
                RedGradient = new LinearGradientBrush(System.Windows.Media.Color.FromRgb(0, Convert.ToByte(GreenPick), Convert.ToByte(BluePick)), System.Windows.Media.Color.FromRgb(255, Convert.ToByte(GreenPick), Convert.ToByte(BluePick)), 0);
                BlueGradient = new LinearGradientBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(RedPick), Convert.ToByte(GreenPick), 0), System.Windows.Media.Color.FromRgb(Convert.ToByte(RedPick), Convert.ToByte(GreenPick), 255), 0);
            }
        }
        public int BluePick
        {
            get { return (int)GetValue(BluePickProperty); }
            set
            {
                SetValue(BluePickProperty, value);
                RedGradient = new LinearGradientBrush(System.Windows.Media.Color.FromRgb(0, Convert.ToByte(GreenPick), Convert.ToByte(BluePick)), System.Windows.Media.Color.FromRgb(255, Convert.ToByte(GreenPick), Convert.ToByte(BluePick)), 0);
                GreenGradient = new LinearGradientBrush(System.Windows.Media.Color.FromRgb(Convert.ToByte(RedPick), 0, Convert.ToByte(BluePick)), System.Windows.Media.Color.FromRgb(Convert.ToByte(RedPick), 255, Convert.ToByte(BluePick)), 0);
            }
        }
        public LinearGradientBrush RedGradient
        {
            get { return (LinearGradientBrush)GetValue(RedGradientProperty); }
            set { SetValue(RedGradientProperty, value); }
        }
        public LinearGradientBrush GreenGradient
        {
            get { return (LinearGradientBrush)GetValue(GreenGradientProperty); }
            set { SetValue(GreenGradientProperty, value); }
        }
        public LinearGradientBrush BlueGradient
        {
            get { return (LinearGradientBrush)GetValue(BlueGradientProperty); }
            set { SetValue(BlueGradientProperty, value); }
        }
        public static DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(SolidColorBrush), typeof(ColorPicker), new PropertyMetadata(null));
        public static DependencyProperty RedPickProperty = DependencyProperty.Register("RedPick", typeof(int), typeof(ColorPicker), new PropertyMetadata(0, OnRedChanged));
        public static DependencyProperty GreenPickProperty = DependencyProperty.Register("GreenPick", typeof(int), typeof(ColorPicker), new PropertyMetadata(0));
        public static DependencyProperty BluePickProperty = DependencyProperty.Register("BluePick", typeof(int), typeof(ColorPicker), new PropertyMetadata(0));
        public static DependencyProperty RedGradientProperty = DependencyProperty.Register("RedGradient", typeof(LinearGradientBrush), typeof(ColorPicker), new PropertyMetadata(null));
        public static DependencyProperty GreenGradientProperty = DependencyProperty.Register("GreenGradient", typeof(LinearGradientBrush), typeof(ColorPicker), new PropertyMetadata(null));
        public static DependencyProperty BlueGradientProperty = DependencyProperty.Register("BlueGradient", typeof(LinearGradientBrush), typeof(ColorPicker), new PropertyMetadata(null));
        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }
        public ColorPicker()
        {
            //Color = Colors.Red;
            Color = new SolidColorBrush(Colors.Red);
        }
        private static void OnRedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
