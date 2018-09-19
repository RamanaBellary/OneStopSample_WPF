using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace OneStopSample.Converters
{
    public class VisibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cmb = value as ComboBoxItem;
            var s = cmb?.Content.ToString();
            if (!string.IsNullOrEmpty(s))
            {
                if (s == "Collapse")
                    return Visibility.Collapsed;
                else if (s == "Hide")
                    return Visibility.Hidden;
                else
                    return Visibility.Visible;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
