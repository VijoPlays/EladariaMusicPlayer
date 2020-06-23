using System;
using System.Windows;
using System.Windows.Media;

namespace EMP.main.emp.view
{
    public partial class MainFrame
    {
        private static readonly MediaPlayer mediaPlayer = new MediaPlayer();
        private static bool playing;

        public MainFrame()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Title = "Eladaria Music Player";

            TestButton.Click += jumpButton; //REMOVE

            SliderVolume.setMediaPlayer(mediaPlayer);
            menuBar.setMediaPlayer(mediaPlayer); //REMOVE
        }

        public MediaPlayer getMediaPlayer() //REMOVE
        {
            return mediaPlayer;
        }

        public void jumpButton(object sender, EventArgs e) //REMOVE
        {
        }
    }
}