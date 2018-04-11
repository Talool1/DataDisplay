using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FrontEndApp.Commands
{
    class RelayCommand : ICommand
    {
        private Predicate<object> canExecute;
        private Action<object> executeAction;

        public RelayCommand(Predicate<object> canExecute, Action<object> executeAction)
        {
            this.canExecute = canExecute;
            this.executeAction = executeAction;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
    }
}
