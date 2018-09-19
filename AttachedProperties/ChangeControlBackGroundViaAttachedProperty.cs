using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OneStopSample.AttachedProperties
{
    public class ChangeControlBackGroundViaAttachedProperty : DependencyObject
    {
        
        #region IsReadOnly
        public static bool GetIsReadOnly(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsReadOnlyProperty);
        }

        public static void SetIsReadOnly(DependencyObject obj, bool value)
        {
            obj.SetValue(IsReadOnlyProperty, value);
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.RegisterAttached(
                "IsReadOnly",
            typeof(bool),
            typeof(ChangeControlBackGroundViaAttachedProperty),
            new PropertyMetadata(false));
        #endregion

        #region ShouldChangeBackground
        public static bool GetShouldChangeBackground(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShouldChangeBackgroundProperty);
        }

        public static void SetShouldChangeBackground(DependencyObject obj, bool value)
        {
            obj.SetValue(ShouldChangeBackgroundProperty, value);
        }

        public static readonly DependencyProperty ShouldChangeBackgroundProperty =
            DependencyProperty.RegisterAttached(
                "ShouldChangeBackground",
            typeof(bool),
            typeof(ChangeControlBackGroundViaAttachedProperty),
            new PropertyMetadata(false)); 
        #endregion
    }
}
