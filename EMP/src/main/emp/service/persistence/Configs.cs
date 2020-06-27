using System;
using System.IO;

namespace EMP.main.emp.service.persistence
{
    public class Configs
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string eladariaFolder = Path.DirectorySeparatorChar + "Eladaria Studios" + Path.DirectorySeparatorChar + "EMP";
        private IniCreator configsFile;

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
    }
}