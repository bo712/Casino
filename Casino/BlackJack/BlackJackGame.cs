using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class BlackJackGame
    {
        private Player player;
        private int bet;
        private Deck52 gameDeck = new Deck52();
        private List<int> playersCards = new List<int>();
        private List<int> croupiersCards = new List<int>();

        public BlackJackGame(Player player)
        {
            this.player = player;
        }

        internal void StartGame()
        {
            CasinoUtils.GetBet(player, ref bet);
            DealCardsToPlayer();
            DealCardsToCroupier();
        }

        private void DealCardsToCroupier()
        {
            croupiersCards.Add(Deck52.GetCard(gameDeck));
            croupiersCards.Add(Deck52.GetCard(gameDeck));

        }

        private void DealCardsToPlayer()
        {
            playersCards.Add(Deck52.GetCard(gameDeck));
            playersCards.Add(Deck52.GetCard(gameDeck));
            PrintPlayersCards(playersCards);
            for (int i = 0; i < 5; i++) //maximum number of cards in player's hand can be 7. If more - it's more than 21 point
            {
                Console.WriteLine("Do you need more cards? Press ENTER if yes, or ESC if no");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
                DealOneCardToPlayer();
            }
        }

        private void DealOneCardToPlayer()
        {
            playersCards.Add(Deck52.GetCard(gameDeck));
            PrintPlayersCards(playersCards);
        }

        private void PrintPlayersCards(List<int> plrsCards)
        {
            Console.WriteLine("Your cards:");
            foreach (var card in plrsCards)
            {
                Console.WriteLine(gameDeck.ToString(card));
            }
        }
    }
}
