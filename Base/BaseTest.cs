
using Allure.NUnit;
using Framework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Framework.Driver;

namespace Framework.Base
{
    [AllureNUnit]
    [Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        protected IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            //  browser initialization
            DriverFactory.InitDriver();
            driver = DriverFactory.GetDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConfigReader.Get("baseUrl"));
            Logger.Info("Launched browser and navigated to base URL");
        }
        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ScreenshotHelper.AttachScreenshot(driver, TestContext.CurrentContext.Test.Name);
                Logger.Error("Test Failed: " + TestContext.CurrentContext.Test.Name);
            }
            else if(status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                ScreenshotHelper.AttachScreenshot(driver, TestContext.CurrentContext.Test.Name);
                Logger.Info("Test Passed: " + TestContext.CurrentContext.Test.Name);
            }
            else
            {
                ScreenshotHelper.AttachScreenshot(driver, TestContext.CurrentContext.Test.Name);
                Logger.Info("Test Broken: " + TestContext.CurrentContext.Test.Name);
            }

            DriverFactory.QuitDriver();
        }
    }
}
