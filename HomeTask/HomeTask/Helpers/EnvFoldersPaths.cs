using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;


namespace HomeTask.Helpers
{
    class EnvFoldersPaths
    {
        public static string Main(string folderType)
        {
            // Decide path to save files
            string path;
            if (ConfigurationSettings.AppSettings["useTimestampAsScreenshotsFolder"] == "true")
            {
                // If your testRun# not changed you may use timeStamp folder belove
                string timeFolder = DateTime.Now.ToString("yyyy-MM-dd");// Create separated folder for save each day screenshots
                path = ConfigurationSettings.AppSettings[folderType] + @"\" + timeFolder + @"\";
                CreateFolderIfNotExists(path);
            }
            else
            {
                path = ConfigurationSettings.AppSettings[folderType] + @"\" + ConfigurationSettings.AppSettings["testRun#"] + @"\";
                CreateFolderIfNotExists(path);
            }

            return path;
        }

        public static void CreateFolderIfNotExists(string path)
        {
            bool exists = System.IO.Directory.Exists(path);
            if (!exists) System.IO.Directory.CreateDirectory(path);
        }
        
}
}
