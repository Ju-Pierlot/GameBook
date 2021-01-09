using System.Collections.Generic;

namespace GameBook.Models.History
{
    public class History : IHistory
    {
        public History(IList<int> history, IList<int> alreadyRead, int lastId)
        {
            LastId = lastId;
            HistoryList = history;
            AlreadyRead = alreadyRead;
        }
        public History() : this(new List<int>() { 0 }, new List<int>(), 0)
        { }

        public int PrecedingId
        {
            get
            {
                if (AlreadyRead.Count > 0) return AlreadyRead[^1];
                return LastId;
            }
        }

        public IList<int> AlreadyRead { get; }


        public int LastId { get; private set; }

        public IList<int> HistoryList { get; }

        public int GetCurrentParagraphId => HistoryList[^1];

        public void AddInAlreadyRead(int id)
            => AlreadyRead.Add(id);

        public void AddInHistory(int id)
            => HistoryList.Add(id);

        public int Back(int id)
        {
            if (HistoryList.Count > 1)
            {
                AddInAlreadyRead(id);
                HistoryList.RemoveAt(HistoryList.Count - 1);
                return HistoryList[^1];
            }
            return -1;
        }

        public bool Contains(int currentParagraphId)
            => AlreadyRead.Contains(currentParagraphId);

        public int GoTo(int id)
        {
            AdaptAlreadyRead(id);
            if (HistoryList.Count > 0) LastId = HistoryList[^1];
            AdaptHistory(id);
            return id;
        }

        private void AdaptHistory(int id)
        {
            for (int i = 0; i < HistoryList.Count - 1; i++)
            {
                if (HistoryList[i] == id)
                {
                    ((List<int>) HistoryList).RemoveRange(i + 1, HistoryList.Count - (i + 1));
                    break;
                }
            }
        }

        private void AdaptAlreadyRead(int id)
        {
            for (int i = 0; i < AlreadyRead.Count; i++)
            {
                if (AlreadyRead[i] == id)
                {
                    ((List<int>)AlreadyRead).RemoveRange(i, AlreadyRead.Count - i);
                    break;
                }
            }
        }

        public int IdNext(int id)
        {
            for (int i = 2; i < AlreadyRead.Count + 1; i++)
            {
                if (id == AlreadyRead[^i]) return AlreadyRead[^(i - 1)];
            }
            return -1;
        }
        public void Reset()
        {
            AlreadyRead.Clear();
            HistoryList.Clear();
            AddInHistory(0);
            LastId = 0;
        }
    }
}
