using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataDisplay;
using FrontEndApp.Commands;

namespace FrontEndApp.ViewModels
{
    class MainWindowViewModel: INotifyPropertyChanged
    {
        internal IImporter Importer { get; private set; }
        internal DataObjectMetadataViewModel[] Metadatas { get; set; }
        public string[] ColumnNames
        {
            get
            {
                if(Metadatas == null)
                {
                    return null;
                }
                string[] columnNames = new string[Metadatas.Length];
                for (int i = 0; i < columnNames.Length; i++)
                {
                    columnNames[i] = Metadatas[i].ColumnName;
                }
                return columnNames;
            }
        }
        public IEnumerable<DataObject> AllData
        {
            get
            {
                if (Importer != null)
                    return Importer.LoadAll();
                return null;
            }
        }
        
        public ICommand LaunchLoaderWindow { get; set; }
        public ICommand CloseWindow { get; set; }
        public Action<DataObjectMetadataViewModel[]> ViewGenerateColumns { get; internal set; }

        public MainWindowViewModel()
        {
            LaunchLoaderWindow = new RelayCommand((o) => { return true; }, (o) => {
                LoaderViewModel lvm = new LoaderViewModel(this);
                LoadingFileCommand loadingFileCommand = new LoadingFileCommand(lvm, this);
                lvm.LoadFileCommand = loadingFileCommand;
                lvm.LaunchViewCommand.Execute(this);
            });

            Metadatas = FakeDataFactory.TEMP_GenerateMeta();
            RaisePropertyChangedEvent(nameof(ColumnNames));
        }

        public void LoadData(LoaderViewModel lvm)
        {
            List<Type> dataTypes = new List<Type>();
            List<string> columnNames = new List<string>();
            foreach (var meta in lvm.metadataDefinitionVM.MetadataCollection)
            {
                dataTypes.Add(meta.ColumnDataType);
                columnNames.Add(meta.ColumnName);
            }
            Metadatas = lvm.metadataDefinitionVM.MetadataCollection.ToArray();
            Importer = new CsvImporter(lvm.FilePath, dataTypes.ToArray(), lvm.SeparatorChar[0]);

            if (ViewGenerateColumns != null)
                ViewGenerateColumns(Metadatas);

            // Trying smt 'creative' here...
            RaisePropertyChangedEvent(nameof(ColumnNames));
            RaisePropertyChangedEvent(nameof(AllData));
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
