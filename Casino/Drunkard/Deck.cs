using System;
namespace Casino
{
    public class Deck
    {
        public const int deckSize = 36;
        public int[] cards = new int[deckSize];

        public Deck()
        {
            FillDeck(cards, deckSize);
            ShakeDeck(cards, deckSize);
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
            //Console.WriteLine(GetPar(cardNumber) + " " + GetSuit(cardNumber));
            return GetPar(cardNumber) + " " + GetSuit(cardNumber);
        }

        public static void FillDeck(int[] cards, int deckSize)
        {
            for (int i = 0; i < deckSize; i++)
            {
                cards[i] = i;
            }
        }

        public void ShakeDeck(int[] cards, int deckSize)
        {
            //calculate checksum of deck
            int sumBeforeShake = CalculateCheckSum(cards, deckSize);

            for (int i = 0; i < 8000; i++)
            {
                Random random = new Random();
                int indexFrom = random.Next(0, (deckSize - 1));
                int indexTo = random.Next(0, (deckSize - 1));
                int temp = cards[indexFrom];
                cards[indexFrom] = cards[indexTo];
                cards[indexTo] = temp;
            }

            //calculate checksum of shaked deck
            int sumAfterShake = CalculateCheckSum(cards, deckSize);
            if (sumBeforeShake != sumAfterShake)
                throw new Exception("Bad shaking!");
        }

        private static int CalculateCheckSum(int[] cards, int deckSize)
        {
            int sum = 0;
            foreach (var card in cards)
            {
                sum += card;
            }
            return sum;
        }

        public void PrintDeck()
        {
            for (int i = 0; i < deckSize; i++)
            {
                Console.WriteLine(ToString(cards[i]));
            }
        }
    }
}
