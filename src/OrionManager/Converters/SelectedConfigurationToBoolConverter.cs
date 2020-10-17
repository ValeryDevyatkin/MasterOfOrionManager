using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using OrionManager.Constants;
using OrionManager.ViewModels;

namespace OrionManager.Converters
{
    internal class SelectedConfigurationToBoolConverter : MarkupExtension, IValueConverter
    {
        public bool IsDefaultConfigurationCheckRequired { get; set; } = true;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is GameConfigurationViewModel viewModel))
            {
                return false;
            }

            return !(IsDefaultConfigurationCheckRequired &&
                     viewModel.Id == GlobalConstants.DefaultGameConfigurationId);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}