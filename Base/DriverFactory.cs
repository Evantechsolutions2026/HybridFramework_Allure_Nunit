
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
        // headless mode -> need to add 
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver() => driver.Value;

        // Browser initialization
        public static void InitDriver()
        {
            string browser = ConfigReader.Get("browser").ToLower();

            switch (browser)
            {
                case "chrome":
                    driver.Value = new ChromeDriver();
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
        // Env  initialization default QA
        public static string EnvSetupUrl()
        {
            string env = ConfigReader.Get("environment").ToLower();

            switch (env.ToLower())
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
        //Quit Method
        public static void QuitDriver()
        {
            driver.Value?.Quit();
        }
        
    }
}
