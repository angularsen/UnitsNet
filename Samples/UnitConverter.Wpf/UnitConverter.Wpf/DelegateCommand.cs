using System;
using System.Windows.Input;

namespace Wpf_GenericUnitConverter
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _commandDelegate;

        public DelegateCommand(Action commandDelegate)
        {
            _commandDelegate = commandDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _commandDelegate.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}