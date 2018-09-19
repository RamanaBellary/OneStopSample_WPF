using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace OneStopSample.Behaviours
{
    public class TextChangeBehaviour : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            TextBox txtBox = AssociatedObject as TextBox;
            //txtBox.TextChanged += txt_TextChanged;            
            //if (string.IsNullOrEmpty(txtBox.Text))
            //{
            //    txtBox.Background = new SolidColorBrush(Colors.Green);
            //}
            //else
            //{
            //    txtBox.Background = new SolidColorBrush(Colors.Red);
            //}

            txtBox.PreviewTextInput += OnTextInput;
            txtBox.PreviewKeyDown += OnPreviewKeyDown;
            DataObject.AddPastingHandler(txtBox, OnPaste);
        }

        private static void OnTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(c => !char.IsDigit(c))) { e.Handled = true; }
        }

        private static void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }

        void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = AssociatedObject as TextBox;
            txtBox.TextChanged += txt_TextChanged;

            if (string.IsNullOrEmpty(txtBox.Text))
            {
                txtBox.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                txtBox.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private static void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                var text = Convert.ToString(e.DataObject.GetData(DataFormats.Text)).Trim();
                if (text.Any(c => !char.IsDigit(c))) { e.CancelCommand(); }
            }
            else
            {
                e.CancelCommand();
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            TextBox txtBox = AssociatedObject as TextBox;
            //txtBox.TextChanged -= txt_TextChanged;
            txtBox.PreviewTextInput += OnTextInput;
            txtBox.PreviewKeyDown += OnPreviewKeyDown;
            DataObject.RemovePastingHandler(txtBox, OnPaste);
        }
    }

    //
    public static class MVVMBehaviours
    {
        public static string GetLoadedMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadedMethodNameProperty);
        }

        public static void SetLoadedMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadedMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadedMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadedMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadedMethodName", typeof(string), typeof(MVVMBehaviours),
                new PropertyMetadata(null, onLoadedMethodNameChanged));

        private static void onLoadedMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            if (element != null)
            {
                element.Loaded += (s, e2) =>
                {
                    var vm = element.DataContext;
                    if (vm == null) return;
                    var methodInfo = vm.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo != null)
                        methodInfo.Invoke(vm, null);
                };
            }
        }
    }
}
