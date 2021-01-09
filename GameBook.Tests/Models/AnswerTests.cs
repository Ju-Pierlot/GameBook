using System;
using System.Collections.Generic;
using System.Text;
using GameBook.Models.Answer;
using NUnit.Framework;

namespace GameBook.Tests.Models
{
    class AnswerTests
    {
        [Test]
        public void PropertiesTest()
        {
            IAnswer answer = new Answer("Answer 1", 0);

            Assert.AreEqual("Answer 1", answer.Label);
            Assert.AreEqual(0, answer.Id);
        }

        [Test]
        public void EqualTest()
        {
            IAnswer answer1 = new Answer("Answer 1", 0);
            IAnswer answer2 = new Answer("Answer 1", 2);
            IAnswer answer3 = new Answer("Answer 2", 3);

            Assert.IsTrue(answer1.Equals(answer2));
            Assert.IsFalse(answer1.Equals(answer3));
        }
    }
}
