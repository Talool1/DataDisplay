using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataDisplay
{
    public class SimpleCsvImporter : IFileImporter
    {
        public string filePath { get; private set; }

        public SimpleCsvImporter(string filePath)
        {
            this.filePath = filePath;
        }

        public void Load()
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {


                }
            }
            catch(FileNotFoundException ex)
            {
                throw;
            }

        }
    }
}
