using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OneStopSample.DataTemplates
{
    /// <summary>
    /// Interaction logic for DataTemplateView.xaml
    /// </summary>
    public partial class DataTemplateView : UserControl
    {
        public ObservableCollection<Person> Persons { get; set; }
        public DataTemplateView()
        {
            InitializeComponent();
            Persons = new ObservableCollection<Person>
            {
                new Person { Name = "Person one",Age = 30 },
                new Person {Name = "Person two", Age = 25 }
            };
            this.DataContext = this;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
