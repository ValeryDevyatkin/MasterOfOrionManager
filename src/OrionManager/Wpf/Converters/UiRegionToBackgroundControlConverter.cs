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
            {UiRegions.Start, typeof(StartBackground)},
            {UiRegions.PreStart, typeof(PreStartBackground)},
            {UiRegions.Configuration, typeof(ConfigurationBackground)},
            {UiRegions.ConfigurationList, typeof(ConfigurationListBackground)},
            {UiRegions.Playing, typeof(PlayingBackground)}
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is UiRegions region))
            {
                throw new NotSupportedException();
            }

            return ServiceLocator.Container.Resolve(RegionMap[region]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}