using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndApp.ViewModels
{
    class ObservableString : INotifyPropertyChanged
    {
        private string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                RaisePropertyChangedEvent(nameof(Content));
            }
        }

        public ObservableString(string content)
        {
            this.content = content;
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