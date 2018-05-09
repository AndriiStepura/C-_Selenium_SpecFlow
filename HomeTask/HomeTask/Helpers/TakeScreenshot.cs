using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;

namespace HomeTask
{
    using Helpers;


    public class TakeScreenshot
    {
        // Decide path to save files            
        public static string pathToSaveScreenshots = EnvFoldersPaths.Main("FilesDownloadFolder");

        // Add screenshot method
        public static void Main(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();

            screenshot.SaveAsFile(pathToSaveScreenshots + screenshotName + ".Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
        }
    }
}
