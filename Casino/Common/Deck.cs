using System;
using System.Collections.Generic;

namespace Casino.Common
{
    public abstract class Deck
    {
        public int DeckSize;
        public readonly List<int> Cards = new List<int>();

        public static Suit GetSuit(int cardNumber, List<int> cards)
        {
            return (Suit)(cardNumber / (cards.Count / 4));
        }

        public abstract string ToString(int cardNumber);

        public static void FillDeck(List<int> cards, int deckSize)
        {
            for (var i = 0; i < deckSize; i++)
            {
                cards.Add(i);
            }
        }

        public static void ShakeDeck(List<int> cards)
        {
            for (var i = 0; i < cards.Count - 1; i++)
            {
                var random = new Random();
                var indexFrom = i;
                var indexTo = random.Next(0, (cards.Count));
                var temp = cards[indexFrom];
                cards[indexFrom] = cards[indexTo];
                cards[indexTo] = temp;
            }
        }
    }

    public enum Suit
    {
        spades,
        hearts,
        clubs,
        diamonds
    }
}

