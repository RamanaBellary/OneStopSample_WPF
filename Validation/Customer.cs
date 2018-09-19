using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OneStopSample.Validation
{
    public class Customer : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        //TODO: The validation is not firing for the first time.
        private string name;
        //[Required]
        //[StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Name field is required, min lenght is 6 and max is 20")]
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged();
                    RemoveError();
                    if (string.IsNullOrEmpty(name))
                        AddError("Name field is required");
                    else if (name.Length < 6 || name.Length > 20)
                        AddError("Name field lenght should be in between 6 and 20");
                }
            }
        }

        private string address;
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 15, ErrorMessage = "Address field is required, min lenght is 15 and max is 50")]
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged();
                RemoveError();
                if (string.IsNullOrEmpty(address))
                    AddError("Address field is required");
                if (string.IsNullOrWhiteSpace(address) || address.Length < 15 || address.Length > 50)
                    AddError("Address field lenght should be in between 15 and 50");
            }
        }

        private string secondayAddress;
        public string SecondayAddress
        {
            get { return secondayAddress; }
            set
            {
                secondayAddress = value;
                RaisePropertyChanged("SecondayAddress");
            }
        }

        private int age;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Age is required, should be > 1 and < 150")]
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                RaisePropertyChanged();
                RemoveError();
                if (age < 1 || age > 150)
                    AddError("Age field lenght should be in between 1 and 150");
            }
        }

        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        private bool isValid;
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; RaisePropertyChanged("IsValid"); }

        }

        #region INotifyDataErrorInfo
        public bool HasErrors
        {
            get
            {
                return _errors.Any(propErrors => propErrors.Value != null && propErrors.Value.Count > 0);
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void NotifyErrorsChanged([CallerMemberName] string propertyName = null)
        {
            // Notify
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            if (this._errors.ContainsKey(propertyName))
                return this._errors[propertyName];
            return null;
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            this.NotifyErrorsChanged(propertyName);
        }
        #endregion

        public void AddError(string error, [CallerMemberName] string propertyName = null)
        {
            // Add error to list
            if (this._errors.ContainsKey(propertyName))
            {
                var lst = this._errors[propertyName];
                if (lst == null)
                    this._errors[propertyName] = new List<string>() { error };
                else
                    this._errors[propertyName].Add(error);
            }
            else
                this._errors[propertyName] = new List<string>() { error };

            IsValid = !this.HasErrors;
            //this.NotifyErrorsChanged(propertyName);
        }

        public void RemoveError([CallerMemberName] string propertyName = null)
        {
            // remove error
            if (this._errors.ContainsKey(propertyName))
                this._errors.Remove(propertyName);
            IsValid = !this.HasErrors;
            //this.NotifyErrorsChanged(propertyName);
        }

    }
}
