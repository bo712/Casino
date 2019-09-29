using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    public abstract class Deck
    {
        protected int deckSize;
        public int[] cards;

        public static Suit GetSuit(int cardNumber, int deckSize)
        {
            return (Suit)(cardNumber / (deckSize / 4));
        }

        public abstract string ToString(int cardNumber);

        public static void FillDeck(int[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = i;
            }
        }

        //public static void ShakeDeck(int[] cards)
        //{
        //    int sumBeforeShake = CalculateCheckSum(cards);

        //    for (int i = 0; i < 80000; i++)
        //    {
        //        Random random = new Random();
        //        int indexFrom = random.Next(0, (cards.Length - 1));
        //        int indexTo = random.Next(0, (cards.Length - 1));
        //        int temp = cards[indexFrom];
        //        cards[indexFrom] = cards[indexTo];
        //        cards[indexTo] = temp;
        //    }

        //    int sumAfterShake = CalculateCheckSum(cards);
        //    if (sumBeforeShake != sumAfterShake)
        //        throw new Exception("Bad shaking!");
        //}

        public static void ShakeDeck(int[] cards)
        {
            int sumBeforeShake = CalculateCheckSum(cards);

            for (int i = 0; i < cards.Length - 1; i++)
            {
                Random random = new Random();
                int indexFrom = i;
                int indexTo = random.Next(0, (cards.Length));
                int temp = cards[indexFrom];
                cards[indexFrom] = cards[indexTo];
                cards[indexTo] = temp;
            }

            int sumAfterShake = CalculateCheckSum(cards);
            if (sumBeforeShake != sumAfterShake)
                throw new Exception("Bad shaking!");
        }

        public static int CalculateCheckSum(int[] cards)
        {
            int sum = 0;
            foreach (var card in cards)
            {
                sum += card;
            }
            return sum;
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

