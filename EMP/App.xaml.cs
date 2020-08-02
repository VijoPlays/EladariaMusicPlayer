using System;
using System.IO;
using System.Windows.Media;
using EMP.main.emp.service;
using EMP.main.emp.service.persistence;
using EMP.main.service;
using File = TagLib.File;

namespace EMP
{
    public partial class App
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}