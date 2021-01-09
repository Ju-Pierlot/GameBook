using GameBook.Models.Answer;
using System;
using System.Collections.Generic;

namespace GameBook.Models.Paragraph
{
    public class Paragraph : IParagraph, IComparable
    {
        private ISet<IAnswer> _answers;

        public Paragraph(int id, string label) : this(id, label, "#fff", "#fff")
        {
        }
        public Paragraph(int id, string label, string colorStart, string colorEnd)
        {
            Id = id;
            Label = label;
            _answers = new HashSet<IAnswer>();
            ColorStart = colorStart;
            ColorEnd = colorEnd;
        }
        public string Label { get; }

        public int Id { get; }

        public IList<string> Answers
        {
            get
            {
                IList<string> answers = new List<string>();
                foreach (var ans in _answers)
                {
                    answers.Add(ans.Label);
                }
                return answers;
            }
        }

        public bool IsTerminal => _answers.Count == 0;

        public string ColorStart { get; }

        public string ColorEnd { get; }

        public int NextParagraphId(string answer)
        {
            foreach (var ans in _answers)
            {
                if (ans.LabelIsOk(answer) != -1) return ans.Id;
            }
            return -1;
        }

        public int CompareTo(object? obj)
        {
            if (obj != null) return Id - ((IParagraph)obj).Id;
            return 0;
        }
        public override string ToString()
            => (Label.Length > 35) ? $"Paragraphe {Id + 1} : {Label.Substring(0, 35)}..." :
                $"Paragraphe {Id + 1} : {Label}";
            
        

        public void AddAnswer(IAnswer answer)
        {
            if (answer != null)
            {
                _answers.Add(answer);
            }
        }

        public void AddAnswers(params IAnswer[] answers)
        {
            if (answers != null) foreach (var item in answers) AddAnswer(item);
        }
    }
}
