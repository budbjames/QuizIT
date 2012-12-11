//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    //TODO refactor out the querying method so that this can be easily mocked
    public class QuizItTestPersistenceStore<T> : IDataPersistenceStore<T>
    {

        public void Save(T Entity)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Raven.Client.IDocumentSession GetQueryContext()
        {
            throw new System.NotImplementedException();
        }


        public void Remove(T Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
