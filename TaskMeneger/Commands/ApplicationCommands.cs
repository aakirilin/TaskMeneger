using System.Windows.Input;

namespace TaskMeneger.Commands
{
    public class ApplicationCommands
    {
        public static RoutedUICommand ApplyButton_Command
                            = new RoutedUICommand("Set true dialog result",
                                                  "ApplyButton_Command",
                                                  typeof(ApplicationCommands));
        public static RoutedUICommand AddFileButton_Command
                            = new RoutedUICommand("Open dialog for add files",
                                                  "AddFileButton_Command",
                                                  typeof(ApplicationCommands));
        public static RoutedUICommand AddCommetnButton_Command
                            = new RoutedUICommand("Open dialog for add comment",
                                                  "AddCommetnButton_Command",
                                                  typeof(ApplicationCommands));
        public static RoutedUICommand AddTaskButton_Command
                            = new RoutedUICommand("Open dialog for add task",
                                                  "AddTaskButton_Command",
                                                  typeof(ApplicationCommands));
        public static RoutedUICommand AddReminderButton_Command
                            = new RoutedUICommand("Open dialog for add reminder",
                                                  "AddReminderButton_Command",
                                                  typeof(ApplicationCommands));

        public static RoutedUICommand RememberAfterOneHoursButton_Command
                            = new RoutedUICommand("Remember After One Hours Button Command",
                                                  "RememberAfterOneHoursButton_Command",
                                                  typeof(ApplicationCommands));
        public static RoutedUICommand RememberAfterOneDayButton_Command
                            = new RoutedUICommand("Remember After One Day Button Command",
                                                  "RememberAfterOneDayButton_Command",
                                                  typeof(ApplicationCommands));

        public static RoutedUICommand DeleteReminderButton_Command
                            = new RoutedUICommand("Delete Reminder Button Command",
                                                  "DeleteReminderButton_Command",
                                                  typeof(ApplicationCommands));

        public static RoutedUICommand SaveFileButton_Command
                            = new RoutedUICommand("Save File Button Command",
                                                  "SaveFileButton_Command",
                                                  typeof(ApplicationCommands));
    }
}
