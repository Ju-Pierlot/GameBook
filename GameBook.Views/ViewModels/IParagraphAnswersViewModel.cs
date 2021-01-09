using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GameBook.Views.ViewModels
{
    public interface IParagraphAnswersViewModel
    {
        ObservableCollection<IAnswerViewModel> Answers { get; }
    }
    public interface IAnswerViewModel
    {
        string Label { get; }
        ICommand Select { get; }
    }
}
