﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;

namespace EMP.main.emp.model
{
    public class EladariaPlayer : MediaPlayer
    {
        private bool playing, shuffle = true, repeat, tooFewSongs;

        private List<string> remainingSongs;
        private int missingSongsSize = 10; //Change Size of queue to change how many songs are removed from remainingSongs
        private Queue missingSongs;

        public EladariaPlayer()
        {
            MediaEnded += mediaFinished;
            missingSongs = new Queue(missingSongsSize);
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

        public void setMissingSongsSize(int size) //TODO: Create UI
        {
            missingSongsSize = size;
            if (remainingSongs.Count + missingSongs.Count - missingSongsSize < 0)
            {
                tooFewSongs = true;
            }
            missingSongs = new Queue(size);
        }

        public void setSongDictionary(List<string> songDictionary)
        {
            remainingSongs = songDictionary;
            if (songDictionary.Count - missingSongsSize < 0)
            {
                tooFewSongs = true;
            }
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
            remainingSongs.Remove(path);
            missingSongs.Enqueue(path);
        }

        private void mediaFinished(object sender, EventArgs eventArgs)
        {
            if (shuffle)
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
                
                remainingSongs.Remove(path);
                missingSongs.Enqueue(path);
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