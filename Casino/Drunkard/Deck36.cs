using System;
namespace Casino
{
    public class Deck36
    {
        public const int deckSize = 36;
        public int[] cards = new int[deckSize];

        public Deck36()
        {
            FillDeck(cards);
            ShakeDeck(cards);
        }

        public Suit GetSuit(int cardNumber)
        {
            return (Suit)(cardNumber / (deckSize / 4));
        }

        public Par36 GetPar(int cardNumber)
        {
            return (Par36)(cardNumber % (deckSize / 4));
        }

        public string ToString(int cardNumber)
        {
            return GetPar(cardNumber) + " " + GetSuit(cardNumber);
        }

        public static void FillDeck(int[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = i;
            }
        }

        public static void ShakeDeck(int[] cards)
        {
            int sumBeforeShake = CalculateCheckSum(cards);

            for (int i = 0; i < 8000; i++)
            {
                Random random = new Random();
                int indexFrom = random.Next(0, (cards.Length - 1));
                int indexTo = random.Next(0, (cards.Length - 1));
                int temp = cards[indexFrom];
                cards[indexFrom] = cards[indexTo];
                cards[indexTo] = temp;
            }

            int sumAfterShake = CalculateCheckSum(cards);
            if (sumBeforeShake != sumAfterShake)
                throw new Exception("Bad shaking!");
        }

        private static int CalculateCheckSum(int[] cards)
        {
            int sum = 0;
            foreach (var card in cards)
            {
                sum += card;
            }
            return sum;
        }
    }
}
