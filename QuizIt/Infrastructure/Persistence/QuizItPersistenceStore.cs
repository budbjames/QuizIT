using Infrastructure.Quizit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// Represents the persistence object for the quiz it application.
    /// This particular implementation is based on the RavenDB database.
    /// </summary>
    /// <typeparam name="T">The type in which you wish to store or retrieve</typeparam>
    public class QuizItPersistenceStore<T> : RavenDbPersistenceStoreBase<T>, IDataPersistenceStore<T>
    {
        public QuizItPersistenceStore() 
            : base()
        { 
        
        }
        
        //public QuizItPersistenceStore(string dataDirectory)
        //    : base(dataDirectory)
        //{
        //    if (dataDirectory == null)
        //        throw new ArgumentNullException("dataDirectory");
        //}
    }
}
