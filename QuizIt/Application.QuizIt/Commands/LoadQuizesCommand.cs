using QuizIt.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ApplicationLayer.QuizIt.Commands
{
    /// <summary>
    /// The purpose of this command is to call to the service layer
    /// to retreive all existing quizes from the data store.
    /// </summary>
    public class LoadQuizesCommand : ICommand
    {
        private IMainQuizMenuViewModel _viewModel;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
                throw new Exception("unable to execute command.");

            if (parameter == null)
                throw new ArgumentNullException("parameter");

            _viewModel = (IMainQuizMenuViewModel)parameter;

            if (_viewModel.QuizServiceManager == null)
                throw new NullReferenceException("The quiz service manager is null");

            _viewModel.Quizes = _viewModel.QuizServiceManager.RetrieveQuizes();

        }
    }
}
