using EMP.main.emp.model;
using EMP.main.emp.service;

namespace EMP.main
{
    public class MediaController
    {
        private static EladariaPlayer eladariaPlayer;

        public static void main(string[] args)
        {
            eladariaPlayer = new EladariaPlayer();
        }
    }
}