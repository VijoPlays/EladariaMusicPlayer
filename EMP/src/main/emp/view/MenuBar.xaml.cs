using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using EMP.main.emp.model;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EMP.main.emp.view
{
    public partial class MenuBar : Menu
    {
        private EladariaPlayer mediaPlayer;

        public MenuBar()
        {
            InitializeComponent();
            MenuNewPlaylist.Click += ActionListenerNewPlayList;
            MenuCustomAddFolder.Click += ActionListenerNewFolder;
        }
        //TODO: Add way to remove folder and other things that we're gonna add
        
        public void setMediaPlayer(EladariaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
        }

        private void ActionListenerNewFolder(object sender, RoutedEventArgs routedEventArgs)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                mediaPlayer.getConfigs().setPaths(dialog.FileName);
            }
        }

        private void ActionListenerNewPlayList(object sender, RoutedEventArgs routedEventArgs)
        {
            //TODO: Create New Playlist
        }

        //TODO: Add additional Actionlisteners for the other MenuItems (e.g. set Folders)
    }
}