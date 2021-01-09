using System.Collections.Generic;
using GameBook.Models.Answer;
using GameBook.Models.Book;
using GameBook.Models.History;
using GameBook.Models.Paragraph;
using GameBook.Models.ReadingSession;
using GameBook.Views.ViewModels;
using GameBook.Views.ViewModels.Impl;
using Moq;
using NUnit.Framework;

namespace GameBook.Tests.ViewModels
{
    class ParagraphsBoxViewModelTests
    {
        private void SameContent(IList<string> a, IList<string> b)
        {
            for (int i = 0; i < b.Count; i++)
            {
                Assert.AreEqual(a[i], b[i]);
            }
        }
        //Test d’acceptation US7 #1
        [Test]
        public void TestUS7_1()
        {
            IReadingSession rs = CreateReadingSession();
            IParagraphsBoxViewModel pbvm = new ParagraphsBoxViewModel(rs);
            IList<string> listpara = new List<string>()
            {
                pbvm.ParagraphSelected,
                "Paragraphe 1 : Lorem ipsum dolor sit amet, consect...",
                "Paragraphe 2 : Lorem ipsum dolor sit amet, consect..."
            };

            rs.Next("A1");

            SameContent(listpara, pbvm.ParagraphVisited);
        }
        //Test d’acceptation US7 #2
        [Test]
        public void TestUS7_2()
        {
            IReadingSession rs = CreateReadingSession();
            IParagraphsBoxViewModel pbvm = new ParagraphsBoxViewModel(rs);
            IList<string> listpara = new List<string>()
            {
                pbvm.ParagraphSelected,
                "Paragraphe 1 : Lorem ipsum dolor sit amet, consect...",
                "Paragraphe 2 : Lorem ipsum dolor sit amet, consect...",
                "Paragraphe 3 : Lorem ipsum dolor sit amet, consect..."
            };

            rs.Next("A1");
            rs.Next("A2");

            SameContent(listpara, pbvm.ParagraphVisited);
        }
        //Test d’acceptation US7 #3
        [Test]
        public void TestUS7_3()
        {
            IReadingSession rs = CreateReadingSession();
            IParagraphsBoxViewModel pbvm = new ParagraphsBoxViewModel(rs);
            IList<string> listpara = new List<string>()
            {
                pbvm.ParagraphSelected,
                "Paragraphe 1 : Lorem ipsum dolor sit amet, consect...",
                "Paragraphe 2 : Lorem ipsum dolor sit amet, consect...",
                "Paragraphe 3 : Lorem ipsum dolor sit amet, consect..."
            };

            rs.Next("A1");
            rs.Next("A2");
            rs.Back();

            SameContent(listpara, pbvm.ParagraphVisited);
        }
        //Test d’acceptation US7 #4
        [Test]
        public void TestUS7_4()
        {
            IReadingSession rs = CreateReadingSession();
            IParagraphsBoxViewModel pbvm = new ParagraphsBoxViewModel(rs);
            IList<string> listpara = new List<string>()
            {
                pbvm.ParagraphSelected,
                "Paragraphe 1 : Lorem ipsum dolor sit amet, consect..."
            };

            rs.Next("A1");
            rs.Next("A2");
            rs.Back();
            rs.GoTo(0);

            SameContent(listpara, pbvm.ParagraphVisited);
        }
        //Test d’acceptation US7 #5
        [Test]
        public void TestUS7_5()
        {
            IReadingSession rs = CreateReadingSession();
            IParagraphsBoxViewModel pbvm = new ParagraphsBoxViewModel(rs);
            IList<string> listpara = new List<string>()
            {
                pbvm.ParagraphSelected,
                "Paragraphe 1 : Lorem ipsum dolor sit amet, consect...",
                "Paragraphe 2 : Lorem ipsum dolor sit amet, consect...",
                "Paragraphe 3 : Lorem ipsum dolor sit amet, consect..."
            };

            rs.Next("A1");
            rs.Next("A2");
            rs.Back();
            rs.Next("A2");

            SameContent(listpara, pbvm.ParagraphVisited);
        }
        private IReadingSession CreateReadingSession()
        {
            IParagraph p1 = new Paragraph(0, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam");
            p1.AddAnswer(new Answer("A1", 1));
            IParagraph p2 = new Paragraph(1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam");
            p2.AddAnswer(new Answer("A2", 2));
            p2.AddAnswer(new Answer("A3", 3));
            IParagraph p3 = new Paragraph(2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam");
            p3.AddAnswer(new Answer("A4", 1));
            IParagraph p4 = new Paragraph(3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam");

            IBook book = new Book("Title");
            book.AddParagraphs(p1, p2, p3, p4);
            return new ReadingSession(book, new History());
        }
    }
}
