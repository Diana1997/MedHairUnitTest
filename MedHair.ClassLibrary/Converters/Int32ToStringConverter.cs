using System;
using System.Globalization;
using System.Windows.Data;

namespace MedHair.ClassLibrary.Converters
{
    public class Int32ToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => System.Convert.ToInt32(value).ToString();

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int res;
            Int32.TryParse((string)value, out res);
            return res;
        }
    }
}
