using System;
using System.Windows.Input;

namespace GameBook.Views.ViewModels.Commands
{
    public class BasicRelayCommand : ICommand
    {
        private Action _action;

        public BasicRelayCommand(Action action)
        {
            if (action == null) throw new ArgumentNullException("action cannot be null");
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _action();
    }
}
