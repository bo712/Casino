using System;
using NUnit.Framework;

namespace Casino.Tests
{
    [TestFixture]
    public class Deck52Tests
    {
        [TestCase(0, "two spades")]
        [TestCase(10, "queen spades")]
        [TestCase(20, "nine hearts")]
        [TestCase(30, "six clubs")]
        [TestCase(35, "joker clubs")]
        public void ToString_CardNumber_ReturnsName(int cardNumber, string expected)
        {
            Deck52 deck = new Deck52();
            Deck.FillDeck(deck.cards);
            Assert.AreEqual(deck.ToString(cardNumber), expected);
        }

        [TestCase(0, "seven spades")]
        [TestCase(10, "ten hearts")]
        [TestCase(20, "nine clubs")]
        [TestCase(30, "ace diamonds")]
        [TestCase(35, "six diamonds")]
        public void ToString_CardNumber_ReturnsWrongName(int cardNumber, string expected)
        {
            Deck52 deck = new Deck52();
            Deck.FillDeck(deck.cards);
            Assert.AreNotEqual(deck.ToString(cardNumber), expected);
        }

        [TestCase(1, "three")]
        [TestCase(11, "king")]
        [TestCase(21, "ten")]
        [TestCase(31, "seven")]
        [TestCase(34, "ten")]
        public void GetPar_CardNumber_ReturnsPar(int cardNumber, Par52 expected)
        {
            Deck52 deck = new Deck52();
            Deck.FillDeck(deck.cards);
            Assert.AreEqual(deck.GetPar(cardNumber), expected);
        }

        [TestCase(1, "nine")]
        [TestCase(11, "nine")]
        [TestCase(21, "nine")]
        [TestCase(31, "nine")]
        [TestCase(34, "nine")]
        public void GetPar_CardNumber_ReturnsWrongPar(int cardNumber, Par52 expected)
        {
            Deck52 deck = new Deck52();
            Deck.FillDeck(deck.cards);
            Assert.AreNotEqual(deck.GetPar(cardNumber), expected);
        }
    }
}
