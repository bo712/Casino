using Casino.Drunkard;
using NUnit.Framework;

namespace Casino.Tests.Drunkard
{
    [TestFixture]
    public class Deck36Tests
    {
        [TestCase(0, "six spades")]
        [TestCase(10, "seven hearts")]
        [TestCase(20, "eight clubs")]
        [TestCase(30, "nine diamonds")]
        [TestCase(35, "ace diamonds")]
        public void ToString_CardNumber_ReturnsName(int cardNumber, string expected)
        {
            var deck = new Deck36();
            Assert.AreEqual(deck.ToString(cardNumber), expected);
        }

        [TestCase(0, "seven spades")]
        [TestCase(10, "ten hearts")]
        [TestCase(20, "nine clubs")]
        [TestCase(30, "ace diamonds")]
        [TestCase(35, "six diamonds")]
        public void ToString_CardNumber_ReturnsWrongName(int cardNumber, string expected)
        {
            var deck = new Deck36();
            Assert.AreNotEqual(deck.ToString(cardNumber), expected);
        }

        [TestCase(1, "seven")]
        [TestCase(11, "eight")]
        [TestCase(21, "nine")]
        [TestCase(31, "ten")]
        [TestCase(34, "king")]
        public void GetPar_CardNumber_ReturnsPar(int cardNumber, Par36 expected)
        {
            var deck = new Deck36();
            Assert.AreEqual(deck.GetPar(cardNumber), expected);
        }

        [TestCase(1, "nine")]
        [TestCase(11, "nine")]
        [TestCase(21, "ten")]
        [TestCase(31, "nine")]
        [TestCase(34, "nine")]
        public void GetPar_CardNumber_ReturnsWrongPar(int cardNumber, Par36 expected)
        {
            var deck = new Deck36();
            Assert.AreNotEqual(deck.GetPar(cardNumber), expected);
        }
    }
}
