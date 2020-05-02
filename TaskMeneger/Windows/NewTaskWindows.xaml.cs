using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TaskMeneger
{
    /// <summary>
    /// Логика взаимодействия для NewTaskWindows.xaml
    /// </summary>
    public partial class NewTaskWindows : Window
    {
        public WorkTask WorkTask;
        private WorkTaskViewModel workTaskViewModel;
        public NewTaskWindows()
        {
            InitializeComponent();
            WorkTask = new WorkTask()
            {
                Name = "Новая задача",
                Text = "Описание",
                Files = new ObservableCollection<AdditionFile>(),
                Comments = new ObservableCollection<Comment>()
            };
            workTaskViewModel = new WorkTaskViewModel(WorkTask);
            DataContext = workTaskViewModel;
        }

        private void ApplyChenge_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void AddFileCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddFilesWindow additionFileControl = new AddFilesWindow(WorkTask.Files);
            if (additionFileControl.ShowDialog() == true)
            {
                var filesVM = additionFileControl.DataContext as AdditionalFilesViewModel;
                workTaskViewModel.Files = filesVM.AdditionFiles;
            }
        }
    }
}
