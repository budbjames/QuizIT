using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.QuizIt;
using Service.QuizIt.Interfaces;

namespace QuizIt.ViewModels.Interfaces
{
    /// <summary>
    /// This represents the interface for the 
    /// ViewModel that is bound to the Main Quiz interface.
    /// </summary>
    public interface IMainQuizMenuViewModel
    {
        List<Quiz> Quizes { get; set; }
        IQuizService QuizServiceManager { get; set; }

        void LoadQuizes();
        void CreateQuiz();
        Quiz BuildNewQuiz();
    }
}
