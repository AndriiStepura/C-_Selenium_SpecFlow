using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask
{
    using System.Configuration;
    using OpenQA.Selenium;

    public class TakeScreenshot
    {
        // Add screenshot method
        public static void Main(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();

            // Decide path to save files
            // Create separated folder for save each hour screenshots
            string timeFolder = DateTime.Now.ToString("yyyy-MM-dd-HH");
            string path = ConfigurationSettings.AppSettings["ScreenshootsFolder"]+ @"\" +timeFolder + @"\";
                bool exists = System.IO.Directory.Exists(path);
                if (!exists) System.IO.Directory.CreateDirectory(path);

            screenshot.SaveAsFile(path + screenshotName + ".Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
        }
    }
}
