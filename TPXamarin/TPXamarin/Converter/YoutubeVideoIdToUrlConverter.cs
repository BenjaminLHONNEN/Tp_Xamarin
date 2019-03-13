using System;
using System.Globalization;
using Xamarin.Forms;

namespace TPXamarin.Converter
{
    public class YoutubeVideoIdToUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"https://www.youtube.com/embed/{((string) value)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
