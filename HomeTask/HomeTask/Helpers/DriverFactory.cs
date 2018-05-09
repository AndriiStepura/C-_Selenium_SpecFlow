using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace HomeTask.Helpers
{
    public static class DriverFactory
    {
        // Decide path to save files            
        public static string pathToSaveFiles = EnvFoldersPaths.Main("FilesDownloadFolder");

        public static IWebDriver ReturnDriver(DriverType driverType)
        {
            IWebDriver driver;
            switch (driverType)
            {
                case DriverType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.default_directory", pathToSaveFiles);
                    //chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
                    //chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                    driver = new ChromeDriver(chromeOptions);
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
