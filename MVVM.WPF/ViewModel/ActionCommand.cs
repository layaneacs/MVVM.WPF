using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MVVM.WPF.ViewModel
{
    public class ActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }


        public ActionCommand(Action<object> execute) : this(execute, null)
        {

        }

        public ActionCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute", "You must specify an Action<T>");
            }
            _execute = execute;
            _canExecute = canExecute;
        }
    }
}
