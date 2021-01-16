using NUnit.Framework;

namespace EMP.test.emp
{
    [TestFixture]
    public class ConfigTests
    {
        
        [TestCase]
        public void testThis()
        {
            string a = "";
            string b = a;
            Assert.AreEqual(a, b);
        }
    }
}