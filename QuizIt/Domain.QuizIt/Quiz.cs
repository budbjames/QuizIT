using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.QuizIt
{
    public class Quiz
    {
        private List<Question> _questions;

        public Guid Id { get; set; }

        public string QuizName { get; set; }

        public string QuizDescription { get; set; }

        public List<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        /// <summary>
        /// The purpose of this routine is to create a new quiz object
        /// and generate all of the necessarly properties.
        /// </summary>
        /// <returns>A new Quiz</returns>
        public static Quiz CreateQuiz()
        {
            var returnQuiz = new Quiz
                {
                    Id = Guid.NewGuid(),
                    QuizName = "new quiz",
                    QuizDescription = "new quiz",
                    Questions = new List<Question>()
                };

            return returnQuiz;
        }


        /// <summary>
        /// This method is called when a user starts to take a quiz.
        /// </summary>
        public void StartQuiz()
        {
            if (this.Questions == null)
                throw new NullReferenceException("Questions list cannot be null");

            //randomize the questions
            _randomizeQuestions();

            this.StartTime = DateTime.Now;

        }

        private void _randomizeQuestions()
        {
            Random rnd = new Random();
            this.Questions = (from question in this.Questions
                                 orderby rnd.Next()
                                 select question).ToList();
            this.Questions.ForEach(question => question.RandomizeChoices());
        }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public void EndQuiz()
        {
            this.EndTime = DateTime.Now;
        }
    }
}
