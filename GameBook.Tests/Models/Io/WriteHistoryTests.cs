using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GameBook.Models.History;
using GameBook.Models.Io;
using NUnit.Framework;

namespace GameBook.Tests.Models.Io
{
    class WriteHistoryTests
    {
        [Test]
        public void WriteTest()
        {
            string path = @"..\..\..\Saves\HistoriesTest\WriteHistoryTest.json";
            string line;

            IHistory history = new History(new List<int>()
            {
                6,
                8
            }, new List<int>()
            {
                5,
                9
            }, 
                9);
            IWriteHistoryService whs = new WriteHistory(@"..\..\..\Saves\HistoriesTest\");

            line = readFile(path);

            Assert.AreEqual("", line);

            whs.Save(history, "WriteHistoryTest.json");

            line = readFile(path);

            Assert.AreEqual("{\"History\":[6,8],\"AlreadyRead\":[5,9],\"LastId\":9}", line);

            Reset(path);
        }

        private string readFile(string path)
        {
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadToEnd();
            }
            return line;
        }

        private void Reset(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write("");
            }
        }
    }
}
