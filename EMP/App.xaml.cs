using System;
using System.IO;
using System.Windows.Media;

namespace EMP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        [STAThread]
        public static void Main(string[] args)
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();

            MediaPlayer mediaPlayer = new MediaPlayer();
            String songLocation = "G:/Jailhouserock/Great Gubal Library - FFXIV.mp3";
            Uri uriSong = new Uri(songLocation);
            FileInfo fileInfo = new FileInfo(songLocation);
            String attr = fileInfo.Attributes.ToString();
            mediaPlayer.Open(uriSong);
            var sFile = TagLib.File.Create(songLocation); //TODO: Download NuGet
            // Console.WriteLine(sFile.Tag.Album);
            // sFile.Save();

            // while (true)
            // {
            //     mediaPlayer.Play();
            // }
        }
    }
}