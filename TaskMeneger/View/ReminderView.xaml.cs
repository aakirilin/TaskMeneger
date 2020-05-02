using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TaskMeneger.View
{
    /// <summary>
    /// Логика взаимодействия для ReminderView.xaml
    /// </summary>
    public partial class ReminderView : UserControl
    {

        public static readonly RoutedEvent DeleteReminder = EventManager.RegisterRoutedEvent(
        "DeleteReminderButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ReminderView));


        public event RoutedEventHandler DeleteReminderButtonClick
        {
            add { AddHandler(DeleteReminder, value); }
            remove { RemoveHandler(DeleteReminder, value); }
        }

        public ReminderView()
        {
            InitializeComponent();
        }

        public void DeleteReminderCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DeleteReminderEventArgs eventArgs = new DeleteReminderEventArgs(e.Parameter as Reminder);
            eventArgs.RoutedEvent = DeleteReminder;
            RaiseEvent(eventArgs);
        }
    }
}
