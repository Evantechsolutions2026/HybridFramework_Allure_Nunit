using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        public IWebElement Selectable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementExists(locator));
        }

        public IWebElement Hoverable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement Scrollable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement JsClickable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public IWebElement Draggable(By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void Hover(By locator)
        {
            new Actions(driver)
                .MoveToElement(Hoverable(locator))
                .Perform();
        }

        public void ScrollToElement(By locator)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", Scrollable(locator));
        }

        public void ScrollToBottom()
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public void ScrollToTop()
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("window.scrollTo(0, 0);");
        }

        public void JsClick(By locator)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", JsClickable(locator));
        }

        public void DragAndDrop(By source, By target)
        {
            new Actions(driver)
                .DragAndDrop(Draggable(source), Draggable(target))
                .Perform();
        }

        public void SelectByText(By locator, string text)
        {
            new SelectElement(Selectable(locator)).SelectByText(text);
        }

        public void SelectByValue(By locator, string value)
        {
            new SelectElement(Selectable(locator)).SelectByValue(value);
        }

        public void SelectByIndex(By locator, int index)
        {
            new SelectElement(Selectable(locator)).SelectByIndex(index);
        }

        public void DeselectByText(By locator, string text)
        {
            new SelectElement(Selectable(locator)).DeselectByText(text);
        }

        public void DeselectByValue(By locator, string value)
        {
            new SelectElement(Selectable(locator)).DeselectByValue(value);
        }

        public void DeselectByIndex(By locator, int index)
        {
            new SelectElement(Selectable(locator)).DeselectByIndex(index);
        }

        public void DeselectAll(By locator)
        {
            new SelectElement(Selectable(locator)).DeselectAll();
        }

        public void SwitchToFrame(By locator)
        {
            driver.SwitchTo().Frame(Visible(locator));
        }

        public void SwitchToFrame(int index)
        {
            driver.SwitchTo().Frame(index);
        }

        public void SwitchToFrame(string nameOrId)
        {
            driver.SwitchTo().Frame(nameOrId);
        }

        public void SwitchToParentFrame()
        {
            driver.SwitchTo().ParentFrame();
        }

        public void SwitchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}