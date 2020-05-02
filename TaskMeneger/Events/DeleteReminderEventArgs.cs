using System.Windows;

namespace TaskMeneger
{
    public class DeleteReminderEventArgs : RoutedEventArgs
    {
        private Reminder reminder;

        public Reminder Reminder
        {
            get
            {
                return reminder;
            }
        }

        internal DeleteReminderEventArgs(Reminder reminder)
        {
            this.reminder = reminder;
        }
    }
}
