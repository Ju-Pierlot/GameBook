using System;
using System.Collections.Generic;
using System.Text;
using GameBook.Models.History;
using NUnit.Framework;

namespace GameBook.Tests.Models
{
    class HistoryTests
    {
        [Test]
        public void PropertiesTest()
        {
            IHistory history = new History(
                new List<int>(){0, 1, 2, 1, 3}, 
                new List<int>(){0, 1, 2, 1}, 
                1);

            Assert.AreEqual(3, history.GetCurrentParagraphId);
            Assert.AreEqual(1, history.LastId);
            Assert.IsTrue(history.Contains(2));
            Assert.AreEqual(1, history.PrecedingId);
            Assert.AreEqual(1, history.IdNext(2));
        }
    }
}
