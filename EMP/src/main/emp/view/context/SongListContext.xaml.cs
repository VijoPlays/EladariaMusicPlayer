using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using EMP.main.emp.model;
using EMP.main.emp.view.panels;

namespace EMP.main.emp.view.context
{
    // This context class is called when right clicking on a song.
    public partial class SongListContext : ContextMenu
    {

        private string path;
        private EladariaPlayer mediaPlayer;
        
        public SongListContext()
        {
            InitializeComponent();
        }

        public void setPath(string path)
        {
            this.path = path;
        }
        
        private void CopyName_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Clipboard.SetText(SongList.getTitleFromPath(path));
        }
        
        private void Filter_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            //TODO: Add "Filter by..." Album, Genre, etc
        }        
        
        private void ShowInExplorer_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Process.Start("explorer.exe","/select, \"" + path + "\"");
        }
        
        private void PlayNext_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            mediaPlayer.loopPlay(path);
            //TODO: Currently bugged, maybe related to the fact that it's not being called from the MainFrame itself? 
        }
        
        // This method is used to queue a song up.
        private void QueueNext_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            
        }
        
        // This method is used to ignore a song from being played.
        private void Exclude_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            EladariaPlayer.excludeSong(path);
        }

        public void setMediaPlayer(EladariaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
        }
    }
}