using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using OrionManager.Enums;
using OrionManager.ExtensionMethods;

namespace OrionManager.Wpf.Converters
{
    internal class PlayerColorToBrushConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is PlayerColor playerColor))
            {
                throw new ArgumentException(nameof(value));
            }

            return playerColor.ToBrush();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}