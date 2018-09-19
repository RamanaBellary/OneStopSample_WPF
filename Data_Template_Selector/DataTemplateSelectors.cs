using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OneStopSample.DTS
{
    public class GradeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PassedTemplateInCodeBehind
        { get; set; }

        public DataTemplate FailedTemplateInCodeBehind
        { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Student student = item as Student;

            if (student != null)
            {
                if (student.Percentage >= 60)
                    return PassedTemplateInCodeBehind;
                else
                    return FailedTemplateInCodeBehind;
            }
            else
                return base.SelectTemplate(item, container);
        }
    }

    public class Student
    {
        public Student(int id, String firstName, String lastName, Double percentage)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Percentage = percentage;
        }

        public int ID
        { get; set; }

        public String FirstName
        { get; set; }

        public String LastName
        { get; set; }

        public Double Percentage
        { get; set; }
    }
}
