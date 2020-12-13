using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using OrionManager.Common.Constants;
using OrionManager.ViewModel.ViewModels;

namespace OrionManager.Wpf.Converters
{
    internal class GameConfigurationDisplayTextConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is GameConfigurationViewModel configuration))
            {
                throw new ArgumentException(nameof(value));
            }

            return configuration.Id == GlobalConstants.DefaultGameConfigurationId ?
                       configuration.Name :
                       $"{configuration.Name} ({configuration.SaveTime})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}