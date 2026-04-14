// Default Action setup
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Framework.Utils
{
    public class WaitHelper
    {
        private IWebDriver driver;
        private int timeout;

        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
            this.timeout = ConfigReader.GetInt("timeouts", "explicitWait");
        }

        public IWebElement Visible(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement Clickable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        // need to add Action class, 
    }
}
