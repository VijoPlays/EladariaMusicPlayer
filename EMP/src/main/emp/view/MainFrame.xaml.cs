using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using EMP.main.emp.controller;

namespace EMP.main.emp.view
{
    public partial class MainFrame
    {
        private static readonly MediaPlayer mediaPlayer = new MediaPlayer();
        private static bool playing, dragStarted;

        public MainFrame()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Title = "Eladaria Music Player";
            
            
            menuBar.setMediaPlayer(mediaPlayer); //REMOVE
        }
        //TODO: Only slide when mouse over slider
        private void ActionListenerSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!dragStarted) 
                mediaPlayer.Volume = SliderVolume.Value / 100;
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
        
        public MediaPlayer getMediaPlayer() //REMOVE
        {
            return mediaPlayer;
        }
    }
}