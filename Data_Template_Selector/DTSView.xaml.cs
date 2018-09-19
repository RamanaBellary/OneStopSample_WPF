using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace OneStopSample.DTS
{
    /// <summary>
    /// Interaction logic for DTSView.xaml
    /// </summary>
    public partial class DTSView : UserControl
    {
        ObservableCollection<Student> students = new ObservableCollection<Student>();
        public DTSView()
        {
            InitializeComponent();
            students.Add(new Student(10, "Bob", "Smith", 80.5));

            students.Add(new Student(25, "James", "Brown", 77.9));

            students.Add(new Student(15, "Joe", "Martin", 52.4));

            students.Add(new Student(12, "Dona", "Taylor", 53.6));

            students.Add(new Student(18, "Peter", "Brian", 90.9));


            DataContext = students;
        }
    }
}
