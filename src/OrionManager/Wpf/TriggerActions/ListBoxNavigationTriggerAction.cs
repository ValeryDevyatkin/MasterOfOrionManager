using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using BAJIEPA.Tools.Helpers;

namespace OrionManager.Wpf.TriggerActions
{
    internal class ListBoxNavigationTriggerAction : TriggerAction<UIElement>
    {
        protected override void Invoke(object parameter)
        {
            if (ListBox == null)
            {
                throw new ArgumentNullException(nameof(ListBox));
            }

            if (ItemToNavigate == null)
            {
                throw new ArgumentException(nameof(ItemToNavigate));
            }

            try
            {
                ListBox.SelectedItem = ItemToNavigate;
                ListBox.ScrollIntoView(ListBox.SelectedItem);
                ListBox.Focus();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);
            }
        }

        #region ListBox dependency: ListBox

        public static readonly DependencyProperty ListBoxProperty =
            DependencyProperty.Register(
                nameof(ListBox),
                typeof(ListBox),
                typeof(ListBoxNavigationTriggerAction),
                new PropertyMetadata(default(ListBox)));

        public ListBox ListBox
        {
            get => (ListBox) GetValue(ListBoxProperty);
            set => SetValue(ListBoxProperty, value);
        }

        #endregion

        #region ItemToNavigate dependency: object

        public static readonly DependencyProperty ItemToNavigateProperty =
            DependencyProperty.Register(
                nameof(ItemToNavigate),
                typeof(object),
                typeof(ListBoxNavigationTriggerAction),
                new PropertyMetadata(default(object)));

        public object ItemToNavigate
        {
            get => GetValue(ItemToNavigateProperty);
            set => SetValue(ItemToNavigateProperty, value);
        }

        #endregion
    }
}