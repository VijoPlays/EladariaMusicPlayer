using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using EMP.main.emp.service.persistence;
using EMP.main.emp.view;

namespace EMP.main.emp.model
{
    /**
     * This is a modified MediaPlayer to allow special functions.
     */
    public class EladariaPlayer : MediaPlayer
    {
        private bool playing, shuffle = true, repeat, tooFewSongs, playNext;
        private static List<string> remainingSongs = new List<string>();
        private static int missingSongsSize = 10; //Change Size of queue to change how many songs are removed from remainingSongs
        private static Queue missingSongs = new Queue(missingSongsSize);

        public EladariaPlayer()
        {
            MediaEnded += mediaFinished;
        }

        public void reverseShuffle()
        {
            shuffle = !shuffle;
        }

        public void reverseRepeat()
        {
            repeat = !repeat;
        }

        public void setPlaying(bool playing)
        {
            this.playing = playing;
        }

        public bool getPlaying()
        {
            return playing;
        }

        public static void excludeSong(string path)
        {
            remainingSongs.Remove(path);
        }

        public void setMissingSongsSize(int size) //TODO: Create UI
        {
            missingSongsSize = size;
            if (remainingSongs.Count + missingSongs.Count - missingSongsSize < 0)
            {
                tooFewSongs = true;
            }
            missingSongs = new Queue(size);
        }

        public bool setSongDictionary(List<string> songDictionary)
        {
            remainingSongs = songDictionary.ToList();
            if (songDictionary.Count - missingSongsSize < 0)
            {
                tooFewSongs = true;
            }
            else
            {
                tooFewSongs = false;
            }

            return tooFewSongs;
        }

        public void loopPlay()
        {
            Play();
            playing = true;
        }

        public void loopPlay(String path)
        {
            Play();
            playing = true;
            if (tooFewSongs) return;
            missingSongs.Enqueue(path);
            excludeSong(path);
        }

        /**
         * This method is used to loop automatically after a song has finished playing.
         */
        private void mediaFinished(object sender, EventArgs eventArgs)
        {
            if (playNext)
            {
                //TODO; set playNext = true, then play that song
            } else if (shuffle)
            {
                Random random = new Random();
                
                int randSong = random.Next(1, remainingSongs.Count);
                string path = remainingSongs[randSong - 1];
                Uri uri = new Uri(path);
                Open(uri);
                Play();

                if (tooFewSongs) return;
                
                if (missingSongs.Count == missingSongsSize)
                {
                    remainingSongs.Add(missingSongs.Dequeue().ToString());
                }
                
                missingSongs.Enqueue(path);
                excludeSong(path);
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