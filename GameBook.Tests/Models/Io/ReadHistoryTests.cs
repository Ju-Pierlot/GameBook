using System;
using System.Collections.Generic;
using System.Text;
using GameBook.Models.History;
using GameBook.Models.Io;
using NUnit.Framework;

namespace GameBook.Tests.Models.Io
{
    class ReadHistoryTests
    {
        [Test]
        public void ReadHistoryTest()
        {
            IReadHistoryService hs = new ReadHistory(@"..\..\..\Saves\HistoriesTest\");
            IHistory history = hs.Read("HistoryTest.json");

            Assert.AreEqual(1, history.LastId);
            Assert.AreEqual(2, history.HistoryList.Count);
        }
    }
}
