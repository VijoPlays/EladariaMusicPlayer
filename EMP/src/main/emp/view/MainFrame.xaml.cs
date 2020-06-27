using System;
using System.Windows;
using System.Windows.Media;
using EMP.main.emp.service.persistence;

namespace EMP.main.emp.view
{
    public partial class MainFrame
    {
        private static readonly MediaPlayer mediaPlayer = new MediaPlayer();
        private static bool playing;
        private static Configs configs = new Configs();

        public MainFrame()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Title = "Eladaria Music Player";

            TestButton.Click += jumpButton; //REMOVE

            SliderVolume.setMediaPlayer(mediaPlayer);
            menuBar.setMediaPlayer(mediaPlayer); //REMOVE
            Closed += processTerminated;
            
            setUpSettings();
        }

        public void jumpButton(object sender, EventArgs e) //REMOVE
        {
        }

        private void setUpSettings()
        {
            string volume = configs.getVolume();
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
        }
    }
}