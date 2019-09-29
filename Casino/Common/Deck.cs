using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    public abstract class Deck
    {
        public int deckSize;
        //public int[] cards;
        public List<int> cards = new List<int>();

        public static Suit GetSuit(int cardNumber, List<int> cards)
        {
            return (Suit)(cardNumber / (cards.Count / 4));
        }

        public abstract string ToString(int cardNumber);

        public static void FillDeck(List<int> cards, int deckSize)
        {
            for (int i = 0; i < deckSize; i++)
            {
                cards.Add(i);
            }
        }

        public static void ShakeDeck(List<int> cards)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                Random random = new Random();
                int indexFrom = i;
                int indexTo = random.Next(0, (cards.Count));
                int temp = cards[indexFrom];
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

