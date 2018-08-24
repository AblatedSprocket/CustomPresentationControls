using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace CustomPresentationControls.Utilities
{
    public static class Extensions
    {
        public static object FindNearestAncestorTag(this FrameworkElement child)
        {
            if (child != null)
            {
                FrameworkElement parent = VisualTreeHelper.GetParent(child) as FrameworkElement;
                if (parent.Tag != null)
                {
                    return parent.Tag;
                }
                else
                {
                    return FindNearestAncestorTag(parent);
                }
            }
            else
            {
                return null;
            }
        }
        public static object FindNthNearestAncestorTag(this FrameworkElement child, int n)
        {
            int tagCount = 0;
            if (child != null)
            {
                FrameworkElement parent = null;
                do
                {
                    parent = VisualTreeHelper.GetParent(child) as FrameworkElement;
                    if (parent != null && parent.Tag != null)
                    {
                        if (++tagCount == n)
                        {
                            return parent.Tag;
                        }
                        child = parent;
                    }
                } while (parent != null);
            }
            return null;
        }
        public static T FindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            if (child != null)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(child);
                if (parent is T)
                {
                    return parent as T;
                }
                else
                {
                    return FindParent<T>(parent);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
