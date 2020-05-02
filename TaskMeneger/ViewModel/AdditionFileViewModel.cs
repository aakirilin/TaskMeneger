using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TaskMeneger
{
    public class AdditionFileViewModel : INotifyPropertyChanged
    {
        public AdditionFileViewModel()
        {
            AdditionFiles = new ObservableCollection<AdditionFile>();
        }

        private AdditionFile selectAdditionFile;
        public AdditionFile SelectAdditionFile
        {
            get
            {
                return selectAdditionFile;
            }
            set
            {
                selectAdditionFile = value;
                OnPropertyChanged("SelectAdditionFile");
            }
        }

        public ObservableCollection<AdditionFile> AdditionFiles { get; set; }

        public void AddFile(string fileName)
        {
            AdditionFile newFile = new AdditionFile
            {
                FillPath = fileName
            };
            AdditionFiles.Add(newFile);
        }

        public void RemoveFile(AdditionFile file)
        {
            if (file != null)
            {
                AdditionFiles.Remove(file);
            }
        }

        public void RemoveFile(string fileName)
        {
            AdditionFile file = AdditionFiles.FirstOrDefault(f => f.Name.CompareTo(fileName) == 0);
            RemoveFile(file);
        }

        private RoutedCommand addFileCommand;
        public RoutedCommand AddFileCommand
        {
            get
            {
                return addFileCommand ??
                  (addFileCommand = new RoutedCommand("FileName", typeof(string)));
            }
        }

        private RoutedCommand removeFileCommand;
        public RoutedCommand RemoveFileCommand
        {
            get
            {
                return removeFileCommand ??
                  (removeFileCommand = new RoutedCommand("FileName", typeof(string)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
