using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataDisplay;

namespace DataDisplay.Tests
{
    [TestClass]
    public class SimpleCsvImporterTester
    {
        string mockTestPath = "TestFilePath";

        [TestMethod]
        public void TestConstructor()
        {
            SimpleCsvImporter simpleCsvImporter = new SimpleCsvImporter("TestFilePath");
            Assert.IsTrue(simpleCsvImporter != null);
        }

        [TestMethod]
        public void NamedConstructorSavesName()
        {
            SimpleCsvImporter simpleCsvImporter = new SimpleCsvImporter(mockTestPath);
            Assert.IsTrue(simpleCsvImporter.filePath ==  mockTestPath);
        }
        
    }
}
