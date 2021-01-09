using System;
using System.Collections.Generic;
using System.Text;
using GameBook.Models.Answer;
using GameBook.Models.Paragraph;
using NUnit.Framework;

namespace GameBook.Tests.Models
{
    class ParagraphTests
    {
        [Test]
        public void PropertiesTest()
        {
            IParagraph paragraph = new Paragraph(0, "Paragraph", "#ffffff", "#3876a7");

            Assert.AreEqual(0, paragraph.Id);
            Assert.AreEqual("Paragraph", paragraph.Label);
            Assert.AreEqual("#ffffff", paragraph.ColorStart);
            Assert.AreEqual("#3876a7", paragraph.ColorEnd);
        }

        [Test]
        public void AnswersTest()
        {
            IParagraph paragraph = new Paragraph(0, "Paragraph");
            
            paragraph.AddAnswers(
                new Answer("Answer 1", 1),
                new Answer("Answer 2", 2),
                new Answer("Answer 3", 3));

            IList<string> answers = new List<string>()
            {
                "Answer 1",
                "Answer 2",
                "Answer 3"
            };
            int i = 0;
            foreach (var answer in paragraph.Answers)
            {
                Assert.AreEqual(answer, answers[i]);
                i++;
            }
        }

        [Test]
        public void IsTerminalTest()
        {
            IParagraph paragraph = new Paragraph(0, "Paragraph");

            Assert.IsTrue(paragraph.IsTerminal);

            paragraph.AddAnswers(
                new Answer("Answer 1", 1),
                new Answer("Answer 2", 2),
                new Answer("Answer 3", 3));

            Assert.IsFalse(paragraph.IsTerminal);
        }

        [Test]
        public void NextParagraphId()
        {
            IParagraph paragraph = new Paragraph(1, "Paragraph");
            paragraph.AddAnswers(
                new Answer("Answer 1", 1),
                new Answer("Answer 2", 2),
                new Answer("Answer 3", 3));

            Assert.AreEqual(-1, paragraph.NextParagraphId("A Answer"));

            Assert.AreEqual(2, paragraph.NextParagraphId("Answer 2"));
        }

        [Test]
        public void ToStringTest()
        {
            IParagraph paragraph = new Paragraph(1, "Paragraph is a cool paragraph.");

            Assert.AreEqual("Paragraphe 2 : Paragraph is a cool paragraph.", paragraph.ToString());
        }
    }
}
