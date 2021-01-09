namespace GameBook.Models.Answer
{
    public interface IAnswer
    {
        int Id { get; }
        string Label { get; }
        int LabelIsOk(string label);
    }
}
