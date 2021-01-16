using System;
using System.Windows;
using EMP.main.emp.model;
using EMP.main.emp.service;
using EMP.main.emp.service.persistence;
using EMP.main.emp.view.context;

namespace EMP.main.emp.view
{
    public partial class MainFrame
    {
        private static readonly EladariaPlayer mediaPlayer = new EladariaPlayer();

        public MainFrame()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Title = "Eladaria Music Player";

            playlistButton.Click += newPlaylistButton;
            setMediaPlayers();

            Closed += processTerminated;

            setUpSettings();
            SongList.setSongDictionary();
        }

        public void newPlaylistButton(object sender, EventArgs e) //TODO: Impl
        {
            
        }
        
        private void setUpSettings()
        {
            var volume = Configs.getVolume();
            if (string.IsNullOrEmpty(volume))
            {
                SliderVolume.Value = 50;
                mediaPlayer.Volume = .5;
            }
            else
            {
                mediaPlayer.Volume = Convert.ToDouble(volume) / 100;
                SliderVolume.Value = Convert.ToDouble(volume);
            }
        }

        private void processTerminated(object sender, EventArgs eventArgs)
        {
            Configs.setVolume(SliderVolume.Value.ToString());
            //TODO: Save all the configs things in here
        }

        private void setMediaPlayers()
        {
            SongList.setMediaPlayer(mediaPlayer);
            SongList.setPlayMenu(PlayMenu);
            SliderVolume.setMediaPlayer(mediaPlayer);
            PlayMenu.setMediaPlayer(mediaPlayer);
            menuBar.setMediaPlayer(mediaPlayer);
        }
    }
}