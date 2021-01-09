using GameBook.Models.Book;
using GameBook.Models.History;
using System.IO;

namespace GameBook.Models.Io
{
    public class Services : IServices
    {
        private string _path;
        private string _lastBookPath;
        private IBook _book;
        private IHistory _history;

        private IReadBookService _bookService;
        private IReadHistoryService _historyService;
        private IWriteHistoryService _writeHistory;

        public Services(string path, IReadBookService bookService, IReadHistoryService historyService, IWriteHistoryService writeHistory)
        {
            _path = path;
            _lastBookPath = null;
            _bookService = bookService;
            _historyService = historyService;
            _writeHistory = writeHistory;
        }
        public IBook Book => _book;

        public IHistory History => _history;
        public void Start()
        {
            if (!File.Exists(_path))
            {
                using var f = File.Create(_path);
            }
            using (StreamReader sr = new StreamReader(_path))
            {
                string line = sr.ReadToEnd();
                if (!string.IsNullOrEmpty(line))
                {
                    _lastBookPath = line;
                    Read();
                }
            }
        }

        public void Save()
        {
            if(Book != null) _writeHistory.Save(_history, _lastBookPath.Split('\\')[^1]);
        }

        public bool SetBookName(string path)
        {
            if (File.Exists(path))
            {
                _lastBookPath = path;
                Read();
                using (StreamWriter sr = new StreamWriter(_path))
                {
                    sr.Write(path);
                }
                return true;
            }
            return false;
        }

        private void Read()
        {
            IBook book = _bookService.Read(_lastBookPath);
            if (book != null)
            {
                _book = book;
                _history = _historyService.Read(_lastBookPath.Split('\\')[^1]);
            }
        }
    }

}
