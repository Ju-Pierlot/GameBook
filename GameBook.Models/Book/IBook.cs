using GameBook.Models.Paragraph;

namespace GameBook.Models.Book
{
    public interface IBook
    {
        string Title { get; }
        IParagraph this[int i] { get; }
        void AddParagraph(IParagraph paragraph);
        void AddParagraphs(params IParagraph[] paragraphs);
    }
}
