using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace OneStopSample.Behaviours
{
    public class DoubleClickBehaviour :Behavior<Control>
    {
        //TODO: Not working as of now...
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewMouseUp += AssociatedObject_PreviewMouseUp;
        }

        private void AssociatedObject_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                DoubeClickCommand?.Execute(null);
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewMouseUp -= AssociatedObject_PreviewMouseUp;
        }

        public static readonly DependencyProperty DoubeClickCommandProperty =
            DependencyProperty.Register(nameof(DoubeClickCommand), typeof(ICommand), typeof(DoubleClickBehaviour));

        public ICommand DoubeClickCommand
        {
            get { return (ICommand)GetValue(DoubeClickCommandProperty); }
            set
            {
                SetValue(DoubeClickCommandProperty, value);
            }
        }
    }
}
