using GameBook.Models.Answer;
using System;
using System.Collections.Generic;

namespace GameBook.Models.Paragraph
{
    public class NullObjectParagraph : IParagraph
    {
        public string Label => "Error";
        public int Id => -1;

        public IList<string> Answers => new List<string>();

        public bool IsTerminal => true;

        public string ColorStart => "#ffffff";

        public string ColorEnd => "#ffffff";


        public void AddAnswers(params IAnswer[] answers)
        {
        }

        public int NextParagraphId(string answer) => -1;

        void IParagraph.AddAnswer(IAnswer answer)
        {
        }
    }
}
