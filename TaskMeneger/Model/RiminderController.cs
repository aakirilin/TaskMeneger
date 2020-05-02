using System;

namespace TaskMeneger
{
    public class RiminderController
    {
        public WorkTask workTask { get; private set; }
        public Reminder reminder { get; private set; }

        public DateTime DateReminder
        {
            get
            {
                return reminder.DateReminder;
            }
            set
            {
                reminder.DateReminder = value;
            }
        }

        public RiminderController(WorkTask workTask, Reminder reminder)
        {
            this.workTask = workTask;
            this.reminder = reminder;
        }

        public void AddReminder()
        {
            workTask.AddReminder(reminder);
        }

        public void RemoveReminder()
        {
            workTask.RemoveReminder(reminder);
        }
    }
}
