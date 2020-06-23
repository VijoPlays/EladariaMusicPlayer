namespace EMP.main.service
{
    public class SongGrabber
    { //TODO: Fix paths and such
        private static readonly string pathBase = "G:/Jailhouserock/";
        private static string pathSong = pathBase + "Paisley Park - Prince.mp3";

        public string addSong()
        {
            return pathSong;
        }
        
    }
}