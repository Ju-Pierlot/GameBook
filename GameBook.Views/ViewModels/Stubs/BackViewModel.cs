using System.Windows.Input;
using GameBook.Views.ViewModels.Commands;

namespace GameBook.Views.ViewModels.Stubs
{
    public class BackViewModel : IBackViewModel
    {
        public ICommand BackCommand => new NullCommand();
    }
}
