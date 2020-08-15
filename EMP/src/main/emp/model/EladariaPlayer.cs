using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Media;

namespace EMP.main.emp.model
{
    public class EladariaPlayer : MediaPlayer
    {
        private bool playing, shuffle, repeat;

        private List<string> songDictionary;

        public EladariaPlayer()
        {
            MediaEnded += mediaFinished;
        }

        public void setShuffle(bool shuffle)
        {
            this.shuffle = shuffle;
        }

        public void setRepeat(bool repeat)
        {
            this.repeat = repeat;
        }

        public bool getPlaying()
        {
            return playing;
        }

        public void setPlaying(bool currentlyPlaying)
        {
            playing = currentlyPlaying;
        }

        public void setSongDictionary(List<string> songDictionary)
        {
            this.songDictionary = songDictionary;
        }

        public void loopPlay()
        {
            Play();
            playing = true;
        }

        private void mediaFinished(object sender, EventArgs eventArgs)
        {
            if (shuffle)
            {
                //Random random = new Random(number of songs to grab);
                //TODO: Make randomizer
                // Uri uri = new Uri(remaining songs[random]);
                // Open(uri);
                Play();
            }
            else if (repeat)
            {
                Position = new TimeSpan(0,0,0);
                Play();
            }
            else
            {
                playing = false;
            }
        }
    }
}