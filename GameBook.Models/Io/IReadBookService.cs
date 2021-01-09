using GameBook.Models.Book;

namespace GameBook.Models.Io
{
    public interface IReadBookService
    {
        IBook Read(string path);
    }
}
