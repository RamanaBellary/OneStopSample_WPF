using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStopSample.Model
{
    public class Customer : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(name != value)
                {
                    name = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age != value)
                {
                    age = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Age"));
                }
            }
        }

        private string address1;
        public string Address1
        {
            get
            {
                return address1;
            }
            set
            {
                if (address1 != value)
                {
                    address1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Address1"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged=delegate { };
    }
}
