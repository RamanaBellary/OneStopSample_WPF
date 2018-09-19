using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OneStopSample.Behaviours
{
    public class DoubleClickUsingADP 
    {
        public static readonly DependencyProperty DoubleClickCommandProperty =
            DependencyProperty.RegisterAttached("DoubleClickCommand", typeof(ICommand), typeof(DoubleClickUsingADP),
                new FrameworkPropertyMetadata(OnDoubleClickCommandPropertyChanged));

        public static ICommand GetDoubleClickCommand(DependencyObject obj)
        {
             return (ICommand)obj.GetValue(DoubleClickCommandProperty); 
        }

        public static void SetDoubleClickCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(DoubleClickCommandProperty, value);
        }

        private static void OnDoubleClickCommandPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var frameworkElement = obj as FrameworkElement;
            frameworkElement.PreviewMouseLeftButtonDown -= OnPreviewMouseLeftButtonUpEvent;
            frameworkElement.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonUpEvent;
        }

        private static void OnPreviewMouseLeftButtonUpEvent(object sender, MouseButtonEventArgs args)
        {
            if(args.ClickCount == 2)
            {
                var obj = sender as DependencyObject;
                var cmd = GetDoubleClickCommand(obj);
                if (cmd != null)
                {
                    cmd.Execute(null);
                    args.Handled = true;
                }
            }
                     
        }
    }
}
