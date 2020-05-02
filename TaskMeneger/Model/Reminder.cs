using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskMeneger
{
    public class Reminder : INotifyPropertyChanged, IDB
    {
        public Guid Id { get; set; }

        private DateTime dateReminder;
        public DateTime DateReminder
        {
            get
            {
                return dateReminder;
            }
            set
            {
                dateReminder = value;
                OnPropertyChanged("DateReminder");
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
