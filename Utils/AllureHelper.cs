using System.IO;
using System.Diagnostics;

namespace Framework.Utils
{
    public static class AllureHelper
    {
        private static string resultsPath = "allure-results";
        private static string reportPath = "allure-report";

        public static void CopyHistoryToResults()
        {
          
            string historyInReport = Path.Combine(reportPath, "history");
            string historyBackup = Path.Combine(resultsPath, "history");

            if (Directory.Exists(resultsPath))
            {
                foreach (var file in Directory.GetFiles(resultsPath, "*-result.json"))
                    File.Delete(file);

                foreach (var file in Directory.GetFiles(resultsPath, "*-container.json"))
                    File.Delete(file);

                foreach (var file in Directory.GetFiles(resultsPath, "*.attach*"))
                    File.Delete(file);
            }
            else
            {
                Directory.CreateDirectory(resultsPath);
            }


            if (Directory.Exists(historyInReport))
            {
                if (Directory.Exists(historyBackup))
                    Directory.Delete(historyBackup, true);

                CopyDirectory(historyInReport, historyBackup);
            }
        }

       
        //public static void CopyHistoryToReport()
        //{
        //    string source = Path.Combine(resultsPath, "history");
        //    string destination = Path.Combine(reportPath, "history");

        //    if (Directory.Exists(source))
        //    {
        //        if (Directory.Exists(destination))
        //            Directory.Delete(destination, true);

        //        CopyDirectory(source, destination);
        //    }
        //}

        
        public static void GenerateReport()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c allure generate allure-results --clean -o allure-report",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi)?.WaitForExit();
        }

        private static void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            foreach (var file in Directory.GetFiles(sourceDir))
                File.Copy(file, Path.Combine(destDir, Path.GetFileName(file)), true);

            foreach (var dir in Directory.GetDirectories(sourceDir))
                CopyDirectory(dir, Path.Combine(destDir, Path.GetFileName(dir)));
        }
    }
}