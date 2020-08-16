using System;
using System.Windows;
using EMP.main.emp.model;
using EMP.main.emp.service;
using EMP.main.emp.service.persistence;

namespace EMP.main.emp.view
{
    public partial class MainFrame
    {
        private static readonly EladariaPlayer mediaPlayer = new EladariaPlayer();
        private static readonly Configs configs = new Configs();

        public MainFrame()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Title = "Eladaria Music Player";

            TestButton.Click += jumpButton; //REMOVE
            setMediaPlayers();

            Closed += processTerminated;

            setUpSettings();
            SongList.setSongDictionary();
        }

        public void jumpButton(object sender, EventArgs e) //REMOVE
        {
        }

        public static Configs getConfigs()
        {
            return configs;
        }

        private void setUpSettings()
        {
            var volume = configs.getVolume();
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
            configs.setVolume(SliderVolume.Value.ToString());
            //TODO: Save all the configs things in here
        }

        private void setMediaPlayers()
        {
            SongList.setMediaPlayer(mediaPlayer);
            SliderVolume.setMediaPlayer(mediaPlayer);
            PlayMenu.setMediaPlayer(mediaPlayer);
            menuBar.setMediaPlayer(mediaPlayer);
        }
    }
}