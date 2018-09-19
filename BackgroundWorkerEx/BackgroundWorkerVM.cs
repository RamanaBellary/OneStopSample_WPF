using OneStopSample.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Globalization;
using System.Windows;

namespace OneStopSample.BackgroundWorkerEx
{
    public class BackgroundWorkerVM : INotifyPropertyChanged
    {
        private BackgroundWorker bgWorker;

        public BackgroundWorkerVM()
        {
            bgWorker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            invokeCMD = new RelayCommand(Invoke, null);
            cancelCMD = new RelayCommand(Cancel, null);

        }

        private ICommand invokeCMD;
        public ICommand InvokeCMD
        {
            get { return invokeCMD; }
        }

        private ICommand cancelCMD;
        public ICommand CancelCMD
        {
            get { return cancelCMD; }
        }

        private int currentProgress;
        public int CurrentProgress
        {
            get { return currentProgress; }
            set
            {
                currentProgress = value;
                RaisePropertyChanged("CurrentProgress");
            }
        }

        private bool isBackgroundWorkerRunning;
        public bool IsBackgroundWorkerRunning
        {
            get { return isBackgroundWorkerRunning; }
            set
            {
                isBackgroundWorkerRunning = value;
                RaisePropertyChanged("IsBackgroundWorkerRunning");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void Invoke(object obj)
        {
            bgWorker.DoWork += DoWork;
            bgWorker.ProgressChanged += ProgressChanged;
            bgWorker.RunWorkerCompleted += RunWorkerCompleted;
            IsBackgroundWorkerRunning = true;
            bgWorker.RunWorkerAsync();
        }

        private void Cancel(object obj)
        {
            bgWorker.CancelAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs args)
        {
            for (int i = 0; i < 100; i++)
            {
                if (bgWorker.CancellationPending)
                {
                    args.Cancel = true;
                    return;
                }
                else
                {
                    bgWorker.ReportProgress(i);
                    Thread.Sleep(1000);
                }
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs args)
        {
            CurrentProgress = args.ProgressPercentage;
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            if (args.Cancelled)
            {

            }
            else if (args.Error != null)
            {

            }
            else
            {
                var result = args.Result;
            }
            IsBackgroundWorkerRunning = false;
        }
    }

    public class InvertBoolFlagConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            bool val =false ;
            if (bool.TryParse(value.ToString(), out val))
            {
                return !val;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
