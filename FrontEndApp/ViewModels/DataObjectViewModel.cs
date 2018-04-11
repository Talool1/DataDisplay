using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDisplay;

namespace FrontEndApp.ViewModels
{
    class DataObjectViewModel : INotifyPropertyChanged
    {
        DataObject dataObject;
        
        public DataObjectViewModel(DataObject dataObject)
        {
            this.dataObject = dataObject;
        }

        public DataObject DataObject
        {
            get
            {
                return dataObject;
            }
            set
            {
                dataObject = value;
                RaisePropertyChangedEvent(nameof(DataObject));
            }
        }

        public object[] Columns
        {
            get
            {
                return dataObject.Columns;
            }
            set
            {
                dataObject.Columns = value;
                RaisePropertyChangedEvent(nameof(Columns));
            }
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
