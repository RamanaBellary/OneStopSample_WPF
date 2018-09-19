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

namespace OneStopSample.ControlTemplate
{
    /// <summary>
    /// Interaction logic for ControlTemplateView.xaml
    /// </summary>
    public partial class ControlTemplateView : UserControl
    {
        public ControlTemplateView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I am button..");
        }
    }
}
