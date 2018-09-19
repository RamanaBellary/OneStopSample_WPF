using OneStopSample.Utils;
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

namespace OneStopSample.Behaviours
{
    /// <summary>
    /// Interaction logic for DoubleClickUsingBehaviourAndDP.xaml
    /// </summary>
    public partial class DoubleClickUsingBehaviourAndDP : UserControl
    {
        public DoubleClickUsingBehaviourAndDP()
        {
            InitializeComponent();
            this.DataContext = new DoubleClickUsingBehaviourAndDPVM();
        }
    }

    public class DoubleClickUsingBehaviourAndDPVM
    {
        public DoubleClickUsingBehaviourAndDPVM()
        {
            ImageDoubleClick = new RelayCommand(HandleImageDoubleClick);
        }

        private ICommand imageDoubeClick;
        public ICommand ImageDoubleClick
        {
            get { return imageDoubeClick; }
            set
            {
                imageDoubeClick = value;
            }
        }

        public void HandleImageDoubleClick(object obj)
        {

        }
    }
}
