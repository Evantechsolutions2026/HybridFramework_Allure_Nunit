using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Framework.Utils
{
    // CSV Reader for Testdata (STILL WORKING)
    public class CsvReaderHelper
    {
        public static IEnumerable<TestCaseData> ReadCsv(string fileName)
        {
            string filePath = null;
            try
            {
                 filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);

            }
            catch (DirectoryNotFoundException)
            {
                throw new Exception("Test Data path to access the file does not exist");
            }

                       var lines = File.ReadAllLines(filePath);
            if(lines.Length <2) yield break;

            var headers = lines[0].Split(',')
                                  .Select(h => h.Trim().ToLower())
                                  .ToArray();
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',')
                                 .Select(v => v.Trim())
                                 .ToArray();
                string methodName = "{m}";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                for (int i = 0; i < headers.Length; i++)
                {
                    dict[headers[i]] = values[i];
                   
                }
                List<string> parts = new List<string>();
                foreach (var key in dict.Keys)
                {
                    parts.Add(key + "=" + dict[key]);
                }

                string name = string.Join(", ", parts);

                string testName = Path.GetFileNameWithoutExtension(fileName);
                TestCaseData testCaseData = new TestCaseData(dict);
                //string testName = $"{methodName}";
                testCaseData.SetName(testName);
                yield return testCaseData;
            }
        }
      
       
}
}