using OneStopSample.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace OneStopSample.InteractivityEx
{
    public class InteractivityExVM
    {
        public InteractivityExVM()
        {
            MouseEnterCmd = new Utils.RelayCommand(new Action<object>(MouseEntered),new Func<object,bool>(CanExecute));
            OnImageClick = new RelayCommand(HandleOnImageClick);
        }

        private ICommand mouseEnterCmd;
        public ICommand MouseEnterCmd
        {
            get { return mouseEnterCmd; }
            set { mouseEnterCmd = value; }
        }

        public bool CanExecute(object obj) { return true; }

        public void MouseEntered(object obj)
        {
            MessageBox.Show("Mouse Entered command invoked...");
        }

        private ICommand onImageClick;
        public ICommand OnImageClick
        {
            get { return onImageClick; }
            set
            {
                onImageClick = value;
            }
        }

        private void HandleOnImageClick(object obj)
        {
            MessageBox.Show("Image Mouse Enter command invoked...");
        }
    }
}
