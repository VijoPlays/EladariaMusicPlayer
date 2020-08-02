using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using EMP.main.emp.service.persistence;
using EMP.main.service;

namespace EMP.main.emp.view.panels
{
    public partial class SongList : DataGrid
    {
        private EladariaPlayer mediaPlayer;
        private Dictionary<int, string> songDictionary = new Dictionary<int, string>();
        private static Configs configs = new Configs();
        public SongList()
        {
            InitializeComponent();
            
            
            //TODO: Create List with Columns (Subitems?), then Fill list, disable focus when clicking on it, play song when double clicking it, add scrollbar, change colour depending on background
            //TODO: When selecting an item, send it to the MediaPlayer/PlayMenu
            fillSongs();
        }

        public void setMediaPlayer(EladariaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
        }

        public class Song
        {
            public string Title { get; set; }
            public int Count { get; set; }
            public string Duration { get; set; }
            public string Genre { get; set; }
            public string Album { get; set; }
            public string DateAdded { get; set; }
        }

        private void fillSongs()
        { //TODO: Add compatibility with other sound files
            int i = 1, j = 0;
            Song song;

            List<string> pathlist = configs.getPaths();
            
            while (j < pathlist.Count)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(pathlist[j]);

                foreach (var file in directoryInfo.GetFiles("*.mp3"))
                {
                    song = new Song();
                    TagLib.File tagFile = TagLib.File.Create(file.FullName);
                    TimeSpan duration = tagFile.Properties.Duration;
                    
                    song.Count = i; 
                    song.Title = tagFile.Tag.Title;
                    song.Duration = calcTime(duration.Seconds, duration.Minutes);
                    // TODO: Playcount?
                    song.Genre = tagFile.Tag.FirstGenre;
                    song.Album = tagFile.Tag.Album;
                    song.DateAdded = tagFile.Tag.DateTagged.ToString();
                
                    //TODO: Save Header positions + size and preferred sorting
                    GridSongs.Items.Add(song);
                    i++;
                }
                j++;
            }
        }

        private string calcTime(int seconds, int minutes)
        {
            string time;
            
            if (minutes <= 9)
            {
                time = "0" + minutes;
            }
            else
            {
                time = minutes.ToString();
            }

            if (seconds <= 9)
            {
                time = time + ":" + "0" + seconds;
            }
            else
            {
                time = time + ":" + seconds;
            }

            return time;
        }

        private void playSong(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            Song row = (Song) GridSongs.SelectedItems[0];
            int index = row.Count;
            String path;
            songDictionary.TryGetValue(index, out path);
            mediaPlayer.Open(new Uri(path));
            mediaPlayer.Play();
            mediaPlayer.setPlaying(true);
        }

        private void rightClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            //TODO: Add functionality      
        }
    }
}