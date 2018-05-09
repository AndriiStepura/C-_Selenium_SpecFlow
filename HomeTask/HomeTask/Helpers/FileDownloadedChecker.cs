using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.Helpers
{
    using System.IO;

    class FileDownloadedChecker
    {

        public static bool Main(string filename)
        {
            string Path = EnvFoldersPaths.Main("FilesDownloadFolder");
            Task.Delay(10000).Wait(); // Wait 10 second // ToDo implement download full file download listener

            bool exist = false;
            //default user path string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString()) exist = true;
                    exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }
    }
}
