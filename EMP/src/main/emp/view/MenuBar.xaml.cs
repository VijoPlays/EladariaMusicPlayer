using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EMP.main.emp.view
{
    public partial class MenuBar : Menu
    {
        public MenuBar()
        {
            InitializeComponent();
            MenuNewPlaylist.Click += ActionListenerNewPlayList;
        }

        private static void ActionListenerNewPlayList(object sender, RoutedEventArgs routedEventArgs)
        {
            

            //TODO: Create New Playlist, for now it's a sound test
            MediaPlayer mediaPlayer = new MediaPlayer();
            var songLocation = "G:/Jailhouserock/Great Gubal Library - FFXIV.mp3";
            var uriSong = new Uri(songLocation);
            mediaPlayer.Open(uriSong);
            mediaPlayer.Play();
        }

        //TODO: Add additional Actionlisteners for the other MenuItems
    }
}