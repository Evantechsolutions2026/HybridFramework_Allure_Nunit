
// Provides test data from external CSV files for data-driven testing.
// Uses CsvReaderHelper to read and return data in NUnit TestCaseData format.
using System.Collections.Generic;
using NUnit.Framework;

namespace Framework.Utils
{
    public class TestDataProvider
    {
        public static IEnumerable<TestCaseData> GetData(string fileName)
        {
            return CsvReaderHelper.ReadCsv(fileName);
        }
    }
}