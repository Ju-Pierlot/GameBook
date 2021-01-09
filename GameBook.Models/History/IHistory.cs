using System.Collections.Generic;

namespace GameBook.Models.History
{
    public interface IHistory
    {
        bool Contains(int currentParagraphId);
        int PrecedingId { get; }
        int IdNext(int id);
        IList<int> AlreadyRead { get; }
        IList<int> HistoryList { get; }
        int LastId { get; }
        void AddInHistory(int id);
        void AddInAlreadyRead(int id);
        int GoTo(int id);
        int Back(int id);
        void Reset();
        int GetCurrentParagraphId { get; }
    }
}
