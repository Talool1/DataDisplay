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
        LoaderViewModel loaderViewModel;
        MainWindowViewModel mwvm;

        public LoadingFileCommand(LoaderViewModel viewModel, MainWindowViewModel mwvm)
        {
            this.loaderViewModel = viewModel;
            this.mwvm = mwvm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private bool ValidateFilepath(string filePath)
        {
            string path = loaderViewModel.FilePath;
            return System.IO.File.Exists(path);
        }

        public bool CanExecute(object parameter)
        {
            bool isValidPath = ValidateFilepath(parameter as string);
            bool isValidSeparator = ValidateSeparator();
            return isValidPath && isValidSeparator;
        }

        private bool ValidateSeparator()
        {
            string separator = loaderViewModel.SeparatorChar;
            if (separator != null && separator.Length == 1)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            //mwvm.Metadatas = loaderViewModel.metadataDefinitionVM.MetadataCollection.ToArray();
            loaderViewModel.CloseViewCommand.Execute(this);
            mwvm.LoadData(loaderViewModel);
        }
    }
}