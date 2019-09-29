using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Casino.Tests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void FillDeck_10itemsEmptyArray_SortedArray1to10()
        {
            List<int> list = new List<int>();
            List<int> expected = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            bool filledGood = true;

            Deck.FillDeck(list, list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != expected[i])
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
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            bool allCardsInDeck = true;
            Deck.ShakeDeck(list);
            for (int i = 0; i < list.Count; i++)
            {
                if (!list.Contains(i))
                {
                    allCardsInDeck = false;
                    break;
                }
            }
            Assert.IsTrue(allCardsInDeck);
        }
    }
}
