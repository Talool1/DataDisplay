using DataDisplay;
using NUnit.Framework;
using System;

namespace DataDisplay.Tests
{
    [TestFixture]
    class NewCsvLineParserTest
    {
        [Test]
        public void ParseLine_ValidLineParse_Success()
        {
            NewCsvLineParser lineParser = new NewCsvLineParser(TestInitializationFactory.GenerateFakeColumnTypes());
            string lineToParse = "2018-01-03 12:00:00, 1,2,3,4,5";
            DataObject result = lineParser.ParseLine(lineToParse);
            Assert.AreEqual(result.Columns.Length, 6);
            Assert.AreEqual(result.Columns[0].GetType(), typeof(DateTime));
            for (int i = 1; i < 6; i++)
            {
                Assert.AreEqual(result.Columns[i].GetType(), typeof(int));
                Assert.AreEqual(result.Columns[i], i);
            }
        }

        [Test]
        public void ParseLine_InvalidIntFormat_Exception()
        {
            NewCsvLineParser lineParser = new NewCsvLineParser(TestInitializationFactory.GenerateFakeColumnTypes());
            string lineToParse = "2018-01-03 12:00:00, 1,2i,3,4,5";
            Assert.Catch(() => lineParser.ParseLine(lineToParse));
        }

        [Test]
        public void ParseLine_InvalidDateTimeFormat_Exception()
        {
            NewCsvLineParser lineParser = new NewCsvLineParser(TestInitializationFactory.GenerateFakeColumnTypes());
            string lineToParse = "2018ax01-03 12:00:00, 1,2,3,4,5";
            Assert.Catch(() => lineParser.ParseLine(lineToParse));
        }
    }
}
