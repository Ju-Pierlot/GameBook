using System;
using System.Collections.Generic;
using System.Text;
using GameBook.Models.Answer;
using GameBook.Models.Book;
using GameBook.Models.History;
using GameBook.Models.Paragraph;
using GameBook.Models.ReadingSession;
using GameBook.Views.ViewModels;
using GameBook.Views.ViewModels.Impl;
using NUnit.Framework;

namespace GameBook.Tests.ViewModels
{
    class MessageViewModelTests
    {
        //Test d’acceptation US6 #1
        [Test]
        public void TestUS6_1()
        {
            IReadingSession rs = CreateReadingSession();
            IMessageViewModel mvm = new MessageViewModel(rs);

            rs.Next("A1");
            rs.Next("A2");

            Assert.AreEqual("Vous quittez le paragraphe 2 pour aller au paragraphe 3.", mvm.Message);
        }
        //Test d’acceptation US6 #2
        [Test]
        public void TestUS6_2()
        {
            IReadingSession rs = CreateReadingSession();
            IMessageViewModel mvm = new MessageViewModel(rs);

            rs.Next("A1");
            rs.Next("A2");
            rs.Back();

            Assert.AreEqual("Vous avez déjà lu le paragraphe 2. Vous êtes ensuite aller au paragraphe 3.", mvm.Message);
        }
        //Test d’acceptation US6 #3
        [Test]
        public void TestUS6_3()
        {
            IReadingSession rs = CreateReadingSession();
            IMessageViewModel mvm = new MessageViewModel(rs);

            rs.Next("A1");
            rs.Next("A3");

            Assert.AreEqual("Vous quittez le paragraphe 2 pour aller au paragraphe 4. Vous avez atteint la fin du livre.", mvm.Message);
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
