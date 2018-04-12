using FrontEndApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FrontEndApp.ViewModels
{
    class MetadataDefinitionViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<DataObjectMetadataViewModel> MetadataCollection { get; set; }

        private Type[] availableDataTypes;
        public Type[] AvailableFieldTypes { get; set; } = new Type[]
        {
             typeof(DateTime),
             typeof(int),
        };

        public MetadataDefinitionViewModel(): this(null)
        {
            add = new RelayCommand((o) =>
            {
                if (FieldName != null && FieldName.Trim() != string.Empty)
                {
                    return true;
                }
                return false;
            },
            (o) =>
            {
                DataObjectMetadata meta = FromCurrentToMetadata();
                DataObjectMetadataViewModel metaVm = new DataObjectMetadataViewModel(meta);
                MetadataCollection.Add(metaVm);
            });

            remove = new RelayCommand((o) =>
            {
                if(o == null)
                {
                    return false;
                }
                int i = (int)o;
                return (i >= 0) && (i < MetadataCollection.Count);
            },
            (o) =>
            {
                int i = (int)o;
                MetadataCollection.RemoveAt(i);
            });
        }
        public MetadataDefinitionViewModel(Type[] availableDataTypes)
        {
            this.availableDataTypes = availableDataTypes;
            MetadataCollection = new ObservableCollection<DataObjectMetadataViewModel>();
        }

        private string fieldName;
        public string FieldName
        {
            get
            {
                return fieldName;
            }
            set
            {
                fieldName = value;
                RaisePropertyChangedEvent(nameof(FieldName));
            }
        }

        private Type fieldType;
        public Type FieldType
        {
            get
            {
                return fieldType;
            }
            set
            {
                fieldType = value;
                RaisePropertyChangedEvent(nameof(FieldType));
            }
        }

        private DataObjectMetadata FromCurrentToMetadata()
        {
            return new DataObjectMetadata(FieldName, FieldType);
        }

        private ICommand add;
        public ICommand Add { get { return add; } }

        private ICommand remove;
        public ICommand Remove { get { return remove; } }

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
