using LiteDB;

namespace TaskMeneger
{
    public class WorkTaskTable : DBTable<WorkTask>
    {
        public WorkTaskTable(LiteDatabase connection) : base(connection)
        {
        }
    }
}
