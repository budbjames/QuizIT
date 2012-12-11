using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.QuizIt
{
    /// <summary>
    /// Represents a multiple choice of a question
    /// </summary>
    public class Choice : IChoice
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Choice()
        {
            Id = Guid.NewGuid();
            IsCorrect = false;
        }
    }
}
