using System;
using System.Windows.Controls;
using EMP.main.emp.model;
using EMP.main.emp.service;

namespace EMP.main.emp.view.panels
{
    public partial class PlayMenu : Grid
    {
        private EladariaPlayer mediaPlayer;
        private bool playing;
        private TimeSpan songProgress;

        public PlayMenu()
        {
            InitializeComponent();

            btn_Play.Click += playMusic;
        }

        private void playMusic(object sender, EventArgs e)
        {
            //TODO: Change Image_Play icon when music is playing
            if (mediaPlayer.getPlaying())
            {
                songProgress = mediaPlayer.Position;
                mediaPlayer.Pause();
                mediaPlayer.setPlaying(false);
            }
            else
            {
                mediaPlayer.Position = songProgress;
                mediaPlayer.Play(); //TODO: Continuous play/Playqueue
                mediaPlayer.setPlaying(true);
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

        public void setMediaPlayer(EladariaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
        }

        public void setPlaying(bool playing)
        {
            this.playing = playing;
        }
    }
}