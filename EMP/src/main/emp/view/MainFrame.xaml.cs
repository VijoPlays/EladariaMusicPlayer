using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using EMP.Annotations;
using EMP.main.emp.controller;

namespace EMP.main.emp.view
{
    public partial class MainFrame
    {
        private static readonly MediaPlayer mediaPlayer = new MediaPlayer();
        private static bool playing, dragStarted, mouseOverVol;
        private double sliderVal = 0;

        public MainFrame()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Title = "Eladaria Music Player";

            SliderVolume.MouseEnter += mouseOverEnterVol;
            SliderVolume.MouseLeave += mouseOverLeaveVol;
            SliderVolume.ValueChanged += ActionListenerSliderValueChanged;

            TestButton.Click += jumpButton; //REMOVE

            menuBar.setMediaPlayer(mediaPlayer); //REMOVE
        }

        //TODO: Only slide when mouse over slider
        private void ActionListenerSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sliderVal = mediaPlayer.Volume * 100;
            if (mouseOverVol)
            {
                if (!dragStarted)
                    mediaPlayer.Volume = SliderVolume.Value / 100;
            }
            else
            {
                SliderVolume.Value = sliderVal;
            }
        }

        private void ActionListenerSliderDragStarted(object sender, DragStartedEventArgs e)
        {
            if (mouseOverVol)
                dragStarted = true;
        }

        private void ActionListenerSliderDragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (mouseOverVol)
            {
                mediaPlayer.Volume = SliderVolume.Value / 100;
                dragStarted = false;
            }
        }

        private void mouseOverEnterVol(object sender, EventArgs e)
        {
            mouseOverVol = true;
        }

        private void mouseOverLeaveVol(object sender, EventArgs e)
        {
            mouseOverVol = false;
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