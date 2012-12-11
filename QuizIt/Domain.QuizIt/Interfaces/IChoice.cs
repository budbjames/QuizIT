using System;

namespace Domain.QuizIt
{
    public interface IChoice
    {
        Guid Id { get; set; }
        string Text { get; set; }
        bool IsCorrect { get; set; }
    }
}