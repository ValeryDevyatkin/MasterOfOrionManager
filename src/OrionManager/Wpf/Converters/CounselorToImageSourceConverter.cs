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
    internal class CounselorToImageSourceConverter : MarkupExtension, IValueConverter
    {
        private static readonly IReadOnlyDictionary<Counselors, string> CounselorIconMap =
            new Dictionary<Counselors, string>
            {
                {Counselors.None, CounselorIconKeys.None},
                {Counselors.Advia, CounselorIconKeys.Advia},
                {Counselors.Alluvia, CounselorIconKeys.Alluvia},
                {Counselors.Harrava, CounselorIconKeys.Harrava},
                {Counselors.Kual, CounselorIconKeys.Kual},
                {Counselors.Moldred, CounselorIconKeys.Moldred},
                {Counselors.Kuruk, CounselorIconKeys.Kuruk},
                {Counselors.Veil, CounselorIconKeys.Veil},
                {Counselors.Viktoria, CounselorIconKeys.Viktoria}
            };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Counselors counselor)
            {
                return Application.Current.Resources[CounselorIconMap[counselor]];
            }

            throw new ArgumentException(nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}