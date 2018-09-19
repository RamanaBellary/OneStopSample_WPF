using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace OneStopSample.DependencyPropertyEx
{
    public class CustomDatePicker : DatePicker
    {
        public bool IsFocusable
        {
            get { return (bool)GetValue(IsFocusableProperty); }
            set { SetValue(IsFocusableProperty, value); }
        }

        public static readonly DependencyProperty IsFocusableProperty = DependencyProperty.Register("IsFocusable", typeof(bool), typeof(CustomDatePicker), new PropertyMetadata(true));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TextBox tb = GetTemplateChild("PART_TextBox") as TextBox;
            Binding b = new Binding() { Source = this, Path = new PropertyPath(IsFocusableProperty) };
            tb.SetBinding(UIElement.FocusableProperty, b);
        }

    }
}
