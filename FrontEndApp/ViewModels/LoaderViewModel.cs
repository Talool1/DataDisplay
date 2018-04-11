using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FrontEndApp.Commands;
using Microsoft.Win32;

namespace FrontEndApp.ViewModels 
{
    class LoaderViewModel : INotifyPropertyChanged
    {
        private char _separatorChar = ',';
        public char SeparatorChar
        {
            get
            {
                return _separatorChar;
            }
            set
            {
                _separatorChar = value;
                RaisePropertyChangedEvent(nameof(SeparatorChar));
            }
        }

        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                RaisePropertyChangedEvent(nameof(FilePath));
            }
        }

        //public ObservableString ObservableFilePath;

        public MetadataDefinitionViewModel metadataDefinitionVM { get; set; }
        private LoaderWindow myView;

        public ICommand LaunchViewCommand { get; set; }
        public ICommand CloseViewCommand { get; set; }
        public ICommand LaunchFileBrowserCommand { get; set; }
        public ICommand LoadFileCommand { get; set; }

        public LoaderViewModel(MainWindowViewModel mainWindowViewModel)
        {
            LoadFileCommand = new LoadingFileCommand(this, mainWindowViewModel);
            LaunchViewCommand = new RelayCommand((o) => { return true; }, (o) => { LaunchView(); });
            metadataDefinitionVM = new MetadataDefinitionViewModel();
            LaunchFileBrowserCommand = new RelayCommand((o) => { return true; }, (o) => { OpenBrowseWindow(); });
            CloseViewCommand = new RelayCommand((o) => { return true; }, (o) => { CloseView(); });
        }

        private void OpenBrowseWindow()
        {
            OpenFileDialog openFileDialogue = new OpenFileDialog();
            //openFileDialogue.Title = openFileDialogueTitle;
            //openFileDialogue.Filter = fileType;
            openFileDialogue.FileOk += (s, args) => { FilePath = openFileDialogue.FileName; };
            openFileDialogue.CheckPathExists = true;
            openFileDialogue.ShowDialog();
        }

        private void LaunchView()
        {
            myView = new LoaderWindow(this);
            //myView.DataContext = this;
            myView.ShowDialog();
        }

        private void CloseView()
        {
            myView.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChangedEvent(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
