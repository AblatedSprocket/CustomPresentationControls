using CustomPresentationControls.Message;
using CustomPresentationControls.Utilities;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomPresentationControls
{
    public enum MessageIcon
    {
        Information,
        Warning,
        Error,
        None
    }
    public static class WpfMessageBox
    {
        #region Fields
        private static Window _messageWindow;
        #endregion
        public static bool? ShowDialog(string message) { return ShowDialog(null, message, MessageBoxButton.OK); }
        public static bool? ShowDialog(string caption, string message) { return ShowDialog(caption, message, MessageBoxButton.OK); }
        public static bool? ShowDialog(string message, MessageBoxButton buttons) { return ShowDialog(null, message, buttons); }
        public static bool? ShowDialog(string caption, string message, MessageBoxButton buttons) { return ShowDialog(caption, message, buttons, MessageIcon.None); }
        public static bool? ShowDialog(string caption, string message, MessageBoxButton buttons, MessageIcon messageIcon)
        {
            _messageWindow = new Window();
            _messageWindow.SizeToContent = SizeToContent.WidthAndHeight;
            MessageControl messageControl = new MessageControl
            {
                Caption = caption,
                Message = message,
                CommitCommand = new RelayCommand(OnCommit),
                CancelCommand = new RelayCommand(OnCancel),
            };
            messageControl.SetMessageType(messageIcon);
            messageControl.SetButtonType(buttons);
            _messageWindow.Content = messageControl;
            return _messageWindow.ShowDialog();
        }
        //public static bool? ShowDialog(string caption, string message, MessageIcon messageIcon, MessageBoxButton buttons)
        //{
        //    Window window = new Window();
        //    window.SizeToContent = SizeToContent.WidthAndHeight;
        //    window.Title = messageIcon.ToString();
        //    MessageControl messageControl = new MessageControl
        //    {
        //        Caption = caption,
        //        Message = message,
        //        CommitCommand = new RelayCommand(OnCommit),
        //        CancelCommand = new RelayCommand(OnCancel),
        //    };
        //    messageControl.SetMessageType(messageIcon);
        //    messageControl.SetButtonType(buttons);
        //    window.Content = messageControl;
        //    return window.ShowDialog();
        //}
        private static void OnCommit()
        {
            _messageWindow.DialogResult = true;
        }
        private static void OnCancel()
        {
            _messageWindow.DialogResult = false;
        }
    }
}
