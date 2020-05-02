using LiteDB;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TaskMeneger
{

    public class WorkTask : INotifyPropertyChanged, IDB
    {

        public Guid Id { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }
        private DateTime dateCreate;
        public DateTime DateCreate
        {
            get
            {
                return dateCreate;
            }
            set
            {
                dateCreate = value;
                OnPropertyChanged("DateCreate");
            }
        }

        private WorkTaskStatys statys;
        public WorkTaskStatys Statys
        {
            get
            {
                return statys;
            }
            set
            {
                statys = value;
                OnPropertyChanged("Statys");
            }
        }

        [BsonIgnore]
        public Comment LastComment
        {
            get
            {
                return Comments?.OrderByDescending(c => c.DateCreate).FirstOrDefault();
            }
        }

        private ObservableCollection<AdditionFile> files;
        public ObservableCollection<AdditionFile> Files
        {
            get
            {
                return files;
            }
            set
            {
                files = value;
                OnPropertyChanged("Files");
            }
        }

        public void AddFile(AdditionFile file)
        {
            if (Files == null)
            {
                Files = new ObservableCollection<AdditionFile>();
            }
            Files.Add(file);
            OnPropertyChanged("Files");
        }
        public void RemoveFile(AdditionFile file)
        {
            Files.Remove(file);
            OnPropertyChanged("Files");
        }

        private ObservableCollection<Comment> comments;
        public ObservableCollection<Comment> Comments
        {
            get
            {
                return comments;
            }
            set
            {
                comments = value;
                OnPropertyChanged("Comments");
            }
        }

        public void AddComment(Comment comment)
        {
            if (Comments == null)
            {
                Comments = new ObservableCollection<Comment>();
            }
            Comments.Add(comment);
            OnPropertyChanged("LastComment");
            OnPropertyChanged("Comments");
        }
        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
            OnPropertyChanged("Comments");
        }

        private ObservableCollection<Reminder> reminders;
        public ObservableCollection<Reminder> Reminders
        {
            get
            {
                return reminders;
            }
            set
            {
                reminders = value;
                OnPropertyChanged("Reminders");
            }
        }

        public void AddReminder(Reminder reminder)
        {
            if (Reminders == null)
            {
                Reminders = new ObservableCollection<Reminder>();
            }
            Reminders.Add(reminder);
            OnPropertyChanged("Reminders");
        }
        public void RemoveReminder(Reminder reminder)
        {
            Reminders.Remove(reminder);
            OnPropertyChanged("Reminders");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
