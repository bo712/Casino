using System;
using System.Collections.Generic;
using System.Threading;

namespace Casino
{
    public class DrunkardGame
    {
        private Player player = null;
        private int bet = 0;
        private Deck gameDeck = new Deck();
        private Queue<int> playersCards = new Queue<int>();
        private Queue<int> croupiersCards = new Queue<int>();

        public DrunkardGame(Player player)
        {
            this.player = player;
            Console.WriteLine($"You have ${player.Amount}. Please, input your bet:");
            GetBet();
        }

        internal void StartGame()
        {
            var decksOnDesk = new List<int>();
            DealingCards();

            while (playersCards.Count != 0 && croupiersCards.Count != 0)
            {
                int playersCard;
                int croupiersCard;
                ShowDown(decksOnDesk, out playersCard, out croupiersCard);

                if (playersCard % (Deck.deckSize / 4) > croupiersCard % (Deck.deckSize / 4))
                {
                    CroupierTakes(decksOnDesk);
                }
                else if (playersCard % (Deck.deckSize / 4) < croupiersCard % (Deck.deckSize / 4))
                {
                    PlayerTakes(decksOnDesk);
                }
                else
                {
                    Console.WriteLine("\nDispute! Everybody puts one more card on the table.\n");
                    continue;
                }
                Console.WriteLine($"You have {playersCards.Count} cards");
                Console.WriteLine($"Croupier has {croupiersCards.Count} cards");
            }
            EndGame();
            MainMenu.ChooseGame(player);

        }

        private void GetBet()
        {
            while (bet == 0)
            {
                try
                {
                    bet = int.Parse(Console.ReadLine());
                    if (bet > player.Amount)
                    {
                        Console.WriteLine("You don't have enough money for that bet. Please enter another amount:");
                        bet = 0;
                    }
                    else if (bet <= 0)
                    {
                        Console.WriteLine("Bet must have positive value. Please enter another amount:");
                    }

                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Your input is incorrect. Please, input your bet using the numbers:");
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Your bet is too large. Please, input correct bet.");
                }
            }
        }

        private void PlayerTakes(List<int> decksOnDesk)
        {
            Console.WriteLine("You take the cards.\n");
            for (int i = decksOnDesk.Count - 1; i >= 0; i--)
            {
                playersCards.Enqueue(decksOnDesk[i]);
            }
            decksOnDesk.Clear();
        }

        private void CroupierTakes(List<int> decksOnDesk)
        {
            Console.WriteLine("Croupier takes the cards.\n");
            for (int i = 0; i < decksOnDesk.Count; i++)
            {
                croupiersCards.Enqueue(decksOnDesk[i]);
            }
            decksOnDesk.Clear();
        }

        private void ShowDown(List<int> decksOnDesk, out int playersCard, out int croupiersCard)
        {
            playersCard = playersCards.Dequeue();
            croupiersCard = croupiersCards.Dequeue();
            decksOnDesk.Add(playersCard);
            decksOnDesk.Add(croupiersCard);
            Console.WriteLine($"Your card - {gameDeck.ToString(playersCard)}");
            Console.WriteLine($"Croupier's card - {gameDeck.ToString(croupiersCard)}");
            Thread.Sleep(100);
        }

        private void DealingCards()
        {
            for (int i = 0; i < Deck.deckSize - 1; i += 2)
            {
                playersCards.Enqueue(gameDeck.cards[i]);
            }
            for (int i = 1; i < Deck.deckSize; i += 2)
            {
                croupiersCards.Enqueue(gameDeck.cards[i]);
            }
        }

        private void EndGame()
        {
            if (playersCards.Count < croupiersCards.Count)
            {
                player.Amount += bet;
                Console.WriteLine($"\nYou WON! Your new amount ${player.Amount}.\n");
            }
            else
            {
                player.Amount -= bet;
                Console.WriteLine($"\nYou LOSE! Your new amount ${player.Amount}.\n");
            }
        }
    }
}
