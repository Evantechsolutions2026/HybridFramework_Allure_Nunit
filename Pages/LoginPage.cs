
using OpenQA.Selenium;
using Framework.Utils;

namespace Framework.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private ActionHelper action;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            action = new ActionHelper(driver);
        }

        private By email = By.XPath("//*[@id=\"app\"]/div[1]/div/div[1]/div/div[2]/div[2]/form/div[1]/div/div[2]/input");
        private By password = By.XPath("//*[@id=\"app\"]/div[1]/div/div[1]/div/div[2]/div[2]/form/div[2]/div/div[2]/input");
        private By loginBtn = By.XPath("//*[@id=\"app\"]/div[1]/div/div[1]/div/div[2]/div[2]/form/div[3]/button");

        public void Login(string user, string pass)
        {
            try
            {

                action.Visible(email).SendKeys(user);
                action.Visible(password).SendKeys(pass);
                action.Clickable(loginBtn).Click();
            }
            catch (StaleElementReferenceException)
            {
                action.Visible(email).SendKeys(user);
            }
        }
    }
}
