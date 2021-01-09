using System;
using System.Collections.Generic;

using GameBook.Models.Book;
using GameBook.Models.History;

namespace GameBook.Models.ReadingSession
{
    public interface IReadingSession
    {
        string Title { get; }
        int Id { get; }
        string Paragraph { get; }
        IList<string> Answers { get; }
        string ColorStart { get; }
        string ColorEnd { get; }
        bool IsFinish { get; }
        bool AlreadyRead { get; }
        int PrecedingId { get; }
        int IdNextCurrent { get; }
        IList<string> ParagraphsRead { get; }
        void Next(string answer);
        void Back();
        void GoTo(int id);
        void Reset();
        void SetNewBook(IBook book, IHistory history);

        event EventHandler<EventArgs> CurrentParagraphChanged;
    }
}
