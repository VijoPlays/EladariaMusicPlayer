using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EMP.main.emp.model;
using EMP.main.emp.view.context;
using EMP.main.emp.view.panels.playmenu;
using File = TagLib.File;

namespace EMP.main.emp.view.panels
{
    public partial class SongList : DataGrid
    {
        private EladariaPlayer mediaPlayer;
        private readonly List<string> songDictionary = new List<string>();
        private SongListContext songListContext = new SongListContext();
        private PlayMenu playMenu;
        
        public SongList()
        {
            InitializeComponent();
            fillSongs();
            ContextMenu = songListContext;
        }

        public void setMediaPlayer(EladariaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
            songListContext.setMediaPlayer(mediaPlayer);
        }

        public void setSongDictionary()
        {
            mediaPlayer.setSongDictionary(songDictionary);
        }

        private void fillSongs()
        {
            //TODO: Add compatibility with other sound file types
            int i = 1, j = 0;
            Song song;

            var pathlist = MainFrame.getConfigs().getPaths();

            while (j < pathlist.Count)
            {
                var directoryInfo = new DirectoryInfo(pathlist[j]);

                foreach (var file in directoryInfo.GetFiles("*.mp3"))
                {
                    song = new Song();
                    var tagFile = File.Create(file.FullName);
                    var duration = tagFile.Properties.Duration;
                    
                    song.Count = i;
                    song.Title = tagFile.Tag.Title;
                    song.Duration = calcTime(duration.Seconds, duration.Minutes);
                    // TODO: Playcount?
                    song.Genre = tagFile.Tag.FirstGenre;
                    song.Album = tagFile.Tag.Album;
                    song.DateAdded = tagFile.Tag.DateTagged.ToString();

                    //TODO: Save Header positions + size and preferred sorting
                    GridSongs.Items.Add(song);
                    songDictionary.Add(pathlist[j] + Path.DirectorySeparatorChar + song.Title + ".mp3");
                    //TODO: Fix Index by saving it in a temporary list
                    i++;
                }

                j++;
            }
            //If I can sort Gridsongs, use this one as well: songDictionary.Sort();
        } //TODO: Filter example: https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/datagrid_guidance/group_sort_filter

        private string calcTime(int seconds, int minutes)
        {
            string time;

            if (minutes <= 9)
                time = "0" + minutes;
            else
                time = minutes.ToString();

            if (seconds <= 9)
                time = time + ":" + "0" + seconds;
            else
                time = time + ":" + seconds;

            return time;
        }

        private int durationInSeconds(String duration)
        {
            int durationInSeconds;

            String[] durationSplit = duration.Split(Convert.ToChar(":"));

            durationInSeconds = int.Parse(durationSplit[0]) * 60 + int.Parse(durationSplit[1]);

            return durationInSeconds;
        }

        private void playSong(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var song = (Song) GridSongs.SelectedItems[0];
            var index = song.Count - 1;
            string path = songDictionary[index];

            playMenu.setTitle(getTitleFromPath(path));

            Uri uri = new Uri(path);
            mediaPlayer.Open(uri);
            mediaPlayer.loopPlay(path);
        }

        //This method grabs the title from any song/path and cuts out the file location, as well as the file extension.
        public static string getTitleFromPath(string path)
        {
            string[] pathSplit = path.Split('\\');

            string titleWithMP3 = pathSplit[pathSplit.Length - 1];
            string[] titleWithoutMP3 = titleWithMP3.Split(new[] { ".mp3" }, StringSplitOptions.None);
            
            return titleWithoutMP3[0];
        }

        private void rightClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while (dep != null && !(dep is DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null) return;

            DataGridCell cell = dep as DataGridCell;
            cell.Focus();
            while (dep != null && !(dep is DataGridRow))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            DataGridRow row = dep as DataGridRow;
            GridSongs.SelectedItem = row.DataContext;

            var song = (Song) GridSongs.SelectedItems[0];
            var index = song.Count - 1;
            string path = songDictionary[index];

            songListContext.setPath(path);
        }

        private class Song
        {
            public string Title { get; set; }
            public int Count { get; set; }
            public string Duration { get; set; }
            public string Genre { get; set; }
            public string Album { get; set; }
            public string DateAdded { get; set; }
        }
        
        public void setPlayMenu(PlayMenu playMenu)
        {
            this.playMenu = playMenu;
        }
    }
}