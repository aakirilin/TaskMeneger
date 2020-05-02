using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TaskMeneger
{
    public class CommentViewModel : INotifyPropertyChanged
    {
        private Comment comment;

        public CommentViewModel(Comment comment)
        {
            this.comment = comment;
        }

        public string Text
        {
            get
            {
                return comment.Text;
            }
            set
            {
                comment.Text = value;
                OnPropertyChanged("Text");
            }
        }

        public DateTime DateCreate
        {
            get
            {
                return comment.DateCreate;
            }
            set
            {
                comment.DateCreate = value;
                OnPropertyChanged("DateCreate");
            }
        }

        public ObservableCollection<AdditionFile> Files
        {
            get
            {
                return comment.Files;
            }
            set
            {
                comment.Files = value;
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
