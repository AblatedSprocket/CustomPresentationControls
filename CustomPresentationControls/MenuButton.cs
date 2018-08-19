using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace CustomPresentationControls
{
    public class MenuButton : ToggleButton
    {
        static MenuButton()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuButton), new FrameworkPropertyMetadata(typeof(MenuButton)));
        }
        public MenuButton()
        {
            Binding binding = new Binding("Menu.IsOpen");
            binding.Source = this;
            this.SetBinding(IsCheckedProperty, binding);
            DataContextChanged += (sender, args) =>
            {
                if (Menu != null)
                {
                    Menu.DataContext = DataContext;
                }
            };
        }
        public ContextMenu Menu
        {
            get { return (ContextMenu)GetValue(MenuProperty); }
            set { SetValue(MenuProperty, value); }
        }
        public static readonly DependencyProperty MenuProperty = DependencyProperty.Register("Menu", typeof(ContextMenu), typeof(MenuButton), new PropertyMetadata(null, OnMenuChanged));
        private static void OnMenuChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuButton button = d as MenuButton;
            ContextMenu contextMenu = e.NewValue as ContextMenu;
            contextMenu.DataContext = button.DataContext;
        }
        protected override void OnClick()
        {
            if (Menu != null)
            {
                Menu.PlacementTarget = this;
                Menu.Placement = PlacementMode.Bottom;
                Menu.IsOpen = true;
            }
        }
    }
}
