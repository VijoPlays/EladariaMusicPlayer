using System;
using System.Collections.Generic;
using EMP.main.emp.model;
using NUnit.Framework;

namespace EMP.test.emp.model
{
    [TestFixture]
    public class EladariaPlayerTest
    {
        
        private List<string> songDictionary = new List<string>();
        private Random random = new Random();
        private EladariaPlayer eladariaPlayer = new EladariaPlayer();
        
        public EladariaPlayerTest()
        {
            int songCount = 30;
            int i = 0;
            while (i < songCount)
            {
                songDictionary.Add(random.Next(1, 1000).ToString());
                i++;
            }
        }

        [TestCase]
        public void missingSongsTest()
        {
            eladariaPlayer.setMissingSongsSize(31);
            eladariaPlayer.setSongDictionary(songDictionary);
            Assert.AreNotEqual(eladariaPlayer.setSongDictionary(songDictionary), false);

            eladariaPlayer.setMissingSongsSize(30);
            eladariaPlayer.setSongDictionary(songDictionary); 
            Assert.AreEqual(eladariaPlayer.setSongDictionary(songDictionary), false);
        }
    }
}