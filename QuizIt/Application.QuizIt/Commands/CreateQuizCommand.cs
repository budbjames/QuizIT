using QuizIt.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ApplicationLayer.QuizIt.Commands
{
    /// <summary>
    /// The purpose of this command is create a new Quiz in the data store
    /// </summary>
    public class CreateQuizCommand : ICommand
    {
        private IMainQuizMenuViewModel _viewModel;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            _viewModel = (IMainQuizMenuViewModel)parameter;

            var newQuiz = _viewModel.BuildNewQuiz();


        }
    }
}
