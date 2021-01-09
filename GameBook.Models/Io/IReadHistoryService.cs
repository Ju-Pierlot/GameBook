using GameBook.Models.History;

namespace GameBook.Models.Io
{
    public interface IReadHistoryService
    {
        IHistory Read(string path);
    }
}
