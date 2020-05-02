using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace TaskMeneger
{
    /// <summary>
    /// Логика взаимодействия для FilesViewPage.xaml
    /// </summary>
    public partial class AddFilesWindow : Window
    {
        public AddFilesWindow(IEnumerable<AdditionFile> Files)
        {
            InitializeComponent();
            DataContext = new AdditionalFilesViewModel(Files);
        }

        private void ApplyChenge_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
        }

    }
}
