using System.Windows.Controls;
using System.Windows.Interactivity;

namespace OrionManager.Wpf.Behaviors
{
    internal class ListBoxAutoScrollBehavior : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.SelectionChanged += AssociatedObjectOnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.SelectionChanged -= AssociatedObjectOnSelectionChanged;
        }

        private void AssociatedObjectOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AssociatedObject.ScrollIntoView(AssociatedObject.SelectedItem);
        }
    }
}