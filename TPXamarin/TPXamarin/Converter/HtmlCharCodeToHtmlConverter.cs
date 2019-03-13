using System;
using System.Globalization;
using System.Net;
using Xamarin.Forms;

namespace TPXamarin.Converter
{
    public class HtmlCharCodeToHtmlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return WebUtility.HtmlDecode((string) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return WebUtility.HtmlEncode((string) value);
        }
    }
}
