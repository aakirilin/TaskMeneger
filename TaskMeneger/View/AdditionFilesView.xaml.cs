using System.Windows.Controls;
using System.Windows.Input;

namespace TaskMeneger.View
{
    /// <summary>
    /// Логика взаимодействия для AdditionFilesView.xaml
    /// </summary>
    public partial class AdditionFilesView : UserControl
    {

        public void SaveFileCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (DB db = new DB())
            {
                db.SaveFile(e.Parameter as AdditionFile);
            }
        }

        public AdditionFilesView()
        {
            InitializeComponent();
        }
    }
}
