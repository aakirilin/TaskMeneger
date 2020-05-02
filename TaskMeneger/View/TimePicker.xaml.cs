using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TaskMeneger
{
    /// <summary>
    /// Логика взаимодействия для TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public TimeSpan TimeSpan;
        public TimePicker()
        {
            InitializeComponent();
            TimeSpan = DateTime.Now.TimeOfDay;
            SetText(TimeSpan);

            var hourses = Enumerable.Range(1, 24).Select(v => new { Value = v });
            var munntuts = Enumerable.Range(1, 60).Select(v => new { Value = v });

            hoursControl.ItemsSource = new ObservableCollection<object>(hourses);
            minutesControl.ItemsSource = new ObservableCollection<object>(munntuts);
        }

        private void SetText(TimeSpan TimeSpan)
        {
            TextField.Text = TimeSpan.ToString(@"hh\:mm");
        }

        private void TextBox_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = true;
            hoursControl.SelectedIndex = TimeSpan.Hours - 1;
            minutesControl.SelectedIndex = TimeSpan.Minutes - 1;
            hoursControl.ScrollIntoView(hoursControl.SelectedItem);
            minutesControl.ScrollIntoView(minutesControl.SelectedItem);
        }

        private void popup1_Closed(object sender, EventArgs e)
        {
            TimeSpan = new TimeSpan(
                hoursControl.SelectedIndex + 1,
                minutesControl.SelectedIndex + 1,
                0);
            SetText(TimeSpan);
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hm = TextField.Text.Split(':');
            try
            {
                TimeSpan = new TimeSpan(
                int.Parse(hm[0]),
                int.Parse(hm[1]),
                0);
                SetText(TimeSpan);
            }
            catch
            {
                SetText(TimeSpan);
            }
        }
    }
}
