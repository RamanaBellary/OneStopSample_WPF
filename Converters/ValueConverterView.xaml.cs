using System;
using System.Collections.Generic;
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

namespace OneStopSample.Converters
{
    /// <summary>
    /// Interaction logic for IValueConverterView.xaml
    /// </summary>
    public partial class ValueConverterView : UserControl
    {
        public ValueConverterView()
        {
            InitializeComponent();
        }

        public string VisiblityString { get; set; }
    }
}
