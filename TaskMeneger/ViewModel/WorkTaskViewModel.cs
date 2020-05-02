using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TaskMeneger
{
    public class WorkTaskViewModel : INotifyPropertyChanged
    {
        private WorkTask workTask;

        public WorkTaskViewModel(WorkTask workTask)
        {
            this.workTask = workTask;
        }

        public string Name
        {
            get
            {
                return workTask.Name;
            }
            set
            {
                workTask.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Text
        {
            get
            {
                return workTask.Text;
            }
            set
            {
                workTask.Text = value;
                OnPropertyChanged("Text");
            }
        }

        public ObservableCollection<AdditionFile> Files
        {
            get
            {
                return workTask.Files;
            }
            set
            {
                workTask.Files = value;
                OnPropertyChanged("Files");
                OnPropertyChanged("FilesNames");
                OnPropertyChanged("ShowFilesNames");
            }
        }

        public string FilesNames
        {
            get
            {
                if (Files != null)
                {
                    return String.Join(Environment.NewLine, Files.Select(f => f.Name));
                }
                else
                {
                    return null;
                }
            }
        }

        public Visibility ShowFilesNames
        {
            get
            {
                return Files != null && Files.Count > 0 ? Visibility.Visible : Visibility.Hidden;
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
