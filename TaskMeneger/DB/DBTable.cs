using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace TaskMeneger
{
    public class DBTable<T> where T : class, IDB
    {
        private LiteDatabase connection;

        private string TabletName
        {
            get
            {
                return typeof(T).ToString().Replace('.', '_');
            }
        }
        private ILiteCollection<T> tablet;
        public ILiteCollection<T> Tablet
        {
            get
            {
                if (tablet == null)
                {
                    tablet = connection.GetCollection<T>(TabletName);
                }
                return tablet;
            }
        }


        public void Insert(T obj)
        {
            Tablet.Insert(obj);
        }

        public void Insert(IEnumerable<T> obj)
        {
            Tablet.Insert(obj);
        }


        public void Update(T obj)
        {
            Tablet.Update(obj);
        }

        public void Delete(BsonValue Id)
        {
            Tablet.Delete(Id);
        }

        public void Delete(T obj)
        {
            Delete(obj.Id);
        }

        public IEnumerable<T> Find(BsonExpression predicate)
        {
            return Tablet.Find(predicate);
        }

        public T FindObj(BsonExpression predicate)
        {
            return Find(predicate).FirstOrDefault();
        }

        public DBTable(LiteDatabase connection)
        {
            this.connection = connection;
        }
    }
}
