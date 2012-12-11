using Domain.QuizIt;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// Represents the interface in which to generically save data to the underlying data store
    /// </summary>
    public interface IDataPersistenceStore<T>
    {
        void Save(T Entity);
        List<T> GetAll();
        IDocumentSession GetQueryContext();

        void Remove(T Entity);
    }
}
