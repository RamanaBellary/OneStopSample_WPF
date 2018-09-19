using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneStopSample.Validation
{
    /// <summary>
    /// Interaction logic for INotifyDataErrorInfoView.xaml
    /// </summary>
    public partial class INotifyDataErrorInfoView : UserControl
    {
        public INotifyDataErrorInfoView()
        {
            InitializeComponent();
            this.DataContext = new Customer { Name = "Ramana Bellary", Address = "Rammurthy nagar Bangalore", Age = 20 };
        }
    }

    public class IErrorsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var collection = value as IEnumerable<ValidationError>;
            
            return string.Join(Environment.NewLine,collection.Select(e=>e.ErrorContent));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
