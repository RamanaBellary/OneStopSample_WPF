using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OneStopSample.Converters
{
    public class MultiValueConverterEx : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string x = "";
            foreach (var v in values)
                x += " " + v.ToString();
            return x;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return null;
            string str = (string)value;
            string[] val = str.Split(' ');
            return val;
        }
    }
}
