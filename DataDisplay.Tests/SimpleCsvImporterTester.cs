using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataDisplay;

namespace DataDisplay.Tests
{
    [TestClass]
    public class SimpleCsvImporterTester
    {
        string invalidTestPath = "TestFilePath";
        string sampleDataPath = @"C:\Users\Tal\Desktop\CSV_Project\DataDisplay\SampleData\us-500.csv";

        [TestMethod]
        public void TestConstructor()
        {
            SimpleCsvImporter simpleCsvImporter = new SimpleCsvImporter(invalidTestPath);
            Assert.IsTrue(simpleCsvImporter != null);
        }

        [TestMethod]
        public void NamedConstructorSavesName()
        {
            SimpleCsvImporter simpleCsvImporter = new SimpleCsvImporter(invalidTestPath);
            Assert.IsTrue(simpleCsvImporter.filePath ==  invalidTestPath);
        }

        [TestMethod]
        public void InvalidFileExceptionWorking()
        {
            Assert.ThrowsException<System.IO.FileNotFoundException>(() =>
           {
               SimpleCsvImporter simpleCsvImporter = new SimpleCsvImporter(invalidTestPath);
               simpleCsvImporter.Load();
           });
        }
        
    }
}
