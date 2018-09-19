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

namespace OneStopSample.RoutedCommands.CustomRoutedCommands
{
    /// <summary>
    /// Interaction logic for CustomRoutedCommandView.xaml
    /// </summary>
    public partial class CustomRoutedCommandView : UserControl
    {
        public CustomRoutedCommandView()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(ControlCommands.UpdateTextCommand, ExecuteUpdateText, CanExecuteUpdateText));
        }

        private void CanExecuteUpdateText(object sender, CanExecuteRoutedEventArgs e)
        {
            var param = e.Parameter as string;
            if (param != null)
                e.CanExecute = true;
        }

        private void ExecuteUpdateText(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock tb = e.OriginalSource as TextBlock;
            tb.Text = e.Parameter as string;
        }
    }
}
