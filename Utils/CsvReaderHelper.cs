using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class CsvReaderHelper
{
    public static IEnumerable<TestCaseData> ReadCsv(string fileName)
    {
        string filePath;

        try
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);
        }
        catch (DirectoryNotFoundException)
        {
            throw new Exception("Test Data path to access the file does not exist");
        }

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {filePath}");

        var lines = File.ReadAllLines(filePath);

        if (lines.Length < 2)
            yield break;
        var headers = lines[0]
            .Split(',')
            .Select(h => h.Trim().ToLower())
            .ToArray();

        int totalRows = lines.Length - 1;
        int index = 1;

        foreach (var line in lines.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] data = line.Split(',');
            string[] values = new string[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                values[i] = data[i].Trim();
            }
            Dictionary<string, string> dict = new Dictionary<string, string>();

            for (int i = 0; i < headers.Length; i++)
            {
                dict[headers[i]] = i < values.Length ? values[i] : "";
            }
            TestCaseData testCaseData = new TestCaseData(dict);
            string methodName = "{m}";
            string columnValue = values.Length > 0 ? values[0] : "NoData";

            string testName = $"{methodName}--TestData{index} - {columnValue}";

            foreach (char ch in Path.GetInvalidFileNameChars())
            {
                testName = testName.Replace(ch.ToString(), "");
            }

            foreach (char ch in Path.GetInvalidPathChars())
            {
                testName = testName.Replace(ch.ToString(), "");
            }
            testCaseData.SetName(testName);
            yield return testCaseData;
            index++;
        }
    }
}