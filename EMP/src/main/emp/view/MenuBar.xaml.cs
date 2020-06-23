using System;
using System.IO;
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
            

            //TODO: Create New Playlist, for now it's a sound test
            var songLocation = "G:/Jailhouserock/Great Gubal Library - FFXIV.mp3";
            var uriSong = new Uri(songLocation);
            mediaPlayer.Open(uriSong);
            mediaPlayer.Play();
        }

        public void setMediaPlayer(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
        }
        //TODO: Add additional Actionlisteners for the other MenuItems
    }
}