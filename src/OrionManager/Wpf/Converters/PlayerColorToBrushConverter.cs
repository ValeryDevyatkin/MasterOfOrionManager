using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using OrionManager.Common.Enums;

namespace OrionManager.Wpf.Converters
{
    internal class PlayerColorToBrushConverter : MarkupExtension, IValueConverter
    {
        private static readonly IReadOnlyDictionary<PlayerColors, Brush> PlayerColorMap =
            new Dictionary<PlayerColors, Brush>
            {
                {PlayerColors.Red, Brushes.Red},
                {PlayerColors.Green, Brushes.Green},
                {PlayerColors.Blue, Brushes.Blue},
                {PlayerColors.Yellow, Brushes.Yellow}
            };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is PlayerColors playerColor))
            {
                throw new ArgumentException(nameof(value));
            }

            return PlayerColorMap[playerColor];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}