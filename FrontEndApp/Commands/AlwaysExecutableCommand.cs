using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FrontEndApp.Commands
{
    class AlwaysExecutableCommand : ICommand
    {
        Action action;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AlwaysExecutableCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action actionCopy = action;
            if(actionCopy != null)
            {
                actionCopy();
            }
        }
    }
}
