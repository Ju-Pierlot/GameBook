using GameBook.Models.History;
using System.Collections.Generic;
using System.IO;
using GameBook.Models.Io.JsonObject;
using Newtonsoft.Json;

namespace GameBook.Models.Io
{
    public class WriteHistory : IWriteHistoryService
    {
        private string _path;

        public WriteHistory(string defaultPath)
        {
            _path = defaultPath;
        }
        public void Save(IHistory history, string path)
        {
            if (history != null)
            {
                string line = JsonConvert.SerializeObject(ConvertHistory(history));
                if (!File.Exists(_path + path))
                {
                    using var f = File.Create(_path + path);
                }
                Write(line, _path + path);
            }
        }

        private void Write(string line, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.Write(line);
            }
        }
        private HistoryJson ConvertHistory(IHistory history)
        {
            return new HistoryJson()
            {
                History = (List<int>)history.HistoryList,
                AlreadyRead = (List<int>)history.AlreadyRead,
                LastId = history.LastId
            };
        }
    }
}
