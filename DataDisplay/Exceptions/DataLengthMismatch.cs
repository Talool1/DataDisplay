using System;
using System.Collections.Generic;
using System.Text;

namespace DataDisplay
{
    class DataLengthMismatch : ParsingException
    {
        const string DefaultMessage = "The number of columns defined in the software doesn't match the number data in the file.";
        public readonly int expectedNumberOfData;
        public readonly int actualNumberOfData;

        public DataLengthMismatch() : base(DefaultMessage) { }
        public DataLengthMismatch(int expectedNumberOfData, int actualNumberOfData):this()
        {
            this.expectedNumberOfData = expectedNumberOfData;
            this.actualNumberOfData = actualNumberOfData;
        }
    }
}
