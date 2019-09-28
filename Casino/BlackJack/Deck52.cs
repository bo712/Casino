using System;
namespace Casino
{
    public class Deck52 : Deck
    {
        public new static int deckSize;
        public new int[] cards;
        public int pointer;

        public Deck52()
        {
            deckSize = 52;
            cards = new int[deckSize];
            FillDeck(cards);
            ShakeDeck(cards);
            pointer = deckSize - 1;
        }

        public static Par52 GetPar(int cardNumber)
        {
            return (Par52)(cardNumber % (deckSize / 4));
        }

        public override string ToString(int cardNumber)
        {
            return GetPar(cardNumber) + " " + GetSuit(cardNumber, deckSize);
        }

        public static int GetCard(Deck52 deck)
        {
            return deck.cards[deck.pointer--];
        }
    }
}
