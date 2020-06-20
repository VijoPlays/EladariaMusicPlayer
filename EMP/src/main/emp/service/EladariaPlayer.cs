﻿﻿using System.Windows.Media;

namespace EMP.main.service 
{
    public class EladariaPlayer : MediaPlayer
    {
        private bool curPlaying = false;

        
        
        public bool getPlaying()
        {
            return curPlaying;
        }

        public void setPlaying(bool currentlyPlaying)
        {
            curPlaying = currentlyPlaying;
        }
    }
}