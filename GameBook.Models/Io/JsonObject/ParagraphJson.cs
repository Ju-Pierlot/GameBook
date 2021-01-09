using System.Collections.Generic;

namespace GameBook.Models.Io.JsonObject
{
    public class ParagraphJson
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public List<AnswerJson> Answers { get; set; }
        public string ColorStart { get; set; }
        public string ColorEnd { get; set; }
    }
}
