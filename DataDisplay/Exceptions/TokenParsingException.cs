using System;
using System.Collections.Generic;
using System.Text;

namespace DataDisplay
{
    class TokenParsingException:ParsingException
    {
        const string DefaultMessage = "The data parser could not parse a token.";
        const string DefaultDetailedMessage = "The data parser could not parse the token '{0}' into the expected type '{1}'.";
        public readonly string actualTokenContent;
        public readonly Type expectedTokenType;

        public TokenParsingException() : this(DefaultMessage) { }
        public TokenParsingException(string errorMessage) : base(errorMessage) { }
        public TokenParsingException(string actualTokenContent, Type expectedTokenType) :
            this(FormatDetailedErrorMessage(actualTokenContent, expectedTokenType))
        {
            this.actualTokenContent = actualTokenContent;
            this.expectedTokenType = expectedTokenType;
        }
        static string FormatDetailedErrorMessage(string actualTokenContent, Type expectedTokenType)
        {
            return string.Format(DefaultDetailedMessage, actualTokenContent, expectedTokenType);
        }
    }
}
