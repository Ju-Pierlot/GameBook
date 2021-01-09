using System;
using System.Collections.Generic;
using GameBook.Models.Book;
using GameBook.Models.History;
using GameBook.Models.Paragraph;

namespace GameBook.Models.ReadingSession
{
    public class ReadingSession : IReadingSession
    {
        private IBook _book;
        private IHistory _history;
        private IParagraph _currentParagraph;

        public event EventHandler<EventArgs> CurrentParagraphChanged;

        public ReadingSession(IBook book, IHistory history)
        {
            if (book == null || history == null) throw new Exception("book or history is null");
            _book = book;
            _history = history;
            _currentParagraph = book[_history.GetCurrentParagraphId];
        }
        public string Title => _book.Title;

        public string Paragraph => _currentParagraph.Label;

        public IList<string> Answers => _currentParagraph.Answers;

        public bool IsFinish => _currentParagraph.IsTerminal;

        public int Id => _currentParagraph.Id;

        public string ColorStart => _currentParagraph.ColorStart;

        public string ColorEnd => _currentParagraph.ColorEnd;

        public bool AlreadyRead => _history.Contains(_currentParagraph.Id);

        public int PrecedingId => _history.PrecedingId;

        public int IdNextCurrent => _history.IdNext(_currentParagraph.Id);

        public IList<string> ParagraphsRead
        {
            get
            {
                ISet<IParagraph> paragraphsSorted = new SortedSet<IParagraph>();
                IList<string> paragraphs = new List<string>();
                foreach (var i in _history.AlreadyRead) paragraphsSorted.Add(_book[i]);
                paragraphsSorted.Add(_currentParagraph);
                foreach (var paragraph in paragraphsSorted) paragraphs.Add(paragraph.ToString());
                return paragraphs;
            }
        }
        public void Next(string answer)
        {
            int i = _currentParagraph.NextParagraphId(answer);
            if (i >= 0)
            {
                _history.AddInAlreadyRead(_currentParagraph.Id);
                _history.AddInHistory(i);
                _currentParagraph = _book[i];
                CurrentParagraphChanged?.Invoke(this, new EventArgs());
            }
        }

        public void Back()
        {
            int i = _history.Back(_currentParagraph.Id);
            if (i != -1)
            {
                _currentParagraph = _book[i];
                CurrentParagraphChanged?.Invoke(this, new EventArgs());
            }
        }

        public void GoTo(int id)
        {
            _currentParagraph = _book[_history.GoTo(id)];
            CurrentParagraphChanged?.Invoke(this, new EventArgs());
        }

        public void Reset()
        {
            _history.Reset();
            _currentParagraph = _book[0];
            CurrentParagraphChanged?.Invoke(this, new EventArgs());
        }
        public void SetNewBook(IBook book, IHistory history)
        {
            if (history != null & book != null)
            {
                _book = book;
                _history = history;
                _currentParagraph = _book[_history.GetCurrentParagraphId];
            }
            CurrentParagraphChanged?.Invoke(this, new EventArgs());
        }
    }
}
