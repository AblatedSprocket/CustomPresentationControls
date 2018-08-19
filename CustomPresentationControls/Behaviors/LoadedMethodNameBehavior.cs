using System.Reflection;
using System.Windows;

namespace CustomPresentationControls.Behaviors
{
    public class LoadedMethodNameBehavior
    {
        public static string GetLoadedMethodName(DependencyObject depObj)
        {
            return (string)depObj.GetValue(LoadedMethodNameProperty);
        }
        public static void SetLoadedMethodName(DependencyObject depObj, string value)
        {
            depObj.SetValue(LoadedMethodNameProperty, value);
        }
        public static readonly DependencyProperty LoadedMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadedMethodName", typeof(string), typeof(LoadedMethodNameBehavior), new PropertyMetadata(null, OnLoadedMethodNameChanged));

        private static void OnLoadedMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            if (element != null)
            {
                element.Loaded += (s, e2) =>
                {
                    object viewModel = element.DataContext;
                    if (viewModel == null)
                    {
                        return;
                    }
                    MethodInfo methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo == null)
                    {
                        return;
                    }
                    methodInfo.Invoke(viewModel, null);
                };
            }
        }
    }
}
