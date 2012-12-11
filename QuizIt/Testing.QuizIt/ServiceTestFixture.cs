using System;
using System.Threading;
using System.Windows.Input;
using ApplicationLayer.QuizIt.Commands;
using Infrastructure.DependencyInjection;
using Infrastructure.Persistence;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.QuizIt;
using QuizIt.ViewModels;
using QuizIt.ViewModels.Interfaces;
using Service.QuizIt;
using Service.QuizIt.Interfaces;

namespace Testing.QuizIt
{
    [TestClass]
    public class ServiceTestFixture
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

            _container.RegisterType<IQuizService, QuizService>();
            _container.RegisterType<IDataPersistenceStore<Quiz>, QuizItPersistenceStore<Quiz>>("LivePersistenceStore");
        }



        [TestMethod]
        public void Test_Retrieve_Quizes()
        {
            var quizService = _container.Resolve<IQuizService>();

            if (quizService == null)
                throw new NullReferenceException("Quiz service is null.");

            var quizes = quizService.RetrieveQuizes();

            if (quizes == null)
                throw new NullReferenceException("Unable to retrieve quizes from service layer.");

            Assert.IsTrue((quizes.Count > 0));
        }

        [TestMethod]
        public void Test_Save_Quiz()
        {
            var quiz = Quiz.CreateQuiz();

            _saveTestQuiz(quiz);
        }

        

        [TestMethod]
        public void Test_Retrieve_Quiz_By_Id()
        {
            var quizToSave = Quiz.CreateQuiz();

            _saveTestQuiz(quizToSave);

            var quizService = _container.Resolve<IQuizService>();

            var quizToLoad = quizService.GetQuiz(quizToSave.Id);

            Assert.AreEqual(quizToSave.Id, quizToLoad.Id);

        }

        [TestMethod]
        public void Test_Remove_Quiz_By_Id()
        {
            var quizToRemove = Quiz.CreateQuiz();

            _saveTestQuiz(quizToRemove);

            var quizService = _container.Resolve<IQuizService>();

            quizService.RemoveQuiz(quizToRemove.Id);

            Assert.AreEqual(quizToRemove.Id, quizToRemove.Id);
        }

        [TestMethod]
        public void Test_Remove_Quiz_By_Object()
        {

        }
        


        [TestMethod]
        public void Test_Begin_Quiz_End_Quiz_Time_Elapsed()
        {
            //create a quiz 
            var quiz = Quiz.CreateQuiz();

            //create 4 questions
            var questionOne = _buildTestQuestion();

            quiz.Questions.Add(questionOne);

            //start the quiz
            quiz.StartQuiz();

            Thread.Sleep(10000);

            quiz.EndQuiz();

            Assert.IsTrue((quiz.StartTime < quiz.EndTime));

        }

        [TestMethod]
        public void Test_Randomize_Quiz_Choices()
        {
            //create a quiz 
            var quiz = Quiz.CreateQuiz();

            //create 4 questions
            var questionOne = _buildTestQuestion();

            //grab the Id of the first question
            Guid currentId = questionOne.Choices[0].Id;

            quiz.Questions.Add(questionOne);

            //start the quiz
            quiz.StartQuiz();

            //check that the first question's id doesn't match
            //the previous first question ID
            Assert.AreNotEqual(currentId, quiz.Questions[0].Choices[0].Id);

        }

        

        [TestMethod]
        public void Test_Randomize_Quiz_Questions()
        {
            //create a quiz 
            var quiz = Quiz.CreateQuiz();

            //create 4 questions
            var questionOne = _buildTestQuestion();
            var questionTwo = _buildTestQuestion();
            var questionThree = _buildTestQuestion();
            var questionFour = _buildTestQuestion();

            quiz.Questions.Add(questionOne);
            quiz.Questions.Add(questionTwo);
            quiz.Questions.Add(questionThree);
            quiz.Questions.Add(questionFour);

            //grab the Id of the first question
            Guid currentId = quiz.Questions[0].Id;

            //start the quiz
            quiz.StartQuiz();

            //check that the first question's id doesn't match
            //the previous first question ID
            Assert.AreNotEqual(currentId, quiz.Questions[0].Id);

        }


        private Question _buildTestQuestion()
        {
            var questionOne = new Question { Text = "What is 2 + 2?" };

            if (questionOne.Choices == null)
                throw new NullReferenceException("Choices collection cannot be null");

            questionOne.Choices.Add(new Choice { IsCorrect = true, Text = "4" });
            questionOne.Choices.Add(new Choice { IsCorrect = false, Text = "1" });
            questionOne.Choices.Add(new Choice { IsCorrect = false, Text = "2" });
            questionOne.Choices.Add(new Choice { IsCorrect = false, Text = "3" });
            return questionOne;
        }

        private void _saveTestQuiz(Quiz quiz)
        {
            quiz.Questions.Add(_buildTestQuestion());
            quiz.Questions.Add(_buildTestQuestion());
            quiz.Questions.Add(_buildTestQuestion());
            quiz.Questions.Add(_buildTestQuestion());

            var quizService = _container.Resolve<IQuizService>();

            quizService.SaveQuiz(quiz);
        }
    }
}
