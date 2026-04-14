
using OpenQA.Selenium;
using Framework.Utils;

namespace Framework.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private WaitHelper wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);
        }

        private By profileMenu = By.XPath("//div[@aria-label='Account']");
        private By logoutBtn = By.XPath("//span[text()='Log Out']");

        public void Logout()
        {
            wait.Clickable(profileMenu).Click();
            wait.Clickable(logoutBtn).Click();
        }
    }
}
