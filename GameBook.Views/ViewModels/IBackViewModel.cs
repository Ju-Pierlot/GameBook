using System.Windows.Input;

namespace GameBook.Views.ViewModels
{
    public interface IBackViewModel
    {
        ICommand BackCommand { get; }
    }
}
