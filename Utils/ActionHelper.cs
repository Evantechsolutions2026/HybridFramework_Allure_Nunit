using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Framework.Utils
{
    public class ActionHelper
    {
        private IWebDriver driver;
        private WaitHelper wait;

        public ActionHelper(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WaitHelper(driver);
        }

        // HOVER
      
        public void Hover(By locator)
        {
            new Actions(driver)
                .MoveToElement(wait.Hoverable(locator))
                .Perform();
        }

        // SCROLL
        public void ScrollToElement(By locator)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", wait.Scrollable(locator));
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

        // JS CLICK

        public void JsClick(By locator)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", wait.JsClickable(locator));
        }

        // DRAG AND DROP
        public void DragAndDrop(By source, By target)
        {
            new Actions(driver)
                .DragAndDrop(wait.Draggable(source), wait.Draggable(target))
                .Perform();
        }

        // DROPDOWN - SELECT
        public void SelectByText(By locator, string text)
        {
            new SelectElement(wait.Selectable(locator)).SelectByText(text);
        }

        public void SelectByValue(By locator, string value)
        {
            new SelectElement(wait.Selectable(locator)).SelectByValue(value);
        }

        public void SelectByIndex(By locator, int index)
        {
            new SelectElement(wait.Selectable(locator)).SelectByIndex(index);
        }

        // DROPDOWN - DESELECT (for multi-select)
        public void DeselectByText(By locator, string text)
        {
            new SelectElement(wait.Selectable(locator)).DeselectByText(text);
        }

        public void DeselectByValue(By locator, string value)
        {
            new SelectElement(wait.Selectable(locator)).DeselectByValue(value);
        }

        public void DeselectByIndex(By locator, int index)
        {
            new SelectElement(wait.Selectable(locator)).DeselectByIndex(index);
        }

        public void DeselectAll(By locator)
        {
            new SelectElement(wait.Selectable(locator)).DeselectAll();
        }

        // IFRAME HANDLING

        // Switch using locator (already using WaitHelper)
        public void SwitchToFrame(By locator)
        {
            wait.SwitchToFrame(locator);
        }

        // Switch using index
        public void SwitchToFrame(int index)
        {
            driver.SwitchTo().Frame(index);
        }

        // Switch using name or ID
        public void SwitchToFrame(string nameOrId)
        {
            driver.SwitchTo().Frame(nameOrId);
        }

        // Switch back to parent frame
        public void SwitchToParentFrame()
        {
            driver.SwitchTo().ParentFrame();
        }

        // Switch back to main page
        public void SwitchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}