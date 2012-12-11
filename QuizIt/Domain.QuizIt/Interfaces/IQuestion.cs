using System;
using System.Collections.Generic;

namespace Domain.QuizIt
{
    public interface IQuestion
    {
        Guid Id { get; set; }
        string Text { get; set; }
        List<IChoice> Choices { get; set; }
        int ScoreValue { get; set; }
    }
}