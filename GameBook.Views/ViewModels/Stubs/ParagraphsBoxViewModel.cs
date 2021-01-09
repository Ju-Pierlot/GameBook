using System.Collections.ObjectModel;

namespace GameBook.Views.ViewModels.Stubs
{
    public class ParagraphsBoxViewModel : IParagraphsBoxViewModel
    {
        public ObservableCollection<string> ParagraphVisited => new ObservableCollection<string>()
        {
            "Paragraph 1 : This is a paragraph ...",
            "Paragraph 2 : This is an other paragraph ..."
        };

        public string ParagraphSelected
        {
            get => ParagraphVisited[0]; 
            set {}
        }
    }
}
