using System.Collections.ObjectModel;

namespace GameBook.Views.ViewModels
{
    public interface IParagraphsBoxViewModel
    {
        ObservableCollection<string> ParagraphVisited { get; }
        string ParagraphSelected { get; set; }
    }
}
