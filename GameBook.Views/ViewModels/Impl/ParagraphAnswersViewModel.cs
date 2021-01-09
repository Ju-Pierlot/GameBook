using System.Collections.ObjectModel;
using System.Windows.Input;
using GameBook.Models.ReadingSession;
using GameBook.Views.ViewModels.Commands;

namespace GameBook.Views.ViewModels.Impl
{
    public class ParagraphAnswersViewModel : ObservableViewModel, IParagraphAnswersViewModel
    {
        private IReadingSession _readingSession;

        public ParagraphAnswersViewModel(IReadingSession readingSession)
        {
            _readingSession = readingSession;
            _readingSession.CurrentParagraphChanged += (o, e) => Update();
            Answers = new ObservableCollection<IAnswerViewModel>();
            Update();
        }
        public ObservableCollection<IAnswerViewModel> Answers { get; }

        private void Update()
        {
            Answers.Clear();
            foreach (var answer in _readingSession.Answers) Answers.Add(AnswerViewModel.Create(_readingSession, answer));
            if(Answers.Count == 0) Answers.Add(ResetViewModel.Create(_readingSession, "Recommencer le livre."));
            RaisePropertyChanged(nameof(Answers));
        }
    }

    public class AnswerViewModel : IAnswerViewModel
    {
        internal static AnswerViewModel Create(IReadingSession readingSession, string answer) 
            => new AnswerViewModel(readingSession, answer);

        public AnswerViewModel(IReadingSession readingSession, string answer)
        {
            Label = answer;
            Select = new BasicRelayCommand(() => readingSession.Next(answer));
        }

        public string Label { get; }

        public ICommand Select { get; }
    }
    public class ResetViewModel : IAnswerViewModel
    {
        internal static ResetViewModel Create(IReadingSession readingSession, string answer)
            => new ResetViewModel(readingSession, answer);

        public ResetViewModel(IReadingSession readingSession, string answer)
        {
            Label = answer;
            Select = new BasicRelayCommand(() => readingSession.Reset());
        }

        public string Label { get; }

        public ICommand Select { get; }
    }
}
