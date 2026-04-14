using OpenQA.Selenium;
using Allure.Net.Commons;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Utils
{
    // Screenshot utility class using Allure to attach screenshots
    public static class ScreenshotHelper
    {
        public static void AttachScreenshot(IWebDriver driver, string name)
        {
            try
            {
                // Wait
                new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                    .Until(d => ((IJavaScriptExecutor)d)
                    .ExecuteScript("return document.readyState").Equals("complete"));
                //Small delay for UI rendering
                System.Threading.Thread.Sleep(500);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                AllureApi.AddAttachment(name, "image/png", screenshot.AsByteArray, ".png");
            }
            catch (Exception e)
            {
                Console.WriteLine("Screenshot failed: " + e.Message);
            }
        }
    }
}