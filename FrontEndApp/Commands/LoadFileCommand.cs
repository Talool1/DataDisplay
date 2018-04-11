using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FrontEndApp.ViewModels;

namespace FrontEndApp.Commands
{
    class LoadingFileCommand : ICommand
    {
        LoaderViewModel viewModel;
        MainWindowViewModel mwvm;

        public LoadingFileCommand(LoaderViewModel viewModel, MainWindowViewModel mwvm)
        {
            this.viewModel = viewModel;
            this.mwvm = mwvm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private bool ValidateFilepath(string filePath)
        {
            string path = viewModel.FilePath;
            return System.IO.File.Exists(path);
        }

        public bool CanExecute(object parameter)
        {
            return ValidateFilepath(parameter as string);
        }

        public void Execute(object parameter)
        {
            viewModel.CloseViewCommand.Execute(this);
        }
    }
}