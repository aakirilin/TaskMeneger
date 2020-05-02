using LiteDB;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;

namespace TaskMeneger
{
    public class DB : IDisposable
    {
        private LiteDatabase connection;

        public DB()
        {
            connection = new LiteDatabase("TaskMeneger.db");
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public WorkTask[] GetActiveWorkTask
        {
            get
            {
                WorkTaskTable workTaskDB = new WorkTaskTable(connection);
                return workTaskDB.Tablet.Find(t => t.Statys == WorkTaskStatys.Active).OrderBy(t => t.DateCreate).ToArray();
            }
        }

        public WorkTask[] GetWillDineWorkTask
        {
            get
            {
                WorkTaskTable workTaskDB = new WorkTaskTable(connection);
                return workTaskDB.Tablet.Find(t => t.Statys == WorkTaskStatys.WillDone).OrderBy(t => t.DateCreate).ToArray();
            }
        }

        public void InsertWorkTask(WorkTask workTask)
        {
            WorkTaskTable workTaskDB = new WorkTaskTable(connection);
            if (workTask.Comments != null)
            {
                InsertCommits(workTask.Comments.ToArray());
            }
            if (workTask.Files != null)
            {
                InsertAdditionFiles(workTask.Files.ToArray());
            }
            workTaskDB.Insert(workTask);
        }

        public void InsertCommits(params Comment[] comments)
        {
            CommentTable commentDB = new CommentTable(connection);
            foreach (var comment in comments)
            {
                if (comment.Files != null)
                {
                    InsertAdditionFiles(comment.Files.ToArray());
                }

                commentDB.Insert(comment);
                connection.Commit();
            }
        }

        public void UpdateWorkTask(WorkTask workTask)
        {
            WorkTaskTable workTaskDB = new WorkTaskTable(connection);
            workTaskDB.Update(workTask);
        }

        public void AddComment(WorkTask workTask, Comment comment)
        {
            InsertCommits(comment);
            UpdateWorkTask(workTask);
        }

        public void InsertAdditionFiles(params AdditionFile[] additionFiles)
        {
            foreach (var additionFile in additionFiles)
            {
                connection.FileStorage.Upload(additionFile.Id.ToString(), additionFile.FillPath);
            }
        }

        public void SaveFile(AdditionFile af)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = af.Name;
            if (sf.ShowDialog() == true)
            {
                using (FileStream fileStream = File.Create(sf.FileName))
                {
                    using (var file = connection.FileStorage.OpenRead(af.Id.ToString()))
                    {
                        file.CopyTo(fileStream);
                    }
                }
            }
        }

        public void InsertRiminder(Reminder reminder)
        {
            RiminderTable riminderTablet = new RiminderTable(connection);
            riminderTablet.Insert(reminder);
        }

        public void DeleteRiminder(Reminder reminder)
        {
            RiminderTable riminderTablet = new RiminderTable(connection);
            riminderTablet.Delete(reminder);
        }

        public Reminder[] GetRiminders
        {
            get
            {
                RiminderTable riminderTablet = new RiminderTable(connection);
                return riminderTablet.Tablet.FindAll().ToArray();
            }
        }
    }
}
