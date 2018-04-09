using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DataDisplay
{
    internal class NewCsvLineParser
    {
        private char separatorChar = ',';
        private char[] whitespaceCharacters = new char[] { ' ' };
        private Type[] columnTypes;

        // CNVN: Should I use Func<string, object> or define my own delegate type?
        // CNVN: Also should I make it public and just let users assign to it
        private Dictionary<Type, Func<string, object>> typeToMethodParsingTable;

        #region Constructors
        public NewCsvLineParser(Type[] columnTypes) :
            this(columnTypes, ',', new char[] { ' ' })
        { }
        public NewCsvLineParser(Type[] columnTypes, char separatorChar, char[] whitespaceCharacters) :
            this(columnTypes, separatorChar, whitespaceCharacters, new Dictionary<Type, Func<string, object>>())
        {
            // Default parse types
            typeToMethodParsingTable.Add(typeof(int), ParseInt);
            typeToMethodParsingTable.Add(typeof(DateTime), ParseDataTime);
        }
        public NewCsvLineParser(Type[] columnTypes, char separatorChar, char[] whitespaceCharacters, Dictionary<Type, Func<string, object>> typeToMethodParsingTable)
        {
            this.separatorChar = separatorChar;
            this.whitespaceCharacters = whitespaceCharacters;
            this.columnTypes = columnTypes;
            this.typeToMethodParsingTable = typeToMethodParsingTable;
        }
        #endregion

        internal DataObject ParseLine(string line)
        {
            string[] tokens = line.Split(separatorChar);
            if (tokens.Length != columnTypes.Length)
            {
                // TODO: Throw an exception or skip line entirely depending on setting
                throw new ParsingException();
            }

            DataObject dataObject = new DataObject(tokens.Length);
            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];
                string currentToken = token.Trim(whitespaceCharacters);
                object data = ParseData(columnTypes[i], currentToken);
                dataObject.Columns[i] = data;
            }

            return dataObject;
        }

        private object ParseData(Type dataType, string dataString)
        {
            // CNVN: In a scenario like this should I call invoke explicitly or just ()
            object data = typeToMethodParsingTable[dataType].Invoke(dataString);

            // Do we even need this check? probably...
            if (data.GetType() != dataType)
            {
                // This one is interesting, what do we do here? can we 'correct' it at all?
                // Maybe skip line...
                throw new ParsingException();
            }
            return data;
        }

        private object ParseInt(string token)
        {
            if (int.TryParse(token, out int parsed))
            {
                return parsed;
            }
            throw new ParsingException();
        }

        private object ParseDataTime(string token)
        {
            token = token.Trim('\"');
            if (DateTime.TryParse(token, out DateTime parsed))
            {
                return parsed;
            }
            throw new ParsingException();
        }

    }
}