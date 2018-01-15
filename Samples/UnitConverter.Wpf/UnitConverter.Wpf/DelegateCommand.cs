using System;
using System.Windows.Input;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    /// <summary>
    ///     Simple <see cref="ICommand" /> implementation, that executes a callback upon executing the command, such as
    ///     when clicking a button.
    /// </summary>
    public sealed class DelegateCommand : ICommand
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