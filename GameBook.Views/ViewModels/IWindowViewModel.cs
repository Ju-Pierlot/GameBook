using System.Windows.Input;

namespace GameBook.Views.ViewModels
{
    public interface IWindowViewModel
    {
        ICommand Exit { get; }
        ICommand LoadFile { get; }
    }
}
