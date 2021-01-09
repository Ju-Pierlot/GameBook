using System;
using System.Collections.Generic;
using System.Text;
using GameBook.Models.Answer;
using GameBook.Models.Book;
using GameBook.Models.Paragraph;
using NUnit.Framework;

namespace GameBook.Tests.Models
{
    class BookTests
    {
        private IBook createBook(string title, params IParagraph[] paragraphs)
        {
            IParagraph p1 = new Paragraph(0, "P1");
            IParagraph p2 = new Paragraph(1, "P2");
            IParagraph p3 = new Paragraph(2, "P3");
            IParagraph p4 = new Paragraph(3, "P4");
            IParagraph p5 = new Paragraph(4, "P5");

            p1.AddAnswers(
                new Answer("Answer 1", 1),
                new Answer("Answer 2", 3));

            p2.AddAnswers(
                new Answer("Answer 3", 2),
                new Answer("Answer 4", 4));

            p3.AddAnswers(
                new Answer("Answer 5", 0),
                new Answer("Answer 6", 1),
                new Answer("Answer 7", 3));

            IBook book = new Book(title);

            book.AddParagraphs(p1, p2, p3, p4, p5);
            if(paragraphs != null) book.AddParagraphs(paragraphs);

            return book;
        }

        [Test]
        public void PropertiesTest()
        {
            IParagraph paragraph = new Paragraph(7, "Label");
            IBook book = createBook("Book", paragraph);

            Assert.AreEqual("Book", book.Title);

            Assert.AreEqual(paragraph, book[7]);
        }
    }
}
