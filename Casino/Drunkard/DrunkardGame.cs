using System;
using System.Collections.Generic;

namespace Casino
{
    internal class DrunkardGame
    {
        private Player player;
        private Deck gameDeck;
        private readonly int _deckSize = 36;
        private int Bet { get; set; }

        private Queue<int> playersCards;
        private Queue<int> croupiersCards;

        public DrunkardGame(Player player)
        {
            this.player = player;
            this.gameDeck = new Deck(_deckSize);

            playersCards = new Queue<int>();
            croupiersCards = new Queue<int>();
            Console.WriteLine($"You have ${player.Amount}. Please, input your bet:");
            Bet = GetBet(player);
        }

        private int GetBet(Player player)
        {
            int bet = int.Parse(Console.ReadLine());
            if (bet > player.Amount)
            {
                Console.WriteLine("You don't have enough money for that bet. Please enter another amount:");
                bet = GetBet(player);
            }
            return bet;
        }

        internal void RunDrunkard()
        {
            HandOutCards();
            var decksOnDesk = new List<int>();
            while (playersCards.Count != 0 && croupiersCards.Count != 0)
            {
                var playersCard = playersCards.Dequeue();
                var croupiersCard = croupiersCards.Dequeue();
                decksOnDesk.Add(playersCard);
                decksOnDesk.Add(croupiersCard);
                Console.WriteLine($"Your card - {gameDeck.ToString(playersCard)}");
                Console.WriteLine($"Croupier's card - {gameDeck.ToString(croupiersCard)}");

                if (playersCard % (_deckSize / 4) > croupiersCard % (_deckSize / 4))
                {
                    Console.WriteLine("Croupier takes the cards.\n");
                    for (int i = 0; i < decksOnDesk.Count; i++)
                    {
                        croupiersCards.Enqueue(decksOnDesk[i]);
                    }
                    decksOnDesk.Clear();
                }
                else if (playersCard % (_deckSize / 4) < croupiersCard % (_deckSize / 4))
                {
                    Console.WriteLine("You take the cards.\n");
                    for (int i = decksOnDesk.Count - 1; i >= 0; i--)
                    {
                        playersCards.Enqueue(decksOnDesk[i]);
                    }
                    decksOnDesk.Clear();
                }
                else
                {
                    Console.WriteLine("\nDispute! Everybody puts one more card on the table.\n");
                    continue;
                }
                Console.WriteLine($"You have {playersCards.Count} cards");
                Console.WriteLine($"Croupier has {croupiersCards.Count} cards");
            }
            EndGame(playersCards, croupiersCards);

        }

        private void HandOutCards()
        {
            gameDeck.decks = gameDeck.FillDeck(gameDeck.decks, _deckSize);
            gameDeck.decks = gameDeck.ShakeDeck(gameDeck.decks, _deckSize);
            //gameDeck.PrintDeck();
            for (int i = 0; i < _deckSize - 1; i += 2)
            {
                playersCards.Enqueue(gameDeck.decks[i]);
            }
            for (int i = 1; i < _deckSize; i += 2)
            {
                croupiersCards.Enqueue(gameDeck.decks[i]);
            }
        }

        private void EndGame(Queue<int> playersCards, Queue<int> croupiersCards)
        {
            if (playersCards.Count > croupiersCards.Count)
            {
                player.Amount += Bet;
                Console.WriteLine($"\nYou WON! Your new amount ${player.Amount}.\n");
                MainMenu.ChooseGame(player);
            }
            else
            {
                player.Amount -= Bet;
                Console.WriteLine($"\nYou LOSE! Your new amount ${player.Amount}.\n");
                MainMenu.ChooseGame(player);
            }
        }
    }
}
