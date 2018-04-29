using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace HomeTask.Helpers
{
    public static class DriverFactory
    {
        public static IWebDriver ReturnDriver(DriverType driverType)
        {
            IWebDriver driver;
            switch (driverType)
            {
                case DriverType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case DriverType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case DriverType.Edge:
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(driverType), driverType, null);
            }

            return driver;
        }

        public enum DriverType
        {
            Chrome,
            Firefox,
            Edge
        }
    }
}
