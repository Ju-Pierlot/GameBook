using System.Collections.Generic;
using GameBook.Models.Answer;

namespace GameBook.Models.Paragraph
{
    public interface IParagraph
    {
        string Label { get; }
        int Id { get; }
        IList<string> Answers { get; }
        bool IsTerminal { get; }
        void AddAnswer(IAnswer answer);
        void AddAnswers(params IAnswer[] answers);
        int NextParagraphId(string answer);
        string ColorStart { get; }
        string ColorEnd { get; }
    }
}
