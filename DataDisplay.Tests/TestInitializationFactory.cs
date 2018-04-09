using System;

namespace DataDisplay.Tests
{
    class TestInitializationFactory
    {
        public static Type[] GenerateFakeColumnTypes()
        {
            // HardCoded for now
            Type[] columnTypes = new Type[] {
                typeof(DateTime),
                typeof(int),
                typeof(int),
                typeof(int),
                typeof(int),
                typeof(int),
            };

            return columnTypes;
        }
    }
}
