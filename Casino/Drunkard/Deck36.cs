using Casino.Common;

namespace Casino.Drunkard
{
    public class Deck36 : Deck
    {
        public Deck36()
        {
            DeckSize = 36;
            FillDeck(Cards, DeckSize);
            ShakeDeck(Cards);
        }

        public Par36 GetPar(int cardNumber)
        {
            return (Par36) (cardNumber % (DeckSize / 4));
        }

        public override string ToString(int cardNumber)
        {
            return GetPar(cardNumber) + " " + GetSuit(cardNumber, Cards);
        }
    }
}