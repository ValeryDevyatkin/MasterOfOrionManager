using System.Windows;

namespace OrionManager.Views.Controls
{
    internal partial class CustomButton
    {
        public CustomButton()
        {
            InitializeComponent();
        }

        #region BorderRadius dependency: CornerRadius

        public static readonly DependencyProperty BorderRadiusProperty =
            DependencyProperty.Register(
                nameof(BorderRadius),
                typeof(CornerRadius),
                typeof(CustomButton),
                new PropertyMetadata(default(CornerRadius)));

        public CornerRadius BorderRadius
        {
            get => (CornerRadius) GetValue(BorderRadiusProperty);
            set => SetValue(BorderRadiusProperty, value);
        }

        #endregion
    }
}