using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TaskMeneger
{
    /// <summary>
    /// Логика взаимодействия для NewCommentWindow.xaml
    /// </summary>
    public partial class NewCommentWindow : Window
    {

        public Comment comment;
        private CommentViewModel commentViewModel;

        public NewCommentWindow()
        {
            InitializeComponent();
            comment = new Comment();
            comment.Files = new ObservableCollection<AdditionFile>();
            commentViewModel = new CommentViewModel(comment);
            DataContext = commentViewModel;
        }

        private void ApplyChenge_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void AddFileCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddFilesWindow additionFileControl = new AddFilesWindow(comment.Files);
            if (additionFileControl.ShowDialog() == true)
            {
                var filesVM = additionFileControl.DataContext as AdditionalFilesViewModel;
                commentViewModel.Files = filesVM.AdditionFiles;
            }
        }
    }
}
