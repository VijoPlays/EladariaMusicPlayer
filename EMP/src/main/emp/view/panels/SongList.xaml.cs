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

            fillSongs();
        }

        private void fillSongs()
        {
            foreach (var file in SongGrabber.getDirectoryInfo().GetFiles("*.mp3")) ListSongs.Items.Add(file);
        }
    }
}