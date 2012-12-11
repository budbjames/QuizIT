using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.DependencyInjection;
using Infrastructure.Persistence;
using Infrastructure.Quizit;
using Microsoft.Practices.Unity;
using Raven.Client;
using Domain.QuizIt;

namespace Testing.QuizIt
{
    /// <summary>
    /// The purpose of this test fixture is to test the infrastructure layer in isolation 
    /// </summary>
    [TestClass]
    public class InfrastructureTestFixtrure
    {
        //TODO Test GetAll()
        //TODO Mock out the IDataPersistenceStore to test the interface without using the database
        private static IUnityContainer _container;

        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            _container = UnityContainerFactory.GetUnityContainer();
            _prepareContainer();
        }

        private static void _prepareContainer()
        {
            if (_container == null)
                throw new NullReferenceException("The dependency injection container is null.");

            _container.RegisterType(typeof(IDataPersistenceStore<Quiz>), typeof(QuizItPersistenceStore<Quiz>));
        }
     
        /// <summary>
        /// The method will test creating an object, saving it to the Embedded RavenDB 
        /// server and then retreiving the saved object.  This test uses live data.
        /// </summary>
        [TestMethod]
        public void Test_Save_Entity()
        {
            var dataAccess = _container.Resolve<IDataPersistenceStore<Quiz>>();

            var quiz = new Quiz
            {
                Id = Guid.NewGuid(),
                QuizName = "Test Quiz",
                QuizDescription = "Test Quiz Description"
            };

            dataAccess.Save(quiz);

            Quiz savedQuiz = null;

            using (IDocumentSession session = dataAccess.GetQueryContext())
            {
                savedQuiz = session.Query<Quiz>().FirstOrDefault(QuizVar => (QuizVar.Id == quiz.Id));
            }

            Assert.AreEqual(quiz.Id, savedQuiz.Id);
        }

        [TestMethod]
        public void Test_Get_All_From_PersistenceStore()
        {
            //Grab an instance of the Test data persistance object
            var dataAccess = _container.Resolve<IDataPersistenceStore<Quiz>>();

            //save 4 Mock Quiz objects to the datastore
            for (int counter = 0; counter < 4; counter++)
            {
                SaveQuiz(dataAccess);
            }

            var allQuizes = dataAccess.GetAll();

            var quizList = allQuizes;

            Assert.IsTrue(quizList.Count > 0);
        }


        #region "helper methods"

        private static void SaveQuiz(IDataPersistenceStore<Quiz> dataAccess)
        {
            var quiz = new Quiz
            {
                Id = Guid.NewGuid(),
                QuizName = "Test Quiz",
                QuizDescription = "Test Quiz Description"
            };

            dataAccess.Save(quiz);
        }

        #endregion
        
    }
}
