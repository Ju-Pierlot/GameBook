using GameBook.Models.History;
using System;
using System.IO;
using GameBook.Models.Io.JsonObject;
using Newtonsoft.Json;

namespace GameBook.Models.Io
{
    public class ReadHistory : IReadHistoryService
    {
        private string _defaultRepertory;

        public ReadHistory(string defaultRepertory)
        {
            _defaultRepertory = defaultRepertory;
        }
        public IHistory Read(string path)
        {
            if (File.Exists(_defaultRepertory + path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(_defaultRepertory + path))
                    {
                        string line = sr.ReadToEnd();
                        HistoryJson historyJson = JsonConvert.DeserializeObject<HistoryJson>(line);
                        return convertJsonHistory(historyJson);
                    }
                }
                catch(Exception e)
                {
                }
                return new History.History();
            }
            using var f = File.Create(_defaultRepertory + path);
            return new History.History();
        }

        private IHistory convertJsonHistory(HistoryJson historyJson)
        {
            if(historyJson == null) return new History.History();
            return new History.History(historyJson.History, historyJson.AlreadyRead, historyJson.LastId);
        }
    }
}
