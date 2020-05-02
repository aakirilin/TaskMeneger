using System;
using System.Windows;
using System.Windows.Input;

namespace TaskMeneger
{
    /// <summary>
    /// Логика взаимодействия для ReminderWindow.xaml
    /// </summary>
    public partial class ReminderWindow : Window
    {
        public ReminderWindow()
        {
            InitializeComponent();
            var primaryMonitorArea = SystemParameters.WorkArea;
            Left = primaryMonitorArea.Right - Width - 10;
            Top = primaryMonitorArea.Bottom - Height - 10;

        }

        public event Action OnRememberAfterOneHours;
        public event Action OnRememberAfterOneDay;

        private void CloseButton_Click(object o, EventArgs e)
        {
            Close();
        }

        private void RememberAfterOneHoursCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
            OnRememberAfterOneHours();

        }

        private void RememberAfterOneDayCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
            OnRememberAfterOneDay();
        }
    }
}
