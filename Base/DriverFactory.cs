using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace Framework.Driver
{
    public class DriverFactory
    {
        private static IWebDriver driver;

        public static void InitDriver()
        {
            string browser = ConfigReader.Get("browser").ToLower();
            bool isHeadless = ConfigReader.GetBool("headless");

            switch (browser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();

                    if (isHeadless)
                    {
                        chromeOptions.AddArgument("--headless=new"); // 🔥 latest mode
                        chromeOptions.AddArgument("--disable-gpu");
                        chromeOptions.AddArgument("--window-size=1920,1080");
                    }

                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();

                    if (isHeadless)
                    {
                        edgeOptions.AddArgument("--headless=new");
                        edgeOptions.AddArgument("--window-size=1920,1080");
                    }

                    driver = new EdgeDriver(edgeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();

                    if (isHeadless)
                    {
                        firefoxOptions.AddArgument("--headless");
                    }

                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                default:
                    throw new Exception("Invalid browser");
            }
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void QuitDriver()
        {
            driver?.Quit();
        }
    }
}