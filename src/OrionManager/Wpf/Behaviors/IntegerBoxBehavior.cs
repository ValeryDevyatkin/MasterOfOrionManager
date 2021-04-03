using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace OrionManager.Wpf.Behaviors
{
    internal class IntegerBoxBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewKeyDown += AssociatedObjectOnPreviewKeyDown;
            AssociatedObject.LostFocus += AssociatedObjectOnLostFocus;
            AssociatedObject.TextChanged += AssociatedObjectOnTextChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PreviewKeyDown -= AssociatedObjectOnPreviewKeyDown;
            AssociatedObject.LostFocus -= AssociatedObjectOnLostFocus;
            AssociatedObject.TextChanged -= AssociatedObjectOnTextChanged;
        }

        private void AssociatedObjectOnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(AssociatedObject.Text) &&
                AssociatedObject.Text != "-")
            {
                UpdateBinding();
            }
        }

        private void AssociatedObjectOnLostFocus(object sender, RoutedEventArgs e)
        {
            UpdateBinding();
        }

        private void AssociatedObjectOnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateBinding();
            }

            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void UpdateBinding()
        {
            AssociatedObject.TextChanged -= AssociatedObjectOnTextChanged;
            AssociatedObject.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
            AssociatedObject.TextChanged += AssociatedObjectOnTextChanged;
        }
    }
}