// Default Action setup
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Framework.Utils
{
    public class ActionHelper
    {
        private IWebDriver driver;
        private int timeout;

        public ActionHelper(IWebDriver driver)
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
<<<<<<<< HEAD:Utils/WaitHelper.cs

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
========
        // need to add Action class, 

        // hover , right click , key board action  , normal click , JS click , scroll , move and drop , text, dropdown  , -> selection  , div  
        // iframe , swirch , alerrt  , popup  , window handlers 
        // exp . fluent ( if needed)
        
>>>>>>>> 9a9b922e99d778f138d9c6cd65cb314f6c4a5e67:Utils/ActionHelper.cs
    }
}
