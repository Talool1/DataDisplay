using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDisplay;

namespace SandboxApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //IImporter importer = new SimpleCsvImporter(@"C:\Users\Tal\Desktop\CSV_Project\DataDisplay\SampleData\us-500.csv");
            //importer.Load();

            string filename = @"new2.txt";
            string AppDir = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = AppDir + filename;
            NewCsvImporter newCsvImporter = new NewCsvImporter(relativePath, GenerateFakeColumnTypes());
            bool endOfFile;
            IEnumerable<DataObject> dataObjects = newCsvImporter.LoadRange(3, out endOfFile);
            IEnumerable<DataObject> dataObjects2 = newCsvImporter.LoadRange(3, out endOfFile);
        }

        // TEMP AF
        private static Type[] GenerateFakeColumnTypes()
        {
            // HardCoded for now
            Type [] columnTypes = new Type[] {
                typeof(DateTime),
                typeof(int),
                typeof(int),
                typeof(int),
                typeof(int),
                typeof(int),
            };

            return columnTypes;
        }
    }
}
