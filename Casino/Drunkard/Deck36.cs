using System;

namespace Casino
{
    public class Deck36 : Deck
    {
        public Deck36()
        {
            deckSize = 36;
            FillDeck(cards, deckSize);
            ShakeDeck(cards);
        }

        public Par36 GetPar(int cardNumber)
        {
            return (Par36)(cardNumber % (deckSize / 4));
        }

        public override string ToString(int cardNumber)
        {
            return GetPar(cardNumber) + " " + GetSuit(cardNumber, cards);
        }
    }
}
