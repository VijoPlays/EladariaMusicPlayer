using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EMP.main.emp.view
{
    public partial class MenuBar : Menu
    {
        private MediaPlayer mediaPlayer;

        public MenuBar()
        {
            InitializeComponent();
            MenuNewPlaylist.Click += ActionListenerNewPlayList;
        }

        private void ActionListenerNewPlayList(object sender, RoutedEventArgs routedEventArgs)
        {
            //TODO: Create New Playlist
        }

        public void setMediaPlayer(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
        }

        //TODO: Add additional Actionlisteners for the other MenuItems (e.g. set Folders)
    }
}