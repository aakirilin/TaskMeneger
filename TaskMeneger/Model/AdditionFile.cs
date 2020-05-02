using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskMeneger
{
    public class AdditionFile : INotifyPropertyChanged, IDB
    {
        public Guid Id { get; set; }

        public string Name
        {
            get
            {
                return System.IO.Path.GetFileName(FillPath);
            }
        }
        private string fillPath;
        public string FillPath
        {
            get
            {
                return fillPath;
            }
            set
            {
                fillPath = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("FillPath");
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
