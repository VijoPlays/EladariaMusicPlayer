using System;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace EMP.main.service
{
    public class EladariaPlayer : MediaPlayer
    {
        private bool playing;

        private Timer timer = new Timer();

        public EladariaPlayer()
        {
            timer.Elapsed += timeExpired;
            timer.AutoReset = false;
        }

        public bool getPlaying()
        {
            return playing;
        }

        public void setPlaying(bool currentlyPlaying)
        {
            playing = currentlyPlaying;
        }

        public Timer getTimer()
        {
            return timer;
        }


        public void loopPlay(int duration)
        {
            Play();
            playing = true;
            timer.Interval = duration * 1000;
            timer.Start();
            //TODO: Adjust timer, then play again if timer over
        }

        public void timeExpired(Object sender, ElapsedEventArgs elapsedEventArgs)
        {
            String path = "G:/Jailhouserock/Great Gubal Library - FFXIV.mp3";
            Uri uri = new Uri(path);
            Open(uri);
            this.Play();
            timer.Interval = 1000000000000000000;
            timer.Elapsed -= timeExpired;
            //If shuffle, get new song, then play that one, set new timer, call loopplay etc
            // Change all to loopplay
        }
    }
}