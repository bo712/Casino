using System;
namespace Casino
{
    public class Deck52 : Deck
    {
        public new static int deckSize;
        public new int[] cards;

        public Deck52()
        {
            deckSize = 52;
            cards = new int[deckSize];
            FillDeck(cards);
            ShakeDeck(cards);
        }

        public Par52 GetPar(int cardNumber)
        {
            return (Par52)(cardNumber % (deckSize / 4));
        }

        public override string ToString(int cardNumber)
        {
            return GetPar(cardNumber) + " " + GetSuit(cardNumber, deckSize);
        }
    }
}
