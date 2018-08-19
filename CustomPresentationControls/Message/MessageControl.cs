using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomPresentationControls.Message
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomPresentationControls.Message"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomPresentationControls.Message;assembly=CustomPresentationControls.Message"
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
    ///     <MyNamespace:MessageControl/>
    ///
    /// </summary>
    public class MessageControl : Control
    {
        public ImageSource Icon
        {
            get { return GetValue(IconProperty) as ImageSource; }
            set { SetValue(IconProperty, value); }
        }
        public string Caption
        {
            get { return GetValue(CaptionProperty) as string; }
            set { SetValue(CaptionProperty, value); }
        }
        public string Message
        {
            get { return GetValue(MessageProperty) as string; }
            set { SetValue(MessageProperty, value); }
        }
        public Visibility InfoVisibility
        {
            get { return (Visibility)Enum.Parse(typeof(Visibility), GetValue(InfoVisibilityProperty).ToString()); }
            set { SetValue(InfoVisibilityProperty, value); }
        }
        public Visibility WarningVisibility
        {
            get { return (Visibility)Enum.Parse(typeof(Visibility), GetValue(WarningVisibilityProperty).ToString()); }
            set { SetValue(WarningVisibilityProperty, value); }
        }
        public Visibility ErrorVisibility
        {
            get { return (Visibility)Enum.Parse(typeof(Visibility), GetValue(ErrorVisibilityProperty).ToString()); }
            set { SetValue(ErrorVisibilityProperty, value); }
        }
        public Visibility OKVisibility
        {
            get { return (Visibility)Enum.Parse(typeof(Visibility), GetValue(OKVisibilityProperty).ToString()); }
            set { SetValue(OKVisibilityProperty, value); }
        }
        public Visibility CancelVisibility
        {
            get { return (Visibility)Enum.Parse(typeof(Visibility), GetValue(CancelVisibilityProperty).ToString()); }
            set { SetValue(CancelVisibilityProperty, value); }
        }
        public Visibility YesNoVisibility
        {
            get { return (Visibility)Enum.Parse(typeof(Visibility), GetValue(YesNoVisibilityProperty).ToString()); }
            set { SetValue(YesNoVisibilityProperty, value); }
        }
        public ICommand CommitCommand
        {
            get { return (ICommand)GetValue(CommitCommandProperty); }
            set { SetValue(CommitCommandProperty, value); }
        }
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        public static DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty InfoVisibilityProperty = DependencyProperty.Register("InfoVisibility", typeof(Visibility), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty WarningVisibilityProperty = DependencyProperty.Register("WarningVisibility", typeof(Visibility), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty ErrorVisibilityProperty = DependencyProperty.Register("ErrorVisibility", typeof(Visibility), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty OKVisibilityProperty = DependencyProperty.Register("OKVisibility", typeof(Visibility), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty CancelVisibilityProperty = DependencyProperty.Register("CancelVisibility", typeof(Visibility), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty YesNoVisibilityProperty = DependencyProperty.Register("YesNoVisibility", typeof(Visibility), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty CommitCommandProperty = DependencyProperty.Register("CommitCommand", typeof(ICommand), typeof(MessageControl), new PropertyMetadata(null));
        public static DependencyProperty CancelCommandProperty = DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(MessageControl), new PropertyMetadata(null));
        static MessageControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageControl), new FrameworkPropertyMetadata(typeof(MessageControl)));
        }
        public MessageControl()
        {
            InfoVisibility = Visibility.Collapsed;
            WarningVisibility = Visibility.Collapsed;
            ErrorVisibility = Visibility.Collapsed;
            OKVisibility = Visibility.Visible;
            CancelVisibility = Visibility.Collapsed;
            YesNoVisibility = Visibility.Collapsed;
        }
        public void SetMessageType(MessageIcon messageType)
        {
            switch (messageType)
            {
                case MessageIcon.Information:
                    InfoVisibility = Visibility.Visible;
                    WarningVisibility = Visibility.Collapsed;
                    ErrorVisibility = Visibility.Collapsed;
                    break;
                case MessageIcon.Warning:
                    InfoVisibility = Visibility.Collapsed;
                    WarningVisibility = Visibility.Visible;
                    ErrorVisibility = Visibility.Collapsed;
                    break;
                case MessageIcon.Error:
                    InfoVisibility = Visibility.Collapsed;
                    WarningVisibility = Visibility.Collapsed;
                    ErrorVisibility = Visibility.Visible;
                    break;
            }
        }
        public void SetButtonType(MessageBoxButton buttonType)
        {
            switch (buttonType)
            {
                case MessageBoxButton.OK:
                    OKVisibility = Visibility.Visible;
                    CancelVisibility = Visibility.Collapsed;
                    YesNoVisibility = Visibility.Collapsed;
                    break;
                case MessageBoxButton.OKCancel:
                    OKVisibility = Visibility.Visible;
                    CancelVisibility = Visibility.Visible;
                    YesNoVisibility = Visibility.Collapsed;
                    break;
                case MessageBoxButton.YesNo:
                    OKVisibility = Visibility.Collapsed;
                    CancelVisibility = Visibility.Collapsed;
                    YesNoVisibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    OKVisibility = Visibility.Collapsed;
                    CancelVisibility = Visibility.Visible;
                    YesNoVisibility = Visibility.Visible;
                    break;

            }
        }
    }
}
