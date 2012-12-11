using Domain.QuizIt;
using Microsoft.Practices.Unity;
using QuizIt.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Service.QuizIt.Interfaces;

namespace QuizIt.ViewModels
{
    /// <summary>
    /// This represents the ViewModel that is bound to the Main Quiz user interface.
    /// </summary>
    public class MainQuizMenuViewModel : IMainQuizMenuViewModel
    {

        #region "public properties"

        public ICommand LoadQuizesCommand { get; set; }
        public ICommand CreateQuizCommand { get; set; }
        public IQuizService QuizServiceManager { get; set; }
        public List<Quiz> Quizes { get; set; }
        public string QuizName { get; set; }
        public string QuizDescription { get; set; }

        #endregion

        #region "constructors"

        public MainQuizMenuViewModel([Dependency("LoadQuizes")]ICommand loadQuizesCommand,
            [Dependency("CreateQuiz")]ICommand createQuizCommand, [Dependency]IQuizService quizServiceManager)
        {
            this.LoadQuizesCommand = loadQuizesCommand;
            this.CreateQuizCommand = createQuizCommand;
            this.QuizServiceManager = quizServiceManager;
        }

        #endregion


        #region "public methods"

        /// <summary>
        /// The purpose of this method is to execute the LoadQuizesCommand
        /// </summary>
        public void LoadQuizes()
        {
            if (this.LoadQuizesCommand == null)
                throw new NullReferenceException("The load quizes command is null");

            this.LoadQuizesCommand.Execute(this);
        }

        /// <summary>
        /// The purpose of this method is to execute the CreateQuizCommand
        /// This would be used in if the view didn't support ICommand 
        /// </summary>
        public void CreateQuiz()
        {
            if (this.CreateQuizCommand == null)
                throw new NullReferenceException("The create quiz command is null");

            this.CreateQuizCommand.Execute(this);
        }

        /// <summary>
        /// The purpose of this method is to create a new quiz from the
        /// data bound view model property values and save the entity to the data store
        /// </summary>
        public Quiz BuildNewQuiz()
        {
            //attempt to validate the view
            if (!_validateQuiz())
            {
                _invalidateView();

                return null;
            }
            
            //create a new quiz object and populate the properties with the values of the 
            //ViewModel properties
            var newQuiz = new Quiz
            {
                Id = Guid.NewGuid(),
                QuizName = this.QuizName,
                QuizDescription = this.QuizDescription
            };

            this.QuizServiceManager.SaveQuiz(newQuiz);

            //if (this.Quizes == null)
            //    this.Quizes = new List<Quiz>();

            //this.Quizes.Add(newQuiz);

            this.LoadQuizes();

            //return the quiz to the caller
            return newQuiz;
        }

        #endregion

        #region "private methods"

        private void _invalidateView()
        {
            throw new NotImplementedException();
        }

        private bool _validateQuiz()
        {
            return true;
        }

        #endregion
        
    }
}
