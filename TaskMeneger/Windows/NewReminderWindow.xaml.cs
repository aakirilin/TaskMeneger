using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TaskMeneger
{
    /// <summary>
    /// Логика взаимодействия для NewReminderWindow.xaml
    /// </summary>
    public partial class NewReminderWindow : Window
    {
        public NewReminderWindow()
        {
            InitializeComponent();
            result = new Reminder();
            SelectData.SelectedDate = DateTime.Now;
            DataContext = result;

        }

        public Reminder result;

        private string PeriodReminder;
        private void OnPeriodSelect(object sender, RoutedEventArgs e)
        {
            PeriodReminder = (sender as RadioButton).Name;
        }

        private void ApplyChenge_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var selectDateValue = SelectData.SelectedDate.Value;
            switch (PeriodReminder)
            {
                case "addOneDay": result.DateReminder = DateTime.Now.AddDays(1); break;
                case "addOneWeek": result.DateReminder = DateTime.Now.AddDays(7); break;
                case "addOneMounth": result.DateReminder = DateTime.Now.AddMonths(1); break;
                case "everyDay":
                    result.DateReminder = SelectData.SelectedDate.Value;
                    result.DateReminder = new DateTime(
                        selectDateValue.Year,
                        selectDateValue.Month,
                        selectDateValue.Day,
                        TimePicker.TimeSpan.Hours,
                        TimePicker.TimeSpan.Minutes,
                        0);
                    break;
                case "onSelectData":
                    result.DateReminder = SelectData.SelectedDate.Value;
                    result.DateReminder = new DateTime(
                        selectDateValue.Year,
                        selectDateValue.Month,
                        selectDateValue.Day,
                        TimePicker.TimeSpan.Hours,
                        TimePicker.TimeSpan.Minutes,
                        0);
                    break;
                default: result.DateReminder = DateTime.Now.AddDays(1); break;
            }
            DialogResult = true;
        }
    }
}
