using System.Windows;
using System.Windows.Controls;

namespace TaskMeneger.View
{
    /// <summary>
    /// Логика взаимодействия для WorkTaskViewControl.xaml
    /// </summary>
    public partial class WorkTaskView : UserControl
    {
        public static readonly RoutedEvent DeleteReminder = EventManager.RegisterRoutedEvent(
        "DeleteReminderButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WorkTaskView));

        public event RoutedEventHandler DeleteReminderButtonClick
        {
            add { AddHandler(DeleteReminder, value); }
            remove { RemoveHandler(DeleteReminder, value); }
        }

        private void ReminderView_DeleteReminderButtonClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs eventArgs = new RoutedEventArgs(DeleteReminder, e);
            RaiseEvent(eventArgs);
        }

        public WorkTaskView()
        {
            InitializeComponent();
        }
    }
}
