using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndApp.ViewModels 
{
    class LoaderViewModel : INotifyPropertyChanged
    {
        private char _SeparatorChar = ',';
        public char SeparatorChar
        {
            get
            {
                return _SeparatorChar;
            }
            set
            {
                _SeparatorChar = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SeparatorChar)));
                }
            }
        }

        private string _FilePath;
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(FilePath)));
                }
            }
        }

        Type[] availableFieldTypes;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
