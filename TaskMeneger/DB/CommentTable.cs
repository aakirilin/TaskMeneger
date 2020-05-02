using LiteDB;

namespace TaskMeneger
{
    public class CommentTable : DBTable<Comment>
    {
        public CommentTable(LiteDatabase connection) : base(connection)
        {
        }
    }
}
