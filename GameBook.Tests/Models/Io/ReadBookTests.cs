using System;
using System.Collections.Generic;
using System.Text;
using GameBook.Models.Book;
using GameBook.Models.Io;
using NUnit.Framework;

namespace GameBook.Tests.Models.Io
{
    class ReadBookTests
    {
        [Test]
        public void ReadTest()
        {
            IReadBookService rb = new ReadBook();
            IBook book = rb.Read(@"..\..\..\Saves\BooksTest\BookTest.json");

            Assert.AreEqual("P1", book[0].Label);
            Assert.AreEqual("P2", book[1].Label);
            Assert.AreEqual("P3", book[2].Label);
            Assert.AreEqual("P4", book[3].Label);
        }
    }
}
