using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace TaskMeneger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkTasksViewModel taskControl;

        private NotifyIcon notifyIcon;

        private bool ceanClose = false;

        public MainWindow()
        {
            InitializeComponent();
            taskControl = new WorkTasksViewModel();
            taskControl.LoadActive(new object());
            taskControl.StartTimer();
            DataContext = taskControl;

            this.notifyIcon = new NotifyIcon
            {
                Text = "Планировщик задач",
                Icon = Properties.Resources.icon, // new System.Drawing.Icon(Properties.Resources.icon),
                Visible = true
            };
            notifyIcon.DoubleClick += NotifyIcon_Click;
            ContextMenuStrip notifyContextMenu = new ContextMenuStrip();
            var newTaskButton = notifyContextMenu.Items.Add("Новая задача.");
            newTaskButton.Click += NewTaskButton_Click; ;
            var closeButton = notifyContextMenu.Items.Add("Закрыть.");
            closeButton.Click += CloseButton_Click;
            notifyIcon.ContextMenuStrip = notifyContextMenu;


        }

        private void NewTaskButton_Click(object sender, EventArgs e)
        {
            AddNewWorckTask();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ceanClose = true;
            Close();
        }

        private void AddCommetnCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NewCommentWindow newCommentWindow = new NewCommentWindow();
            if (newCommentWindow.ShowDialog() == true)
            {
                taskControl.AddComment(newCommentWindow.comment);
            }
        }

        private void AddNewWorckTask()
        {
            NewTaskWindows newTaskWindows = new NewTaskWindows();
            if (newTaskWindows.ShowDialog() == true)
            {
                taskControl.AddWorkTask(newTaskWindows.WorkTask);
            }
        }

        private void AddTaskCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddNewWorckTask();
        }

        private void AddReminderCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NewReminderWindow newReminderWindow = new NewReminderWindow();
            newReminderWindow.result.Text = taskControl.SelectWorkTask.Name + Environment.NewLine;
            newReminderWindow.result.Text += taskControl.SelectWorkTask.Text;
            if (newReminderWindow.ShowDialog() == true)
            {
                taskControl.AddRimender(newReminderWindow.result);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.notifyIcon.Dispose();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.ShowInTaskbar = true;
            this.Topmost = true;
            this.Topmost = false;
        }

        private void WorkTaskView_DeleteReminderButtonClick(object sender, RoutedEventArgs e)
        {
            var reminderEventArgs = e.OriginalSource as DeleteReminderEventArgs;
            taskControl.DeleteRimender(reminderEventArgs.Reminder);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ceanClose)
            {
                e.Cancel = true;
                this.WindowState = WindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
