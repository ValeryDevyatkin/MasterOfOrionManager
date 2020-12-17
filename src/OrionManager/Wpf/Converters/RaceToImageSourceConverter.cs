using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using OrionManager.Common.Enums;
using OrionManager.Constants;

namespace OrionManager.Wpf.Converters
{
    internal class RaceToImageSourceConverter : MarkupExtension, IValueConverter
    {
        private static readonly IReadOnlyDictionary<Races, string>
            RaceIconMap = new Dictionary<Races, string>
            {
                {Races.Random, RaceIconKeys.Random},
                {Races.Mrrshan, RaceIconKeys.Mrrshan},
                {Races.Meklar, RaceIconKeys.Meklar},
                {Races.Human, RaceIconKeys.Human},
                {Races.Bulrathi, RaceIconKeys.Bulrathi},
                {Races.Darlok, RaceIconKeys.Darlok},
                {Races.Psilon, RaceIconKeys.Psilon},
                {Races.Alkari, RaceIconKeys.Alkari}
            };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Races race)
            {
                return Application.Current.Resources[RaceIconMap[race]];
            }

            throw new ArgumentException(nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}