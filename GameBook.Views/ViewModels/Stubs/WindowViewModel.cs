using System.Windows.Input;
using GameBook.Views.ViewModels.Commands;

namespace GameBook.Views.ViewModels.Stubs
{
    public class WindowViewModel : IWindowViewModel
    {
        public ICommand Exit => new NullCommand();

        public ICommand LoadFile => new NullCommand();
    }
}
