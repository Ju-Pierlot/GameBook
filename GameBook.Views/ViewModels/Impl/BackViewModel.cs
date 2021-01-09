using System.Windows.Input;
using GameBook.Models.ReadingSession;
using GameBook.Views.ViewModels.Commands;

namespace GameBook.Views.ViewModels.Impl
{
    public class BackViewModel : ObservableViewModel, IBackViewModel
    {
        public BackViewModel(IReadingSession readingSession)
        {
            BackCommand = new BasicRelayCommand(() => readingSession.Back());
        }
        public ICommand BackCommand { get; }
    }
}
