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

        // For hover (element should be visible)
        public IWebElement Hoverable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // For scroll (element should be visible)
        public IWebElement Scrollable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // For JS click (element should exist in DOM)
        public IWebElement JsClickable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementExists(locator));
        }

        // For drag & drop (element visible)
        public IWebElement Draggable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // For dropdown
        public IWebElement Selectable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // For iframe
        public IWebDriver SwitchToFrame(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(locator));
        }
    }
}
