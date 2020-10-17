using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using OrionManager.Constants;
using OrionManager.ViewModels;

namespace OrionManager.Converters
{
    internal class GameConfigurationToDisplayTextConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is GameConfigurationViewModel viewModel))
            {
                return value;
            }

            string displayedText;

            if (viewModel.Id == GlobalConstants.DefaultGameConfigurationId)
            {
                displayedText = viewModel.Name;
            }
            else
            {
                var displayedName =
                    string.IsNullOrWhiteSpace(viewModel.Name) ? viewModel.Id.ToString() : viewModel.Name;

                displayedText = $"{displayedName} ({viewModel.SaveTime})";
            }

            return displayedText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}