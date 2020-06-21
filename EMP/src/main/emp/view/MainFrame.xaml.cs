using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace EMP.main.emp.view
{
    public partial class MainFrame : Window
    {
        private static readonly MediaPlayer mediaPlayer = new MediaPlayer();
        private bool dragStarted;

        public MainFrame()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Title = "Eladaria Music Player";
            MenuNewPlaylist.Click += ActionListenerNewPlayList;
        }

        private static void ActionListenerNewPlayList(object sender, RoutedEventArgs routedEventArgs)
        {
            //TODO: Create New Playlist, for now it's a sound test

            var songLocation = "G:/Jailhouserock/Great Gubal Library - FFXIV.mp3";
            var uriSong = new Uri(songLocation);
            mediaPlayer.Open(uriSong);
            mediaPlayer.Play();
        }

        private void ActionListenerSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!dragStarted) mediaPlayer.Volume = SliderVolume.Value / 100;
        }

        private void ActionListenerSliderDragStarted(object sender, DragStartedEventArgs e)
        {
            dragStarted = true;
        }

        private void ActionListenerSliderDragCompleted(object sender, DragCompletedEventArgs e)
        {
            mediaPlayer.Volume = SliderVolume.Value / 100;
            dragStarted = false;
        }
    }
}