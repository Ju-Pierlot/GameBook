using System;
using System.Collections.Generic;
using System.Text;
using GameBook.Models.Paragraph;
using NUnit.Framework;

namespace GameBook.Tests.Models
{
    class NullObjectParagraphTests
    {
        [Test]
        public void PropertiesTest()
        {
            IParagraph p = new NullObjectParagraph();

            Assert.AreEqual("Error", p.Label);
            Assert.AreEqual(-1, p.Id);
            Assert.AreEqual("#ffffff", p.ColorStart);
            Assert.AreEqual("#ffffff", p.ColorEnd);
            Assert.AreEqual(-1, p.NextParagraphId("Lipsum"));
            Assert.IsTrue(p.IsTerminal);
        }
    }
}
