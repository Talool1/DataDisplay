using System;
using System.Collections.Generic;
using System.Text;

namespace DataDisplay
{
    public class DataObject
    {
        public object[] Columns { get; private set; }

        public DataObject(int numColumns)
        {
            Columns = new object[numColumns];
        }

        // Quick method for debugging
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(30);
            foreach (var column in Columns)
            {
                stringBuilder.Append(column.GetType());
                stringBuilder.Append(": ");
                stringBuilder.Append(column.ToString());
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }
    }
}