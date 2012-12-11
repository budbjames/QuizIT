using Domain.QuizIt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.QuizIt.Interfaces
{
    public interface IQuizService
    {
        List<Quiz> RetrieveQuizes();


        void SaveQuiz(Quiz newQuiz);

        Quiz GetQuiz(Guid guid);

        void RemoveQuiz(Guid guid);
    }
}
