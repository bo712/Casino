using System;
using System.Linq;
using NUnit.Framework;

namespace Casino.Tests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void FillDeck_10itemsEmptyArrray_SortedArray1to10()
        {
            int[] array = new int[20];
            int[] expected = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            bool filledGood = true;

            Deck.FillDeck(array);
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
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            bool allCardsInDeck = true;
            Deck.ShakeDeck(array);
            for (int i = 0; i < array.Length; i++)
            {
                if (!array.Contains(i))
                {
                    allCardsInDeck = false;
                    break;
                }
            }
            Assert.IsTrue(allCardsInDeck);
        }
    }
}
