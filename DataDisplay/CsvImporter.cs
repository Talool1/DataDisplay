using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataDisplay
{
    public class CsvImporter : IImporter
    {
        public string filePath { get; private set; }
        private CsvLineParser lineParser;
        private long streamPosition;
        
        public CsvImporter(string filePath, Type[] dataObjectColumnTypes, char separatorChar = ',')
        {
            char[] whiteSpaceChars = new char[] { ' ' };
            this.filePath = filePath;
            this.lineParser = new CsvLineParser(dataObjectColumnTypes, separatorChar, whiteSpaceChars);
        }

        public IEnumerable<DataObject> LoadAll()
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    List<DataObject> dataObjects = new List<DataObject>();
                    while (!streamReader.EndOfStream)
                    {
                        string currentLine = streamReader.ReadLine();
                        dataObjects.Add(ParseLine(currentLine));
                    }
                    return dataObjects;
                }
            }
        }

        public IEnumerable<DataObject> LoadRange(int count, out bool endOfFile, int skip = 0)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                // TODO: Optimize Multiple Allocations for GC
                List<DataObject> dataObjects = new List<DataObject>(count);

                // Skip N amount on lines
                for (int i = 0; i < skip; i++)
                {
                    streamReader.ReadLine();
                    if (streamReader.EndOfStream)
                    {
                        endOfFile = true;
                        return dataObjects;
                    }
                }

                // Read N amount of lines and parse into DataObjects
                for (int i = 0; i < count; i++)
                {
                    string currentLine = streamReader.ReadLine();
                    dataObjects.Add(ParseLine(currentLine));

                    if (streamReader.EndOfStream)
                    {
                        endOfFile = true;
                        return dataObjects;
                    }
                }

                streamPosition = streamReader.BaseStream.Position;
                endOfFile = false;
                return dataObjects;
            }
        }

        private DataObject ParseLine(string line)
        {
            var dataObject = lineParser.ParseLine(line);
            Console.WriteLine(dataObject);
            Console.WriteLine("-------------");
            return dataObject;
        }

        public string GetFileTypeExtentionString()
        {
            return "CSV Files | *.csv";
        }
    }
}
