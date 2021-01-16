using System;
using System.Collections.Generic;
using EMP.main.emp.service.persistence;
using NUnit.Framework;

namespace EMP.test.emp
{
    [TestFixture]
    public class ConfigTests
    {
        private Random random = new Random();

        [TestCase]
        public void volumeTest()
        {
            string oldVol = Configs.getVolume();
            if (!oldVol.Equals(""))
            {
                string newVol = (double.Parse(oldVol) + random.Next(1, 30)).ToString();
                Configs.setVolume(newVol);

                Assert.AreEqual(newVol, Configs.getVolume());

                Configs.setVolume(oldVol);
            }
            else //Weird test, but I'm too lazy to create a new Method to delete the Volume and then test it, so... eh.
            {
                string newVol = random.Next(1, 30).ToString();
                Configs.setVolume(newVol);

                Assert.AreEqual(newVol, Configs.getVolume());
            }
        }

        [TestCase]
        public void pathTest()
        {
            string titleWithPath = "G:\\Newmusicboys\\Music\\You_Just_Got_Rick_Rolled_69.mp3";
            string titleWithoutPath = "You_Just_Got_Rick_Rolled_69";
            
            Assert.AreEqual(Configs.getTitleFromPath(titleWithPath), titleWithoutPath);
            
            
            string newPath = random.Next(1, 500).ToString();
            Configs.setPaths(newPath);

            List<string> newPaths = Configs.getPaths();
            string lastPath = newPaths[newPaths.Count - 1];
            
            Assert.AreEqual(lastPath, newPath);
            
            Configs.clearPath(newPath);
            
            newPaths = Configs.getPaths();
            if(newPaths.Count == 0) return;
            lastPath = newPaths[newPaths.Count - 1];
            Assert.AreNotEqual(lastPath, newPath);
        }
    }
}