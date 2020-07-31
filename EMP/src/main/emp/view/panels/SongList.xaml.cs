using System.Windows.Controls;
using EMP.main.service;

namespace EMP.main.emp.view.panels
{
    public partial class SongList : ListView
    {
        private static SongGrabber songGrabber = new SongGrabber();

        public SongList()
        {
            InitializeComponent();

            //TODO: Create List with Columns (Subitems?), then Fill list, disable focus when clicking on it, play song when double clicking it, add scrollbar, change colour depending on background
            //TODO: When selecting an item, send it to the MediaPlayer/PlayMenu
            fillSongs();
        }

        private void fillSongs()
        { //TODO: Add compatibility with other sound files
            foreach (var file in SongGrabber.getDirectoryInfo().GetFiles("*.mp3"))
            {
                ListSongs.Items.Add(file); //TODO: Geht theoretisch, muss man nur abändern, weil das bei den 7000 Files nicht mehr funktioniert
                 // TagLib.File tagFile = TagLib.File.Create(file.FullName);
                 // var length = tagFile.Properties.Duration.ToString();
            }
        }
        
        
    }
}