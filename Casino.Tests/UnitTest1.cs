using NUnit.Framework;
using Casino;

namespace Casino.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int x = Program.Test(2, 3);
            Assert.AreEqual(5, x);
        }
    }
}