using Domain.QuizIt;
using Infrastructure.Persistence;
using Microsoft.Practices.Unity;
using Service.QuizIt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.QuizIt
{
    public class QuizService : IQuizService
    {
        private IDataPersistenceStore<Quiz> _dataLayer;

        public QuizService([Dependency("LivePersistenceStore")]IDataPersistenceStore<Quiz> dataLayer)
        {
            if (dataLayer == null)
                throw new ArgumentNullException("dataLayer");

            _dataLayer = dataLayer;

        }

        public List<Quiz> RetrieveQuizes()
        {
            if (_dataLayer == null)
                throw new NullReferenceException("The data layer is null");

            var quizList = _dataLayer.GetAll();

            return quizList;
        }

        public void SaveQuiz(Quiz newQuiz)
        {
            if (newQuiz == null)
                throw new ArgumentNullException("newQuiz");

            if (_dataLayer == null)
                throw new NullReferenceException("The data layer is null");

            _dataLayer.Save(newQuiz);
        }

        public Quiz GetQuiz(Guid Id)
        {
            if (_dataLayer == null)
                throw new NullReferenceException("The data layer is null");

            var quiz = _dataLayer.GetQueryContext().Query<Quiz>().Where(q => (q.Id == Id)).FirstOrDefault();

            return quiz;

        }

        public void RemoveQuiz(Guid Id)
        {
            if (_dataLayer == null)
                throw new NullReferenceException("The data layer is null");

            var quiz = _dataLayer.GetQueryContext().Query<Quiz>().Where(q => (q.Id == Id)).FirstOrDefault();

            if (quiz != null)
                _dataLayer.Remove(quiz);
        }
    }
}
