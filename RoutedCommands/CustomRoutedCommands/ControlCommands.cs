using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneStopSample.RoutedCommands.CustomRoutedCommands
{
    public static class ControlCommands
    {
        private static RoutedCommand updateTextCommand = new RoutedCommand();
        public static RoutedCommand UpdateTextCommand
        {
            get
            {
                return updateTextCommand;
            }
        }
    }
}
