using System;
using System.Collections.Generic;
using System.Text;

namespace DataDisplay
{
    class ParsingException : Exception
    {
        const string DefaultExceptionMessage = "A Parsing exception has occured";
        public int lineNumber { get; internal set; }

        public ParsingException() : this(DefaultExceptionMessage) { }
        public ParsingException(string message) : base(message) { }
    }
}
