using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EMP.main.emp.view
{
    public partial class MenuBar : Menu
    {
        public MenuBar()
        {
            InitializeComponent();
            MenuNewPlaylist.Click += ActionListenerNewPlayList;
        }
        
        private static void ActionListenerNewPlayList(object sender, RoutedEventArgs routedEventArgs)
        {
            //TODO: Create New Playlist, for now it's a sound test
        }
        //TODO: Add additional Actionlisteners for the other MenuItems
    }
}