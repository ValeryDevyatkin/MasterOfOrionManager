using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using OrionManager.Common.Enums;
using OrionManager.Views.Backgrounds;
using Senticode.Wpf;
using Unity;

namespace OrionManager.Wpf.Converters
{
    internal class UiRegionToBackgroundControlConverter : MarkupExtension, IValueConverter
    {
        private static readonly Dictionary<UiRegions, Type> RegionMap = new Dictionary<UiRegions, Type>
        {
            {UiRegions.Home, typeof(HomeBackground)},
            {UiRegions.PreStart, typeof(PreStartBackground)},
            {UiRegions.Configuration, typeof(ConfigurationBackground)},
            {UiRegions.ConfigurationList, typeof(ConfigurationListBackground)},
            {UiRegions.Playing, typeof(PlayingBackground)},
            {UiRegions.Score, typeof(ScoreBackground)}
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is UiRegions region)
            {
                return ServiceLocator.Container.Resolve(RegionMap[region]);
            }

            throw new ArgumentException(nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}