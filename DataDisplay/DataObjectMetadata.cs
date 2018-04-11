using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndApp
{
    public class DataObjectMetadata
    {
        public string ColumnName { get; set; }
        public Type ColumnDataType { get; set; }

        public DataObjectMetadata(string columnName, Type columnDataType)
        {
            this.ColumnName = columnName;
            this.ColumnDataType = columnDataType;
        }
    }
}
