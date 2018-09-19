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

namespace OneStopSample.Resources
{
    /// <summary>
    /// Interaction logic for StaticAndDyanmicResources.xaml
    /// </summary>
    public partial class StaticAndDyanmicResources : UserControl
    {
        public StaticAndDyanmicResources()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush scb1 = new SolidColorBrush(Colors.Green);
            this.Resources["backGroundColor"] = scb1;

            SolidColorBrush scb2 = new SolidColorBrush(Colors.Yellow);
            this.Resources["foreGroundColor"] = scb2;
        }
    }
}
