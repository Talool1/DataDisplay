using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ICommand LoadFileCommand { get; set; }
        public LoaderViewModel()
        {
            //LoadFileCommand = loadCommand;
            LoadFileCommand = new Commands.LoadingFileCommand(this);
        }

        public Type[] AvailableFieldTypes { get; set; } = new Type[]
        { typeof(DateTime), typeof(int) };

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
