using System;
using System.Windows.Controls;
using EMP.main.emp.model;

namespace EMP.main.emp.view.panels.playmenu
{
    /**
     * This class implements the player at the top of the application.
     */
    public partial class PlayMenu : Grid
    {
        private EladariaPlayer mediaPlayer;
        private TimeSpan songProgress;

        public PlayMenu()
        {
            InitializeComponent();

            btn_Play.Click += playMusic;
        }

        public void setTitle(String title)
        {
            txt_Title.Text = title;
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
                mediaPlayer.loopPlay();
            }
        }
        
        //TODO: Shuffle is true on default
        

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
    }
}


//TODO Next: PlayMenu Skip/Previous would be dope