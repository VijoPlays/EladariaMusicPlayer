using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EMP.main.emp.view.panels
{
    public partial class PlayMenu : Grid
    {
        private MediaPlayer mediaPlayer;
        private bool playing;
        private string songName = "G:/Jailhouserock/Paisley Park - Prince.mp3"; //TODO: Song Location == Currently selected Item in list (remove Great Gubal Lib), prevent hardcoded path
        private TimeSpan songProgress;
        public PlayMenu()
        {
            InitializeComponent();
            btn_Play.Click += playMusic;
        }
        
        private void playMusic(object sender, EventArgs e)
        { //TODO: Change Image_Play icon when music is playing
            if (playing)
            {
                songProgress = mediaPlayer.Position;
                mediaPlayer.Stop();
                playing = false;
            }
            else
            {
                Uri uriSong = new Uri(songName);
                mediaPlayer.Open(uriSong);
                mediaPlayer.Position = songProgress;
                mediaPlayer.Play(); //TODO: Continuous play/Playqueue
                playing = true;
            }
        }
        private void skipSong(object sender, EventArgs e)
        {
            songProgress = TimeSpan.Zero;
            // mediaPlayer.Position = ...
            //TODO: Add Skipping mechanic
        }

        private void previousSong(object sender, EventArgs e)
        {
            songProgress = TimeSpan.Zero;
            //TODO: Add Previous mechanic
        }

        public void setMediaPlayer(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
        }
    }
}