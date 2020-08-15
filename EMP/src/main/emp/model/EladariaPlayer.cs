using System;
using System.Timers;
using System.Windows.Media;

namespace EMP.main.emp.model
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
        }

        public void timeExpired(Object sender, ElapsedEventArgs elapsedEventArgs)
        {
            //TODO: Can't interact with mediaplayer during this time for whatever reason
                //TODO: Instead, try adding a clock and use CurrentProgress methods etc?
            //If shuffle, get new song, then play that one, set new timer, call loopplay etc
            // Change all to loopplay
        }
    }
}