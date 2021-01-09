using GameBook.Models.Book;
using System;
using System.IO;
using GameBook.Models.Io.JsonObject;
using GameBook.Models.Paragraph;
using Newtonsoft.Json;

namespace GameBook.Models.Io
{
    public class ReadBook : IReadBookService
    {
        public IBook Read(string path)
        {
            try
            {
                using (var reader = new StreamReader(path))
                {
                    string lines = reader.ReadToEnd();
                    BookJson book = JsonConvert.DeserializeObject<BookJson>(lines);
                    return ConvertJsonBook(book);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        private IBook ConvertJsonBook(BookJson bookJson)
        {
            IBook book = new Book.Book(bookJson.Title);
            foreach (var item in bookJson.Paragraphs)
            {
                IParagraph paragraph = new Paragraph.Paragraph(item.Id, item.Label, item.ColorStart, item.ColorEnd);
                foreach (var answer in item.Answers)
                {
                    paragraph.AddAnswer(new Answer.Answer(answer.Label, answer.Id));
                }
                book.AddParagraph(paragraph);
            }
            return book;
        }
    }
}
