using OneStopSample.Model;
using OneStopSample.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneStopSample.Command
{
    public class CommandUserControlViewModel : INotifyPropertyChanged
    {
        public CommandUserControlViewModel()
        {
            DeleteCommand = new RelayCommand(Delete, canDelete);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>
            {
                new Customer {Name="Vishal",Age=4,Address1="address1" },
                new Customer {Name="Vimal",Age=4,Address1="address1" },
                new Customer {Name="abc",Age=20,Address1="asdfsa" },
                new Customer {Name="xyz",Age=30,Address1="werwqr" }
            };
        }

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set
            {
                if (customers != value)
                {
                    customers = value;
                    RaisePropertyChanged("Customers");
                }
            }
        }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                deleteCommand = value;
            }
        }

        private bool canDelete(object param)
        {
            return selectedCustomer != null;
        }

        public void Delete(object param)
        {
            if (selectedCustomer != null)
                customers.Remove(selectedCustomer);
        }
    }    

    public class C2
    {
        private C2(int i)
        { }
    }
}
