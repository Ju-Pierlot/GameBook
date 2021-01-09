using System;
using System.Collections.Generic;
using System.Text;
using GameBook.Models.Answer;
using GameBook.Models.Book;
using GameBook.Models.History;
using GameBook.Models.Paragraph;
using GameBook.Models.ReadingSession;
using NUnit.Framework;

namespace GameBook.Tests.Models
{
    class ReadingSessionTests
    {
        [Test]
        public void PropertiesTest()
        {
            IReadingSession rs = CreateReadingSession();

            Assert.AreEqual(0, rs.Id);
            Assert.IsFalse(rs.AlreadyRead);
            Assert.AreEqual(1, rs.Answers.Count);
            Assert.AreEqual("P1", rs.Paragraph);
            Assert.IsFalse(rs.IsFinish);
            Assert.AreEqual("Title", rs.Title);
            Assert.AreEqual("#fff", rs.ColorStart);
            Assert.AreEqual("#fff", rs.ColorEnd);
        }

        [Test]
        public void NextTest()
        {
            IReadingSession rs = CreateReadingSession();

            Assert.AreEqual("P1", rs.Paragraph);

            rs.Next("A1");

            Assert.AreEqual("P2", rs.Paragraph);

            rs.Next("Not in answers");

            Assert.AreEqual("P2", rs.Paragraph);
        }

        [Test]
        public void GoToTest()
        {
            IReadingSession rs = CreateReadingSession();
            rs.Next("A1");
            rs.Next("A2");

            rs.GoTo(1);

            Assert.AreEqual("P2", rs.Paragraph);
        }

        [Test]
        public void ResetTest()
        {
            IReadingSession rs = CreateReadingSession();
            rs.Next("A1");
            rs.Next("A2");

            rs.Reset();

            Assert.AreEqual("P1", rs.Paragraph);
        }

        [Test]
        public void BackTest()
        {
            IReadingSession rs = CreateReadingSession();
            rs.Next("A1");
            rs.Next("A2");

            rs.Back();

            Assert.AreEqual("P2", rs.Paragraph);
        }

        [Test]
        public void NewBookTest()
        {
            IReadingSession rs = CreateReadingSession();
            Assert.AreEqual("Title", rs.Title);

            rs.SetNewBook(new Book("Another"), new History());

            Assert.AreEqual("Another", rs.Title);
        }
        private IReadingSession CreateReadingSession()
        {
            IParagraph p1 = new Paragraph(0, "P1");
            p1.AddAnswer(new Answer("A1", 1));
            IParagraph p2 = new Paragraph(1, "P2");
            p2.AddAnswer(new Answer("A2", 2));
            p2.AddAnswer(new Answer("A3", 3));
            IParagraph p3 = new Paragraph(2, "P3");
            p3.AddAnswer(new Answer("A4", 1));
            IParagraph p4 = new Paragraph(3, "P4");

            IBook book = new Book("Title");
            book.AddParagraphs(p1, p2, p3, p4);
            return new ReadingSession(book, new History());
        }
    }
}
