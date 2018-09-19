using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace OneStopSample.StylesAndTriggers
{
    /// <summary>
    /// Interaction logic for StylesAndTriggersView.xaml
    /// </summary>
    public partial class StylesAndTriggersView : UserControl, INotifyPropertyChanged
    {
        public StylesAndTriggersView()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private bool isCheckBoxChecked = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsCheckBoxChecked { get { return isCheckBoxChecked; }
            set
            {
                isCheckBoxChecked = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsCheckBoxChecked"));
            }
        }
    }
}
