using System.Collections.Generic;
using System.Linq;
using Casino.Common;
using NUnit.Framework;

namespace Casino.Tests.Common
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void FillDeck_10itemsEmptyArray_SortedArray1to10()
        {
            var list = new List<int>();
            var expected = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

            Deck.FillDeck(list, list.Count);
            var filledGood = !list.Where((t, i) => t != expected[i]).Any();
            Assert.IsTrue(filledGood);
        }

        [Test]
        public void ShakeDeck_SortedArray_UnsortedArrayWithSameItems()
        {
            var list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            Deck.ShakeDeck(list);
            var allCardsInDeck = !list.Where((t, i) => !list.Contains(i)).Any();
            Assert.IsTrue(allCardsInDeck);
        }
    }
}
