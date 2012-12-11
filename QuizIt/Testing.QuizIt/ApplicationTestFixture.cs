using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Infrastructure.DependencyInjection;
using Infrastructure.Persistence;
using Infrastructure.Quizit;
using System.Windows.Input;
using QuizIt.ViewModels.Interfaces;
using QuizIt.ViewModels;
using System.Collections.Generic;
using QuizIt.ViewModels.Interfaces;
using QuizIt.ViewModels;
using ApplicationLayer.QuizIt.Commands;
using Service.QuizIt.Interfaces;
using Service.QuizIt;
using Domain.QuizIt;

namespace Testing.QuizIt
{
    /// <summary>
    /// The purpose of this test fixture is to test the Application layer in isolation 
    /// </summary>
    [TestClass]
    public class ApplicationTestFixture
    {
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

            //TODO implement a dictionary<string, ICommand> of different commands that a view model supports
            _container.RegisterType<ICommand, LoadQuizesCommand>("LoadQuizes");
            _container.RegisterType<ICommand, CreateQuizCommand>("CreateQuiz");

            //TODO come up with an IViewModel interface
            //TODO come up with an IView interface that holds a reference to each view in the ViewModel
            _container.RegisterType<IMainQuizMenuViewModel, MainQuizMenuViewModel>();


            _container.RegisterType<IQuizService, QuizService>();

            //_container.RegisterType<IDataPersistenceStore<MockQuiz>, QuizItTestPersistenceStore<MockQuiz>>("TestPersistenceStore");
            _container.RegisterType<IDataPersistenceStore<Quiz>, QuizItPersistenceStore<Quiz>>("LivePersistenceStore");
        }

        /// <summary>
        /// This test will test loading the quizes by executing a command on the ViewModel
        /// to populate the Quizes property on the ViewModel.  
        /// </summary>
        [TestMethod]
        public void Test_Load_All_Quizes()
        {
            //create an instance of the ViewModel
            var viewModel = _container.Resolve<IMainQuizMenuViewModel>();

            //execute the command to load all quizes
            viewModel.LoadQuizes();

            //assert that the quizes property has a collection of quizes
            Assert.IsTrue(viewModel.Quizes.Count > 0);
        }


        /// <summary>
        /// This will test saving a new Quiz from the ViewModel data that should
        /// </summary>
        [TestMethod]
        public void Test_Create_a_new_Quiz()
        {
            //create an instance of the ViewModel
            var viewModel = _container.Resolve<IMainQuizMenuViewModel>();

            //execute the command to load all quizes
            viewModel.CreateQuiz();

            //assert that the quizes property has a collection of quizes
            Assert.IsTrue(viewModel.Quizes.Count > 0);
        }

    }
}
