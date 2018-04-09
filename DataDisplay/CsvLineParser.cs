using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataDisplay
{
    internal class CsvLineParser
    {
        private char quotationOpenSymbol = '\"';
        private char quotationCloseSymbol = '\"';
        private char separatorChar = ',';
        private char[] whitespaceCharacters = new char[] { ' ' };
        private bool areQuotationOpenCloseEqual;
        private bool isQuotationOpen = false;
        private bool hasPassedComma = false;
        List<string> words = new List<string>();
        StringBuilder currentWord = new StringBuilder();

        public CsvLineParser()
        {
            areQuotationOpenCloseEqual = (quotationOpenSymbol == quotationCloseSymbol);
        }

        public IEnumerable<object> ParseLine(string line)
        {
            // As there is no comma before the opening quotations
            // we will treat it there was
            hasPassedComma = true;

            // Go through each character and figure out if it is a quatation, a separator or normal data
            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                // Two different parsing paths depending on our location(state) in the parsing(inside quotation or outside)
                if (isQuotationOpen)
                    ParseInsideQuotation(currentChar);
                else
                    ParseCharOutsideQuotation(currentChar);
            }

            // If we are here and still open quotation there was an error in the file: no 'closing brackets' at the end of the line
            // For now throw an exception
            // TODO: Maybe in the future it might be a good idea to close at the end anyways
            if (isQuotationOpen)
                throw new ParsingException();

            // If we're here  it means that there was a comma after the last closing quation marks
            // TODO: We probably want to make this one warning only
            if (hasPassedComma)
                throw new ParsingException();

            return null;
        }

        private void ParseInsideQuotation(char currentChar)
        {
            if (!areQuotationOpenCloseEqual && currentChar == quotationOpenSymbol)
            {
                throw new ParsingException();
            }

            if (currentChar == quotationCloseSymbol)
                CloseQuotationSection();            // Close the word and return
            else
                currentWord.Append(currentChar);    // Else Append char to word
        }

        private void CloseQuotationSection()
        {
            isQuotationOpen = false;
            hasPassedComma = false;
            words.Add(currentWord.ToString());
            Console.WriteLine(words);
            currentWord.Clear();
        }

        private void ParseCharOutsideQuotation(char currentChar)
        {
            if (!areQuotationOpenCloseEqual)
                if (currentChar == quotationCloseSymbol)
                    throw new ParsingException();

            if (currentChar == quotationOpenSymbol)
            {
                // We have two quotation sections not separated by a comma
                // For now we assume it's illegal and throw
                // TODO: we might wanna separate the two in the future
                if (!hasPassedComma)
                    throw new ParsingException();
                
                OpenQuotationSection();
                return;
            }

            if (currentChar == separatorChar)
            {
                // If we're here it means that the file is malformatted and has two(or more)
                // Separators in a 'dead' area <Eg: "Tal",,"Saada">
                if (hasPassedComma)
                    throw new ParsingException();

                // Note that we passed a comma separator and return
                hasPassedComma = true;
                return;
            }

            // For now we will assume that the file is formated well so that
            // The only legal character outside of quotation is a comma character or a quotation open symbol
            // TODO: Add a char[] of valid 'whitespace' characters(eg: 'Space' or 'NewLine')
            if (EqualsAnyOf(currentChar, whitespaceCharacters))
                return;

            throw new ParsingException();
        }

        void OpenQuotationSection()
        {
            // Open Quotation
            isQuotationOpen = true;
            hasPassedComma = false;
            // TODO: We can optimize out this one and rely on the current word being cleared when
            // closeing a Quotation Section.
            currentWord.Clear();    
        }

        bool EqualsAnyOf(char c, char[] charsArray)
        {
            for (int i = 0; i < charsArray.Length; i++)
                if (c == charsArray[i])
                    return true;

            return false;
        }

    }
}
