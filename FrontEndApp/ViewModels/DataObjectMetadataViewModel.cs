using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndApp
{
    class DataObjectMetadataViewModel : INotifyPropertyChanged
    {
        private DataObjectMetadata doMetadata;

        public DataObjectMetadataViewModel(DataObjectMetadata dataObjectMetadata)
        {
            this.doMetadata = dataObjectMetadata;
        }

        public DataObjectMetadata DataObjectMetadata
        {
            get
            {
                return doMetadata;
            }
            set
            {
                doMetadata = value;
            }
        }

        public string ColumnName
        {
            get
            {
                return doMetadata.ColumnName;
            }
            set
            {
                doMetadata.ColumnName = value;
                RaisePropertyChangedEvent(nameof(ColumnName));
            }
        }
        public Type ColumnDataType
        {
            get
            {
                return doMetadata.ColumnDataType;
            }
            set
            {
                doMetadata.ColumnDataType = value;
                RaisePropertyChangedEvent(nameof(ColumnDataType));
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
