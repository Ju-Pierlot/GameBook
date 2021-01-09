using System.Collections.ObjectModel;
using System.Windows.Input;
using GameBook.Views.ViewModels.Commands;

namespace GameBook.Views.ViewModels.Stubs
{
    public class ParagraphAnswersViewModel : IParagraphAnswersViewModel
    {
        public ObservableCollection<IAnswerViewModel> Answers => new ObservableCollection<IAnswerViewModel>()
        {
            new AnswerViewModel() {Label = "Answer number 1"},
            new AnswerViewModel() {Label = "Answer number 2"},
            new AnswerViewModel() {Label = "Answer number 3"}
        };
    }

    public class AnswerViewModel : IAnswerViewModel
    {
        public string Label { get; set; }

        public ICommand Select => new NullCommand();
    }
}
