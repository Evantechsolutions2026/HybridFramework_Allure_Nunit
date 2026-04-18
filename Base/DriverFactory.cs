using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Threading;

namespace Framework.Base
{
    public static class DriverFactory
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver() => driver.Value;

        public static void InitDriver()
        {
            string browser = ConfigReader.Get("browser").ToLower();
            bool headless = ConfigReader.GetBool("headless");

            switch (browser)
            {
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();

                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddArgument("--disable-notifications");
                    chromeOptions.AddArgument("--disable-popup-blocking");

                    if (headless)
                    {
                        chromeOptions.AddArgument("--headless=new");
                        chromeOptions.AddArgument("--window-size=1920,1080");
                        chromeOptions.AddArgument("--disable-gpu");
                        chromeOptions.AddArgument("--no-sandbox");
                        chromeOptions.AddArgument("--disable-dev-shm-usage");
                    }

                    driver.Value = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    driver.Value = new FirefoxDriver();
                    break;

                case "edge":
                    driver.Value = new EdgeDriver();
                    break;

                case "safari":
                    driver.Value = new SafariDriver();
                    break;

                default:
                    driver.Value = new ChromeDriver();
                    break;
            }
        }

        public static string EnvSetupUrl()
        {
            string env = ConfigReader.Get("environment").ToLower();

            switch (env)
            {
                case "qa":
                    return ConfigReader.Get("baseUrl") + ConfigReader.Get("port");

                case "dev":
                    return ConfigReader.Get("baseUrl") + ConfigReader.Get("port");

                case "uat":
                    return ConfigReader.Get("baseUrl") + ConfigReader.Get("port");

                default:
                    Logger.Info("Default Running in QA Environment");
                    return ConfigReader.Get("baseUrl") + ConfigReader.Get("port");
            }
        }

        public static void QuitDriver()
        {
            driver.Value?.Quit();
            driver.Value = null;
        }
    }
}