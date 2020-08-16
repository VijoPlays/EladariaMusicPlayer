using System;

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
        } //TODO: Go through all variables and check if they should be saved in the configs file
    }
}