using System;
namespace Casino
{
    public class Deck
    {
        private readonly int _deckSize;
        public int[] decks;

        public Deck(int deckSize)
        {
            _deckSize = deckSize;
            decks = new int[_deckSize];
            decks = FillDeck(decks, _deckSize);
            decks = ShakeDeck(decks, _deckSize);
        }

        public Suit GetSuit(int cardNumber)
        {
            return (Suit)(cardNumber / (_deckSize / 4));
        }

        public Par GetPar(int cardNumber)
        {
            return (Par)(cardNumber % (_deckSize / 4));
        }

        public string ToString(int cardNumber)
        {
            //Console.WriteLine(GetPar(cardNumber) + " " + GetSuit(cardNumber));
            return GetPar(cardNumber) + " " + GetSuit(cardNumber);
        }

        public int[] FillDeck(int[] deck, int deckSize)
        {
            for (int i = 0; i < deckSize; i++)
            {
                deck[i] = i;
            }
            return deck;
        }

        public int[] ShakeDeck(int[] deck, int deckSize)
        {
            //calculate checksum of deck
            int sumBeforeShake = 0;
            for (int i = 0; i < deckSize; i++)
            {
                sumBeforeShake += deck[i];
            }

            for (int i = 0; i < 8000; i++)
            {
                Random random = new Random();
                int indexFrom = random.Next(0, (deckSize - 1));
                int indexTo = random.Next(0, (deckSize - 1));
                int temp = deck[indexFrom];
                deck[indexFrom] = deck[indexTo];
                deck[indexTo] = temp;
            }

            //calculate checksum of shaked deck
            int sumAfterShake = 0;
            for (int i = 0; i < deckSize; i++)
            {
                sumAfterShake += deck[i];
            }

            if (sumBeforeShake != sumAfterShake)
                throw new Exception("Bad shaking!");
            return deck;
        }

        public void PrintDeck()
        {
            for (int i = 0; i < _deckSize; i++)
            {
                Console.WriteLine(ToString(decks[i]));
            }
        }
    }
}
