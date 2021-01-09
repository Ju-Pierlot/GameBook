namespace GameBook.Models.Answer
{
    public class Answer : IAnswer
    {
        public Answer(string label, int id)
        {
            Label = label;
            Id = id;
        }

        public int Id { get; }

        public string Label { get; }

        public override bool Equals(object? obj)
        {
            return this.Label.Equals(((IAnswer)obj).Label);
        }

        public int LabelIsOk(string label)
            => (label.Equals(Label)) ? Id : -1;
    }
}
