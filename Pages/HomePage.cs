
using OpenQA.Selenium;
using Framework.Utils;

namespace Framework.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private ActionHelper action;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            action = new ActionHelper(driver);
        }

        private By profileMenu = By.XPath("//div[@aria-label='Account']");
        private By logoutBtn = By.XPath("//span[text()='Log Out']");

        public void Logout()
        {
            action.Clickable(profileMenu).Click();
            action.Clickable(logoutBtn).Click();
        }
    }
}
