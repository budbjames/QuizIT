using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.QuizIt
{
    /// <summary>
    /// Represents a quiz question
    /// </summary>
    public class Question : IQuestion
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<IChoice> Choices { get; set; }
        public int ScoreValue { get; set; }

        public Question()
        {
            this.Id = Guid.NewGuid();
            this.Choices = new List<IChoice>();
        }

        public void RandomizeChoices()
        {
            Random rnd = new Random();
            this.Choices = (from choice in this.Choices
                              orderby rnd.Next()
                              select choice).ToList();
        }
    }
}
