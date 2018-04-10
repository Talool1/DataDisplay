using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDisplay;

namespace FrontEndApp.ViewModels
{
    class MainWindowViewModel
    {
        public IImporter Importer { get; private set; }
        public DataObjectMetadata[] Metadatas { get; private set; }
        public string[] ColumnNames
        {
            get
            {
                string[] columnNames = new string[Metadatas.Length];
                for (int i = 0; i < columnNames.Length; i++)
                {
                    columnNames[i] = Metadatas[i].columnName;
                }
                return columnNames;
            }
        }

        // For now....
        public List<DataObject> TheData { get; private set; }

        public MainWindowViewModel(DataObjectMetadata[] dataObjectMetadata, IImporter importer)
        {
            this.Importer = importer;
            this.TheData = importer.LoadAll() as List<DataObject>;
            this.Metadatas = dataObjectMetadata;
        }
    }
}
