using System.Collections.Generic;

namespace GameBook.Models.Io.JsonObject
{
    public class HistoryJson
    {
        public List<int> History { get; set; }
        public List<int> AlreadyRead { get; set; }
        public int LastId { get; set; }
    }
}
