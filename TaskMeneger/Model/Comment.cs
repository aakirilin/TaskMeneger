using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskMeneger
{
    public class Comment : INotifyPropertyChanged, IDB
    {
        public Guid Id { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
