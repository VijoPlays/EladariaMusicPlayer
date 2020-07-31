using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EMP.main.emp.service;
using EMP.main.service;

namespace EMP.main.emp.view.panels
{
    public partial class SongList : DataGrid
    {
        private EladariaPlayer mediaPlayer;
        private Dictionary<int, string> songDictionary = new Dictionary<int, string>(); 
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
            int i = 1;
            Song song = new Song();
            foreach (var file in SongGrabber.getDirectoryInfo().GetFiles("*.mp3"))
            {
                song = new Song();
                TagLib.File tagFile = TagLib.File.Create(file.FullName);
                song.Count = i; 
                song.Title = tagFile.Tag.Title;
                song.Duration = tagFile.Properties.Duration.ToString(); //TODO: Evtl auf Mins + Secs kürzen
                // TODO: Playcount?
                song.Genre = tagFile.Tag.FirstGenre;
                song.Album = tagFile.Tag.Album;
                song.DateAdded = tagFile.Tag.DateTagged.ToString();
                
                //TODO: Sorting function, resize and drag/move headers around option (only headers, then refresh the table afterwards)
                GridSongs.Items.Add(song);
                songDictionary.Add(i, file.FullName); //TODO: Achtung, wenn die Liste umstrukturiert wird is diese rip, da sie den Index nutzt
                // 
                 // var length = tagFile.Properties.Duration.ToString();
                 i++;
            }
        }

        private void playSong(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        { //TODO: Fix Double Click event, then change right click event to proper right clicking
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