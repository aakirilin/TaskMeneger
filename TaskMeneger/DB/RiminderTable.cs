using LiteDB;

namespace TaskMeneger
{
    public class RiminderTable : DBTable<Reminder>
    {
        public RiminderTable(LiteDatabase connection) : base(connection)
        {
        }
    }
}
