using System;
using System.IO;
using System.Windows.Media;
using File = TagLib.File;

namespace EMP
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();

            var mediaPlayer = new MediaPlayer();
            var songLocation = "G:/Jailhouserock/Great Gubal Library - FFXIV.mp3";
            var uriSong = new Uri(songLocation);
            var fileInfo = new FileInfo(songLocation);
            var attr = fileInfo.Attributes.ToString();
            mediaPlayer.Open(uriSong);
            var sFile = File.Create(songLocation);
            // Console.WriteLine(sFile.Tag.Album);
            // sFile.Save();


            //     mediaPlayer.Play();
        }
    }
}