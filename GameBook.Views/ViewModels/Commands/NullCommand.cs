using System;
using System.Windows.Input;

namespace GameBook.Views.ViewModels.Commands
{
    public class NullCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) { }
    }
}
