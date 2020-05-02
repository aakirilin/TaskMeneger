using LiteDB;

namespace TaskMeneger
{
    public class FileTable : DBTable<AdditionFile>
    {
        public FileTable(LiteDatabase connection) : base(connection)
        {
        }
    }
}
