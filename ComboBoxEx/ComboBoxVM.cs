using OneStopSample.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace OneStopSample.ComboBoxEx
{
    public class Country : INotifyPropertyChanged
    {
        private int id;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID"));
            }
        }

        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
    }
    
    public class User : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        private int countryID;
        public int CountryID
        {
            get { return countryID; }
            set
            {
                countryID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CountryID"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class ComboBoxVM
    {
        public ComboBoxVM()
        {
            countries = new ObservableCollection<Country>()
            {
                new Country { ID = 1, Name = "India" },
                new Country { ID = 2, Name = "UK" },
                new Country { ID = 3, Name = "Austraila" }
            };

            users = new ObservableCollection<User>()
            {
                new User {Id=1,Name="Vishal",CountryID=1 },
                new User {Id=2,Name="Vimal",CountryID=1 },
                new User {Id=3,Name="Mouni",CountryID=3 },
                new User {Id=4,Name="Ramana",CountryID=2 },
            };

            invokeCmd = new RelayCommand(Invoke,null);
        }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Users"));
            }
        }

        private ObservableCollection<Country> countries;
        public ObservableCollection<Country> Countries
        {
            get { return countries; }
            set
            {
                countries = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Countries"));
            }
        }

        private Country country;
        public Country Country
        {
            get { return country; }
            set
            {
                country = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Country"));
            }
        }

        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("User"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand invokeCmd;
        public ICommand InvokeCmd
        {
            get { return invokeCmd; }
            set
            {
                invokeCmd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InvokeCmd"));
            }
        }

        private void Invoke(object param)
        {
            string s = "";s.Split(new char[] { ' ' });
        }
    }

    public class CountryConverter : IValueConverter
    {
        static List<Country> Countries = new List<Country>()
            {
                new Country { ID = 1, Name = "India" },
                new Country { ID = 2, Name = "UK" },
                new Country { ID = 3, Name = "Austraila" }
            };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            int val = 0;
            int.TryParse(value.ToString(), out val);
            var country = Countries.Where(c => c.ID == val).FirstOrDefault();
            if (country != null)
                return country.Name;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
