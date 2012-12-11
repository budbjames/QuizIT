using Infrastructure.DependencyInjection;
using Infrastructure.Persistence;
using Microsoft.Practices.Unity;
using Raven.Client;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Quizit
{
    /// <summary>
    /// This represents the base class for all RavenDb IDataPersistenceStore impelementations
    /// </summary>
    /// <typeparam name="T">The type of business object to retreieve or store.</typeparam>
    public abstract class RavenDbPersistenceStoreBase<T> : IDataPersistenceStore<T> , IDisposable
    {
        private EmbeddableDocumentStore _documentStore;
        private IUnityContainer _container;

        public RavenDbPersistenceStoreBase()
        {
            _container = UnityContainerFactory.GetUnityContainer();
            _documentStore = new EmbeddableDocumentStore { DataDirectory = "Data" };
            _documentStore.Initialize();
        }

        public RavenDbPersistenceStoreBase(string dataDirectory)
        {
            if (dataDirectory == null)
                throw new ArgumentNullException(dataDirectory);
            
            _container = UnityContainerFactory.GetUnityContainer();
            _documentStore = new EmbeddableDocumentStore { DataDirectory = dataDirectory };
            _documentStore.Initialize();
        }

        public virtual void Save(T Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException("Entity");

            if (_documentStore == null)
                throw new NullReferenceException("Raven DB Document store is null");

            using (var documentSession = _documentStore.OpenSession())
            {
                documentSession.Store(Entity);
                documentSession.SaveChanges();
            }
        }

        /// <summary>
        /// Query the document store for all objects of the specified type.
        /// </summary>
        /// <returns>A list of all of the specified objects that are stored in the database</returns>
        public virtual List<T> GetAll()
        {
            var documentList = new List<T>();

            using (var documentSession = _documentStore.OpenSession())
            {
                documentList = 
                    documentSession.Query<T>().Select(doc => doc).ToList();
            }

            return documentList;
        }

        public virtual IDocumentSession GetQueryContext()
        {
            if (_documentStore == null)
                throw new NullReferenceException("Raven DB Document store is null");

            var documentSession = _documentStore.OpenSession();
            return documentSession;
        }

        public void Remove(T entity)
        {
            if (_documentStore == null)
                throw new NullReferenceException("Raven DB Document store is null");

            var documentSession = _documentStore.OpenSession();

            if (entity != null)
                documentSession.Delete(entity);

        }


        public void Dispose()
        {
            if (_documentStore != null)
                _documentStore.Dispose();
        }
    }
}
