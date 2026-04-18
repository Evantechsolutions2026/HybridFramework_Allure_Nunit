using Framework.Utils;
using NUnit.Framework;
using System;
using System.Diagnostics;


// Global setup for cleaning and genrating the Report 
namespace Framework
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void BeforeAllTests()
        {
          
            AllureHelper.CopyHistoryToResults();
            // exe file 
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            AllureHelper.GenerateReport();
           // AllureHelper.CopyHistoryToReport();
        }
    }
}