using System;
using System.Collections.Generic;
using System.Text;

namespace DataDisplay
{
    class DataLengthMismatch : ParsingException
    {
        const string DefaultMessage = "The number of columns defined in the software doesn't match the number data in the file.";
        const string DefaultDetailedMessage = "The number of columns defined in the software ({0}) doesn't match the number data in the file({1}).";
        public readonly int expectedNumberOfData;
        public readonly int actualNumberOfData;

        public DataLengthMismatch() : this(DefaultMessage) { }
        public DataLengthMismatch(string message) : base(message) { }
        public DataLengthMismatch(int expectedNumberOfData, int actualNumberOfData) :
            this(FormatDetailedErrorMessage(expectedNumberOfData, actualNumberOfData))
        {
            this.expectedNumberOfData = expectedNumberOfData;
            this.actualNumberOfData = actualNumberOfData;
        }

        // Formatting
        private static string FormatDetailedErrorMessage(int expectedNumData,int actualNumData)
        {
            return string.Format(DefaultDetailedMessage, expectedNumData, actualNumData);
        }
    }
}
