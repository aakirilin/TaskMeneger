using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace TaskMeneger
{
    public class WorkTasksViewModel : INotifyPropertyChanged
    {
        private Timer timer;
        public void StartTimer()
        {
            TimerCallback tm = new TimerCallback(OnTimerTick);
            timer = new Timer(tm, null, 1000, 1000);
        }

        private static readonly object locker = new object();
        private IEnumerable<RiminderController> Reminders
        {
            get
            {
                return WorkTasks.Where(t => t.Reminders != null)
                    .SelectMany(t => t.Reminders.Select(r => new RiminderController(t, r)))
                    .Where(r => r.DateReminder <= DateTime.Now);
            }
        }

        private void OnTimerTick(object obj)
        {
            lock (locker)
            {
                var rems = Reminders.ToArray();
                if (rems != null)
                {
                    foreach (var reminder in rems)
                    {
                        OnRiminderTimeOut(reminder);
                    }
                }
            }
        }

        private void OnRiminderTimeOut(RiminderController riminder)
        {
            DeleteRimender(riminder);
            ParameterizedThreadStart parameterizedThreadStart
                = new ParameterizedThreadStart(ShowReminder);
            Thread newWindowThread = new Thread(parameterizedThreadStart);
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start(riminder);
        }

        private void ShowReminder(object o)
        {
            RiminderController riminder = o as RiminderController;
            ReminderWindow reminderWindow = new ReminderWindow();
            reminderWindow.DataContext = riminder.reminder;
            reminderWindow.OnRememberAfterOneDay += () =>
            {
                riminder.DateReminder = riminder.DateReminder.AddDays(1);
                AddRimender(riminder);
            };
            reminderWindow.OnRememberAfterOneHours += () =>
            {
                riminder.DateReminder = riminder.DateReminder.AddHours(1);
                AddRimender(riminder);
            };
            reminderWindow.Show();
            System.Windows.Threading.Dispatcher.Run();
        }

        private WorkTask selectWorkTask;
        public WorkTask SelectWorkTask
        {
            get
            {
                return selectWorkTask;
            }
            set
            {
                selectWorkTask = value;
                OnPropertyChanged("SelectWorkTask");
                OnPropertyChanged("IsSelectWorkTask");
                OnPropertyChanged("GetText");
            }
        }

        public Visibility IsSelectWorkTask
        {
            get
            {
                return SelectWorkTask != null && ceanAddNewWorkTask ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private ObservableCollection<WorkTask> workTasks;
        public ObservableCollection<WorkTask> WorkTasks
        {
            get
            {
                return workTasks;
            }
            set
            {
                workTasks = value;
                OnPropertyChanged("WorkTasks");
                SelectWorkTask = null;
                OnPropertyChanged("SelectWorkTask");
            }
        }

        private bool ceanAddNewWorkTask;
        public Visibility CeanAddNewWorkTask
        {
            get
            {
                return ceanAddNewWorkTask ? Visibility.Visible : Visibility.Hidden;
            }
        }

        public void AddComment(Comment newComment)
        {
            if (SelectWorkTask != null)
            {
                newComment.Id = Guid.NewGuid();
                if (newComment.Files != null && newComment.Files.Count > 0)
                {
                    foreach (var item in newComment.Files)
                    {
                        item.Id = Guid.NewGuid();
                    }
                }
                newComment.DateCreate = DateTime.Now;
                SelectWorkTask.AddComment(newComment);
                using (var db = new DB())
                {
                    db.AddComment(SelectWorkTask, newComment);
                }
                OnPropertyChanged("SelectWorkTask");
                OnPropertyChanged("GetText");
            }
        }

        public void AddWorkTask(WorkTask workTask)
        {
            workTask.DateCreate = DateTime.Now;
            workTask.Id = Guid.NewGuid();
            if (workTask.Files != null && workTask.Files.Count > 0)
            {
                foreach (var item in workTask.Files)
                {
                    item.Id = Guid.NewGuid();
                }
            }
            if (workTask.Comments != null && workTask.Comments.Count > 0)
            {
                foreach (var item in workTask.Comments)
                {
                    item.Id = Guid.NewGuid();
                    item.DateCreate = DateTime.Now;
                }
            }
            WorkTasks.Add(workTask);
            using (var db = new DB())
            {
                db.InsertWorkTask(workTask);
            }
        }

        public void SetWilDone(object o)
        {
            if (SelectWorkTask != null)
            {
                SelectWorkTask.Statys = WorkTaskStatys.WillDone;
                using (var db = new DB())
                {
                    db.UpdateWorkTask(SelectWorkTask);
                }
                WorkTasks.Remove(SelectWorkTask);
                SelectWorkTask = null;
                OnPropertyChanged("SelectWorkTask");
                OnPropertyChanged("GetText");
            }
        }

        public ICommand SetWilDoneCommand
        {
            get
            {
                return new RelayCommand(SetWilDone);
            }
        }

        public void LoadActive(object o)
        {
            using (var db = new DB())
            {
                WorkTasks = new ObservableCollection<WorkTask>(db.GetActiveWorkTask);
            }
            ceanAddNewWorkTask = true;
            OnPropertyChanged("CeanAddNewWorkTask");
            OnPropertyChanged("GetText");
        }

        public ICommand LoadActiveCommand
        {
            get
            {
                return new RelayCommand(LoadActive);
            }
        }

        public void LoadWillDone(object o)
        {
            using (var db = new DB())
            {
                WorkTasks = new ObservableCollection<WorkTask>(db.GetWillDineWorkTask);
            }
            ceanAddNewWorkTask = false;
            OnPropertyChanged("CeanAddNewWorkTask");
            OnPropertyChanged("GetText");
        }

        public ICommand LoadWillDoneCommand
        {
            get
            {
                return new RelayCommand(LoadWillDone);
            }
        }

        public void AddRimender(RiminderController reminder)
        {
            lock (locker)
            {
                reminder.reminder.Id = Guid.NewGuid();
                Application.Current.Dispatcher.Invoke(reminder.AddReminder);
                using (DB db = new DB())
                {
                    db.InsertRiminder(reminder.reminder);
                    db.UpdateWorkTask(reminder.workTask);
                }
            }
            if (SelectWorkTask == reminder.workTask)
            {
                OnPropertyChanged("GetText");
            }
        }

        public void AddRimender(Reminder reminder)
        {
            AddRimender(new RiminderController(SelectWorkTask, reminder));
        }

        public void DeleteRimender(RiminderController reminder)
        {
            lock (locker)
            {
                Application.Current.Dispatcher.Invoke(reminder.RemoveReminder);
                using (DB db = new DB())
                {
                    db.DeleteRiminder(reminder.reminder);
                    db.UpdateWorkTask(reminder.workTask);
                }
            }
            if (SelectWorkTask == reminder.workTask)
            {
                OnPropertyChanged("GetText");
            }
        }

        public void DeleteRimender(object o)
        {
            Reminder reminder = o as Reminder;
            DeleteRimender(new RiminderController(SelectWorkTask, reminder));
        }

        public ICommand DeleteRimenderCommand
        {
            get
            {
                return new RelayCommand(DeleteRimender);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
