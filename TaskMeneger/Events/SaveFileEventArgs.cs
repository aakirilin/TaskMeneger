using System.Windows;

namespace TaskMeneger
{
    public class SaveFileEventArgs : RoutedEventArgs
    {
        private AdditionFile file;

        public AdditionFile File
        {
            get
            {
                return file;
            }
        }

        internal SaveFileEventArgs(AdditionFile file)
        {
            this.file = file;
        }
    }
}
