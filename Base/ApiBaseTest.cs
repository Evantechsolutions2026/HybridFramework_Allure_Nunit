
using Allure.NUnit;
using Framework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Framework.Base
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ApiBaseTest
    {
        [SetUp]
        public void Setup()
        {
            // No browser initialization
            Logger.Info("API Test Setup (No Browser)");
        }
        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Logger.Error("Test Failed: " + TestContext.CurrentContext.Test.Name);
            }
            else if(status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                Logger.Info("Test Passed: " + TestContext.CurrentContext.Test.Name);
            }
            else
            {
                Logger.Info("Test Broken: " + TestContext.CurrentContext.Test.Name);
            }

        }
    }
}
