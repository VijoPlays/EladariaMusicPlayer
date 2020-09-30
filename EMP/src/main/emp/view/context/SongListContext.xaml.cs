using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EMP.main.emp.view.context
{
    public partial class SongListContext : ContextMenu
    {

        private string path;
        
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
        }
        
        private void Filter_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            //TODO: Add "Filter by..." Album, Genre, etc
        }        
        
        private void ShowInExplorer_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Process.Start("explorer.exe","/select, \"" + path + "\"");
        }
    }
}