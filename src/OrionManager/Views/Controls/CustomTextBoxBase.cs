using System.Windows;
using System.Windows.Controls;

namespace OrionManager.Views.Controls
{
    internal abstract class CustomTextBoxBase : TextBox
    {
        #region Label dependency: string

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(
                nameof(Label),
                typeof(string),
                typeof(CustomTextBoxBase),
                new PropertyMetadata(default(string)));

        public string Label
        {
            get => (string) GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        #endregion

        #region Tip dependency: string

        public static readonly DependencyProperty TipProperty =
            DependencyProperty.Register(
                nameof(Tip),
                typeof(string),
                typeof(CustomTextBoxBase),
                new PropertyMetadata(default(string)));

        public string Tip
        {
            get => (string) GetValue(TipProperty);
            set => SetValue(TipProperty, value);
        }

        #endregion
    }
}