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

namespace OneStopSample.AttachedProperties
{
    /// <summary>
    /// Interaction logic for ChangeControlBackgroundViaADP.xaml
    /// </summary>
    public partial class ChangeControlBackgroundViaADP : UserControl, INotifyPropertyChanged
    {
        public ChangeControlBackgroundViaADP()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool changeBackground = false;
        public bool ChangeBackground
        {
            get
            { return changeBackground; }
            set
            {
                changeBackground = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ChangeBackground"));
            }
        }

        private bool isReadOnly = false;
        public bool IsReadOnly
        {
            get
            { return isReadOnly; }
            set
            {
                isReadOnly = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsReadOnly"));
            }
        }
    }
}
