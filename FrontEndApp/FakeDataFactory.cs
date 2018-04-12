using DataDisplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndApp
{
    public class FakeDataFactory
    {
        internal static DataObjectMetadataViewModel[] TEMP_GenerateMeta()
        {
            string filePath = @"C:\Users\Tal\Desktop\CSV_Project\DataDisplay\FrontEndApp\new2.csv";

            var meta = new DataObjectMetadataViewModel[6];
            Type[] dataTypes = new Type[]
            {
                typeof(DateTime),
                typeof(int),
                typeof(int),
                typeof(int),
                typeof(int),
                typeof(int),
            };

            string[] dataNames = new string[]
            {
                "The Time!",
                "The Num1!",
                "The Num2!",
                "The Num3!",
                "The Num4!",
                "The Num5!",
            };

            for (int i = 0; i < meta.Length; i++)
            {
                meta[i] = new DataObjectMetadataViewModel(new DataObjectMetadata(dataNames[i], dataTypes[i]));
            }

            return meta;
        }
    }
}
