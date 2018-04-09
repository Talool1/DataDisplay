using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndApp
{
    class DataObjectMetadata
    {      
        public string columnName { get; private set; }
        public Type columnDataType{get;private set;}

        public DataObjectMetadata(string columnName, Type columnDataType)
        {
            this.columnName = columnName;
            this.columnDataType = columnDataType;
        }
    }
}
