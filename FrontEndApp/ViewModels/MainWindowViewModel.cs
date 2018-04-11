using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataDisplay;
using FrontEndApp.Commands;

namespace FrontEndApp.ViewModels
{
    class MainWindowViewModel
    {
        internal IImporter Importer { get; private set; }
        internal DataObjectMetadata[] Metadatas { get; private set; }
        internal string[] ColumnNames
        {
            get
            {
                string[] columnNames = new string[Metadatas.Length];
                for (int i = 0; i < columnNames.Length; i++)
                {
                    columnNames[i] = Metadatas[i].ColumnName;
                }
                return columnNames;
            }
        }

        internal ICommand LaunchView { get; set; }
        public ICommand LaunchLoaderWindow { get; set; }

        public MainWindowViewModel()
        {
            LaunchLoaderWindow = new RelayCommand((o) => { return true; }, (o) => {
                LoaderViewModel lvm = new LoaderViewModel(this);
                lvm.LaunchViewCommand.Execute(this);
            });
        }

        private void LoadData()
        {
            
        }

        // For now....
        internal List<DataObject> TheData { get; private set; }        
    }
}
