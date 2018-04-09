using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataDisplay
{
    public class SimpleCsvImporter
    {
        public string filePath { get; private set; }
        char commaSeparator = ',';
        

        public SimpleCsvImporter(string filePath)
        {
            this.filePath = filePath;
        }

        public void Load()
        {
            CsvLineParser lineParser = new CsvLineParser();
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    string allLines = ReadAllLines(fileStream);
                    string[] lines = allLines.Split('\r');
                    foreach (var line in lines)
                        lineParser.ParseLine(line);
                }
            }
            catch(FileNotFoundException ex)
            {
                throw;
            }
            
        }



        string ReadAllLines(FileStream stream)
        {
            using (StreamReader streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
