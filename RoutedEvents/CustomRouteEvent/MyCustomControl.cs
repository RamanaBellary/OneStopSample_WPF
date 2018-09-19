using System.Windows;
using System.Windows.Controls;

namespace OneStopSample.RoutedEvents
{
    public class MyCustomControl : Control
    {
        static MyCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //demo purpose only, check for previous instances and remove the handler first  
            var button = GetTemplateChild("PART_Button") as Button;
            if (button != null) button.Click += Button_Click;
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseClickEvent(); 
        }

        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyCustomControl));

        public event RoutedEventHandler Click
        {
            add
            {
                AddHandler(ClickEvent, value);
            }
            remove
            {
                RemoveHandler(ClickEvent, value);
            }
        }

        protected virtual void RaiseClickEvent()
        {
            RoutedEventArgs args = new
            RoutedEventArgs(MyCustomControl.ClickEvent);
            RaiseEvent(args);
        }
    }
}
