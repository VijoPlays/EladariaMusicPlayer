using System;
using System.Collections.Generic;
using System.IO;

namespace EMP.main.emp.service.persistence
{
    public class Configs
    {
        private IniCreator configsFile;

        private string eladariaFolder =
            Path.DirectorySeparatorChar + "Eladaria Studios" + Path.DirectorySeparatorChar + "EMP";

        private readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Configs()
        {
            appendPaths();
            Directory.CreateDirectory(eladariaFolder);
        }

        private void appendPaths()
        {
            eladariaFolder = path + eladariaFolder;
            configsFile = new IniCreator(eladariaFolder + Path.DirectorySeparatorChar + "configs.ini");
        }

        public string getVolume()
        {
            return configsFile.Read("Volume", "Settings");
        }

        public void setVolume(string volume)
        {
            configsFile.Write("Volume", volume, "Settings");
        }

        //TODO: Enable setting the paths somewhere
        public List<string> getPaths()
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

        //TODO: Test the 2 methods below this one

        public void setPaths(string path)
        {
            var i = 1;
            while (configsFile.KeyExists("Path" + i, "Paths")) i++;

            var pathcount = "Path" + i;

            configsFile.Write(pathcount, path, "Paths");
        }

        public void clearPath(string pathToKill)
        {
            var allPaths = new List<string>();
            var i = 1;
            configsFile.DeleteKey(pathToKill);
            while (configsFile.KeyExists("Path" + i, "Paths"))
            {
                allPaths.Add(configsFile.Read("Path" + i));
                i++;
            }

            i++; //Keikaku's Note: Two While loops are intended. This way any key can be deleted, even in the middle.
            while (configsFile.KeyExists("Path" + i, "Paths"))
            {
                allPaths.Add(configsFile.Read("Path" + i));
                i++;
            }

            i = 1;
            while (allPaths.Count > i) setPaths(allPaths[i]);
        }
    }
}