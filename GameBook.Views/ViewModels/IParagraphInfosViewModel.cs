namespace GameBook.Views.ViewModels
{
    public interface IParagraphInfosViewModel
    {
        string BookTitle { get; }
        string Number { get; }
        string Label { get; }
        string ColorStart { get; }
        string ColorEnd { get; }
        string PrecedingColorStart { get; }
        string PrecedingColorEnd { get; }
    }
}
