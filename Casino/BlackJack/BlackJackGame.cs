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
        private List<int> playersHand = new List<int>();
        private List<int> croupiersHand = new List<int>();

        public BlackJackGame(Player player)
        {
            this.player = player;
        }

        internal void StartGame()
        {
            CasinoUtils.GetBet(player, ref bet);
            DealCardsToPlayer();
            DealCardsToCroupier();
            PrintPlayersHand(playersHand);
            PrintCroupiersHand(croupiersHand);
            ChooseWinner();
            MainMenu.ChooseGame(player);
        }

        private void ChooseWinner()
        {
            int playersHandPoints = Deck52.CalculatePoints(playersHand);
            int croupiersHandPoints = Deck52.CalculatePoints(croupiersHand);
            Console.WriteLine($"You have {playersHandPoints}, croupier has {croupiersHandPoints}.");
            if ((playersHandPoints > 21) ||
                ((playersHandPoints <= croupiersHandPoints) && (croupiersHandPoints <= 21)))
            {
                player.Amount -= bet;
                Console.WriteLine($"\nYou LOSE! Your new amount ${player.Amount}.\n");
                return;
            }
            player.Amount += bet;
            Console.WriteLine($"\nYou WON! Your new amount ${player.Amount}.\n");
        }

        private void DealCardsToCroupier()
        {
            while (Deck52.CalculatePoints(croupiersHand) < 20)
            {
                croupiersHand.Add(Deck52.GetCard(gameDeck));
            }
            Console.WriteLine(Deck52.CalculatePoints(croupiersHand));
        }

        private void DealCardsToPlayer()
        {
            playersHand.Add(Deck52.GetCard(gameDeck));
            playersHand.Add(Deck52.GetCard(gameDeck));
            PrintPlayersHand(playersHand);
            for (int i = 0; i < 5; i++) //maximum number of cards in player's hand can be 7. If more - it's more than 21 point
            {
                Console.WriteLine("Do you need more cards? Press ENTER if yes, or ESC if no.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
                DealOneCardToPlayer();
            }

        }

        private void DealOneCardToPlayer()
        {
            playersHand.Add(Deck52.GetCard(gameDeck));
            PrintPlayersHand(playersHand);
        }

        private void PrintPlayersHand(List<int> plrsCards)
        {
            Console.WriteLine("\nYour cards:");
            foreach (var card in plrsCards)
            {
                Console.WriteLine(gameDeck.ToString(card));
            }
        }

        private void PrintCroupiersHand(List<int> crprsCards)
        {
            Console.WriteLine("\nCroupier's cards:");
            foreach (var card in crprsCards)
            {
                Console.WriteLine(gameDeck.ToString(card));
            }
        }
    }
}
