using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDisplay;

namespace FrontEndApp.ViewModels
{
    class DisplayViewModel
    {
        public IImporter importer { get; private set; }
        public DataObjectMetadata[] dataObjectMetadata { get; private set; }
        // For now....
        public List<DataObject> TheData { get; private set; }

        public DisplayViewModel(DataObjectMetadata[] dataObjectMetadata, IImporter importer)
        {
            this.importer = importer;
            this.TheData = importer.LoadAll() as List<DataObject>;
            this.dataObjectMetadata = dataObjectMetadata;
        }
    }
}
