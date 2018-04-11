using System;
using System.Collections.Generic;

namespace DataDisplay
{
    public interface IImporter
    {
        IEnumerable<DataObject> LoadAll();
        IEnumerable<DataObject> LoadRange(int count, out bool endOfFile, int skip = 0);
        string GetFileTypeExtentionString();
    }
}
