using System.IO;

namespace EMP.main.service
{
    public class SongGrabber
    {
        //TODO: Fix paths and such
        private static readonly string pathBase = "G:/Jailhouserock/";
        private static readonly string pathSong = pathBase + "Paisley Park - Prince.mp3";
        private static readonly DirectoryInfo directoryInfo = new DirectoryInfo(pathBase);

        public string addSong()
        {
            return pathSong;
        }

        public static DirectoryInfo getDirectoryInfo()
        {
            return directoryInfo;
        }

        public string getPathBase()
        {
            return pathBase;
        }
    }
}