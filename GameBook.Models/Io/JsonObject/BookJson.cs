using System.Collections.Generic;

namespace GameBook.Models.Io.JsonObject
{
    public class BookJson
    {
        public string Title { get; set; }
        public List<ParagraphJson> Paragraphs { get; set; }
    }
}
