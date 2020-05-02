using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TaskMeneger
{
    public class AdditionalFilesViewModel : INotifyPropertyChanged
    {

        public AdditionalFilesViewModel()
        {
            AdditionFiles = new ObservableCollection<AdditionFile>();
        }

        public AdditionalFilesViewModel(IEnumerable<AdditionFile> Files)
        {
            AdditionFiles = new ObservableCollection<AdditionFile>(Files);
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

        private ObservableCollection<AdditionFile> additionFiles;
        public ObservableCollection<AdditionFile> AdditionFiles
        {
            get
            {
                return additionFiles;
            }
            set
            {
                additionFiles = value;
                OnPropertyChanged("AdditionFiles");
            }
        }

        private void AddFile(string fileName)
        {
            AdditionFile newFile = new AdditionFile();
            newFile.FillPath = fileName;
            AdditionFiles.Add(newFile);
            OnPropertyChanged("AdditionFiles");
        }

        public void AddFile(object obj)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = true;
            if (of.ShowDialog() == true)
            {
                foreach (var fileName in of.FileNames)
                {
                    AddFile(fileName);
                }
            }
        }

        public void RemoveFile(object obj)
        {
            AdditionFile file = obj as AdditionFile;
            if (file != null)
            {
                AdditionFiles.Remove(file);
                OnPropertyChanged("AdditionFiles");
            }
        }

        public ICommand AddFileCommand
        {
            get
            {
                return new RelayCommand(AddFile);
            }
        }

        public ICommand RemoveFileCommand
        {
            get
            {
                return new RelayCommand(RemoveFile);
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
