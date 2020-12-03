using System.Windows;

namespace OrionManager.Views.Controls
{
    internal partial class CustomTextBox
    {
        public CustomTextBox()
        {
            InitializeComponent();
        }

        #region Label dependency: string

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(
                nameof(Label),
                typeof(string),
                typeof(CustomTextBox),
                new PropertyMetadata(default(string)));

        public string Label
        {
            get => (string) GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        #endregion
    }
}