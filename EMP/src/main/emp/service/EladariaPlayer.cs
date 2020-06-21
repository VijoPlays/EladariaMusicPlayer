using System.Windows.Media;

namespace EMP.main.service
{
    public class EladariaPlayer : MediaPlayer
    {
        private bool curPlaying;


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