using System.Windows.Media;

namespace EMP.main.service
{
    public class EladariaPlayer : MediaPlayer
    {
        private bool playing;

        public bool getPlaying()
        {
            return playing;
        }

        public void setPlaying(bool currentlyPlaying)
        {
            playing = currentlyPlaying;
        }
    }
}