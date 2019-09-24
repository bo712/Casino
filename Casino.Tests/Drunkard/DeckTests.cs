using System;
using System.Linq;
using NUnit.Framework;

namespace Casino.Tests
{
    [TestFixture]
    public class DeckTests
    {
        Deck decks;
        [SetUp]
        public void Setup()
        {
            decks = new Deck();
        }

        [Test]
        public void FillDeck_10itemsEmptyArrray_SortedArray1to10()
        {
            int size = 10;
            int[] array = new int[10];
            int[] expected = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bool filledGood = true;
            Deck.FillDeck(array, size);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != expected[i])
                {
                    filledGood = false;
                    break;
                }
            }
            Assert.IsTrue(filledGood);
        }

        [Test]
        public void ShakeDeck_SortedArray_UnsortedArrayWithSameItems()
        {
            bool allCardsInDeck = true;
            for (int i = 0; i < decks.cards.Length; i++)
            {
                if (!decks.cards.Contains(i))
                {
                    allCardsInDeck = false;
                    break;
                }
            }
            Assert.IsTrue(allCardsInDeck);
        }

        [Test]
        public void Test2()
        {

        }
    }
}
