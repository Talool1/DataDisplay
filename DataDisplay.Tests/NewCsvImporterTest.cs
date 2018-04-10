using System;
using System.Collections.Generic;
using NUnit;
using NUnit.Framework;

namespace DataDisplay.Tests
{
    [TestFixture]
    public class NewCsvImporterTest
    {
        public string fileName = @"new2.txt";
        private string relativePath;

        public NewCsvImporterTest()
        {
            relativePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        [Test]
        public void LoadAll_SimpleFileLoad_Success()
        {
            CsvImporter importer = new CsvImporter(relativePath, TestInitializationFactory.GenerateFakeColumnTypes());
            var result = importer.LoadAll();
            int numItems = EnumerateTestAndCount(result);

            // Test that All items have been read
            Assert.AreEqual(numItems, 7);
        }

        [Test]
        public void LoadNext_LoadFirst3Lines_Success()
        {
            CsvImporter importer = new CsvImporter(relativePath, TestInitializationFactory.GenerateFakeColumnTypes());
            bool endOfFile;
            var result = importer.LoadRange(3, out endOfFile);
            int numItems = EnumerateTestAndCount(result);

            // Test that 3 items have been read
            Assert.AreEqual(numItems, 3);
            Assert.AreEqual(endOfFile, false);
        }

        [Test]
        public void LoadNext_LoadAllLinesWithCount_Success()
        {
            CsvImporter importer = new CsvImporter(relativePath, TestInitializationFactory.GenerateFakeColumnTypes());
            bool endOfFile;
            var result = importer.LoadRange(7, out endOfFile);
            int numItems = EnumerateTestAndCount(result);

            // Test that All items have been read
            Assert.AreEqual(numItems, 7);
            Assert.AreEqual(endOfFile, true);
        }

        [Test]
        public void LoadNext_LoadLast3Lines_Success()
        {
            CsvImporter importer = new CsvImporter(relativePath, TestInitializationFactory.GenerateFakeColumnTypes());
            bool endOfFile;
            var result = importer.LoadRange(3, out endOfFile, 4);
            int numItems = EnumerateTestAndCount(result);

            // Test that All items have been read
            Assert.AreEqual(numItems, 3);
            Assert.AreEqual(endOfFile, true);
        }

        private int EnumerateTestAndCount(IEnumerable<DataObject> enumerable)
        {
            int numItems = 0;
            foreach (var dataObject in enumerable)
            {
                Assert.AreEqual(dataObject.Columns.Length, 6);
                Assert.AreEqual(dataObject.Columns[0].GetType(), typeof(DateTime));
                int i = 0;
                foreach (var Col in dataObject.Columns)
                {
                    if (i != 0)
                    {
                        Assert.AreEqual(Col.GetType(), typeof(int));
                        Assert.AreEqual(Col, i);
                    }
                    i++;
                }
                numItems++;
            }

            return numItems;
        }
    }
}