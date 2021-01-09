namespace GameBook.Views.ViewModels.Stubs
{
    public class ParagraphInfosViewModel : IParagraphInfosViewModel
    {
        public string BookTitle => "Book Title";

        public string Number => "Paragraph 1";

        public string Label => "This is a paragraph content. You must be very careful while reading it in order to make the right choice.";

        public string ColorStart => "#56ab2f";

        public string ColorEnd => "#a8e063";

        public string PrecedingColorStart => "#fff";

        public string PrecedingColorEnd => "#fff";
    }
}