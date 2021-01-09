using GameBook.Models.Book;
using GameBook.Models.History;

namespace GameBook.Models.Io
{
    public interface IServices
    {
        IBook Book { get; }
        IHistory History { get; }
        void Start();
        void Save();
        bool SetBookName(string path);
    }
}
