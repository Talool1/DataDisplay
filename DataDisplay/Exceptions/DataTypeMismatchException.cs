using System;
using System.Collections.Generic;
using System.Text;

namespace DataDisplay
{
    class DataTypeMismatchException : ParsingException
    {
        const string DefaultMessage = "The is a mismatch between the type of data";
        readonly Type expectedType;
        readonly Type actualType;

        public DataTypeMismatchException(Type expected, Type actual) : this(DefaultMessage, expected, actual) { }
        public DataTypeMismatchException(string message = DefaultMessage, Type expectedType = null, Type actualType = null) : base(message)
        {
            this.expectedType = expectedType;
            this.actualType = actualType;
        }
    }
}