using GameBook.Models.History;

namespace GameBook.Models.Io
{
    public interface IWriteHistoryService
    {
        void Save(IHistory history, string path);
    }
}
