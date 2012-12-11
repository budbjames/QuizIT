using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.QuizIt
{
    /// <summary>
    /// The purpose of this class is to provide an arbitrary object for testing the persistence layer
    /// </summary>
    public class MockQuiz
    {
        public Guid Id { get; set; }
        public string QuizName { get; set; }
        public string QuizDescription { get; set; }
    }
}
