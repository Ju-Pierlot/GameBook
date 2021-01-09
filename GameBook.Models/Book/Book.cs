using System.Collections.Generic;
using GameBook.Models.Paragraph;

namespace GameBook.Models.Book
{
    public class Book : IBook
    {
        private IList<IParagraph> _paragraphs;
        public Book(string title)
        {
            Title = title;
            _paragraphs = new List<IParagraph>();
        }
        public string Title { get; }


        public IParagraph this[int i]
        {
            get
            {
                foreach (var item in _paragraphs)
                {
                    if (item.Id == i) return item;
                }
                return new NullObjectParagraph();
            }
        }

        public void AddParagraph(IParagraph paragraph)
        {
            if(paragraph != null && !_paragraphs.Contains(paragraph))
                _paragraphs.Add(paragraph);
        }

        public void AddParagraphs(params IParagraph[] paragraphs)
        {
            if (paragraphs != null)
            {
                foreach (var paragraph in paragraphs)
                {
                    AddParagraph(paragraph);
                }
            }
        }
    }

}
