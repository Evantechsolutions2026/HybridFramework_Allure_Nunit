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
        // need to add Action class, 

        // hover , right click , key board action  , normal click , JS click , scroll , move and drop , text, dropdown  , -> selection  , div  
        // iframe , swirch , alerrt  , popup  , window handlers 
        // exp . fluent ( if needed)
        
    }
}
