using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace EMP.main.emp.service.persistence
{
    /**
     * This class manages the IniCreator to manage and retrieve info from the IniCreator.
     */
    public static class Configs
    {
        private static IniCreator configsFile;

        private static string eladariaFolder = Path.DirectorySeparatorChar + "Eladaria Studios" + Path.DirectorySeparatorChar + "EMP";

        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        static Configs()
        {
            appendPaths();
            Directory.CreateDirectory(eladariaFolder);
        }

        private static void appendPaths()
        {
            eladariaFolder = path + eladariaFolder;
            configsFile = new IniCreator(eladariaFolder + Path.DirectorySeparatorChar + "configs.ini");
        }

        public static string getVolume()
        {
            return configsFile.Read("Volume", "Settings");
        }

        public static void setVolume(string volume)
        {
            configsFile.Write("Volume", volume, "Settings");
        }

        public static List<string> getPaths()
        {
            var paths = new List<string>();
            var i = 1;
            while (configsFile.KeyExists("Path" + i, "Paths"))
            {
                paths.Add(configsFile.Read("Path" + i, "Paths"));
                i++;
            }

            return paths;
        }
        
        public static void setPaths(string path)
        {
            var i = 1;
            while (configsFile.KeyExists("Path" + i, "Paths")) i++;

            var pathcount = "Path" + i;

            configsFile.Write(pathcount, path, "Paths");
        }
        
        public static void clearPath(string pathToKill) //TODO: Add Remove Folder in UI
        {
            var allPaths = getPaths();
            var i = 1;
            bool deleted = false;

            while (!deleted)
            {
                string pathCount = "Path" + i;
                string comparedPath = allPaths[i - 1];
                
                if(comparedPath.Equals(pathToKill))
                {
                    configsFile.DeleteKey(pathCount, "Paths");
                    deleted = true;
                }
                
                i++;
            }
        }
        
        /**
         * This method grabs the title from any song/path and cuts out the file location, as well as the file extension.
         */
        public static string getTitleFromPath(string path)
        {
            string[] pathSplit = path.Split('\\');

            string titleWithMP3 = pathSplit[pathSplit.Length - 1];
            string[] titleWithoutMP3 = titleWithMP3.Split(new[] { ".mp3" }, StringSplitOptions.None);
            
            return titleWithoutMP3[0];
        }
    }
}