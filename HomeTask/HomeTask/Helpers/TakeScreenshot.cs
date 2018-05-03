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
            string path;
            if (ConfigurationSettings.AppSettings["useTimestampAsScreenshotsFolder"] == "true")
            {
                // If your testRun# not changed you may use timeStamp folder belove
                string timeFolder = DateTime.Now.ToString("yyyy-MM-dd-HH");// Create separated folder for save each hour screenshots
                path = ConfigurationSettings.AppSettings["ScreenshootsFolder"] + @"\" + timeFolder + @"\";
            }
            else
            {
                path = ConfigurationSettings.AppSettings["ScreenshootsFolder"] + @"\" + ConfigurationSettings.AppSettings["testRun#"] + @"\";
            }
            

                bool exists = System.IO.Directory.Exists(path);
                if (!exists) System.IO.Directory.CreateDirectory(path);

            screenshot.SaveAsFile(path + screenshotName + ".Jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
        }
    }
}
