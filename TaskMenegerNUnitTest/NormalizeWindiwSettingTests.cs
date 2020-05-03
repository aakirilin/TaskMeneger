using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TaskMeneger.Properties;
using TaskMeneger;
using System.Diagnostics;

namespace TaskMenegerNUnitTest
{
    [TestFixture]
    public class NormalizeWindiwSettingTests
    {
        private Settings settings;

        [SetUp]
        public void Setup()
        {
            settings = Settings.Default;
            var primaryMonitorArea = SystemParameters.WorkArea;
            var wigthWorkArea = primaryMonitorArea.Right;
            var heigthWorkArea = primaryMonitorArea.Bottom;
            var max = wigthWorkArea > heigthWorkArea ? wigthWorkArea : heigthWorkArea;
            max *= 2;
            settings.NewCommentWindowWidth = max;
            settings.NewCommentWindowHeigth = max;
            settings.NewCommentWindowTop = max;
            settings.NewCommentWindowLeft = max;
            settings.NewReminderWindowWidth = max;
            settings.NewReminderWindowHeigth = max;
            settings.NewReminderWindowTop = max;
            settings.NewReminderWindowLeft = max;
            settings.NewTaskWindowsWidth = max;
            settings.NewTaskWindowsHeigth = max;
            settings.NewTaskWindowsTop = max;
            settings.NewTaskWindowsLeft = max;
            settings.AddFilesWindowWidth = max;
            settings.AddFilesWindowHeigth = max;
            settings.AddFilesWindowTop = max;
            settings.AddFilesWindowLeft = max;
            settings.MainWindowHeigth = max;
            settings.MainWindowWidth = max;
            settings.MainWindowTop = max;
            settings.MainWindowLeft = max;
        }


        [Test]
        public void AddFilesWindowTest()
        {
            Type type = typeof(AddFilesWindow);
            try
            {
                NormalizeWindiwSetting.Normalize(type);
            }
            catch (Exception e)
            {
                Assert.Fail($"{type.Name} Test is Fail {Environment.NewLine}{e.Message}");
            }
        }


        [Test]
        public void MainWindowTest()
        {
            Type type = typeof(MainWindow);
            try
            {
                NormalizeWindiwSetting.Normalize(type);
            }
            catch (Exception e)
            {
                Assert.Fail($"{type.Name} Test is Fail {Environment.NewLine}{e.Message}");
            }
        }

        [Test]
        public void NewCommentWindowTest()
        {
            Type type = typeof(NewCommentWindow);
            try
            {
                NormalizeWindiwSetting.Normalize(type);
            }
            catch (Exception e)
            {
                Assert.Fail($"{type.Name} Test is Fail {Environment.NewLine}{e.Message}");
            }
        }

        [Test]
        public void NewReminderWindowTest()
        {
            Type type = typeof(NewReminderWindow);
            try
            {
                NormalizeWindiwSetting.Normalize(type);
            }
            catch (Exception e)
            {
                Assert.Fail($"{type.Name} Test is Fail {Environment.NewLine}{e.Message}");
            }
        }

        [Test]
        public void NewTaskWindowsTest()
        {
            Type type = typeof(NewTaskWindows);
            try
            {
                NormalizeWindiwSetting.Normalize(type);
            }
            catch (Exception e)
            {
                Assert.Fail($"{type.Name} Test is Fail {Environment.NewLine}{e.Message}");
            }
        }
    }
}
