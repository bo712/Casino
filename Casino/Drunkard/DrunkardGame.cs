using System;
using System.Collections.Generic;

namespace Casino
{
    internal class DrunkardGame
    {
        private Player player;
        private Deck gameDeck;
        private readonly int _deckSize = 36;

        private Queue<int> playersCards;
        private Queue<int> croupiersCards;

        public DrunkardGame(Player player)
        {
            this.player = player;
            this.gameDeck = new Deck(_deckSize);
            playersCards = new Queue<int>(_deckSize / 2);
            croupiersCards = new Queue<int>(_deckSize / 2);
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
                Console.WriteLine($"Ваша карта - {gameDeck.ToString(playersCard)}");
                Console.WriteLine($"Карта крупье - {gameDeck.ToString(croupiersCard)}");

                if (playersCard % (_deckSize / 4) > croupiersCard % (_deckSize / 4))
                {
                    Console.WriteLine("Крупье забирает карты.\n");
                    for (int i = 0; i < decksOnDesk.Count; i++)
                    {
                        croupiersCards.Enqueue(decksOnDesk[i]);
                    }
                    decksOnDesk.Clear();
                }
                else if (playersCard % (_deckSize / 4) < croupiersCard % (_deckSize / 4))
                {
                    Console.WriteLine("Вы забираете карты.\n");
                    for (int i = decksOnDesk.Count - 1; i >= 0; i--)
                    {
                        playersCards.Enqueue(decksOnDesk[i]);
                    }
                    decksOnDesk.Clear();
                }
                else
                {
                    Console.WriteLine("Спор! Выкладываем ещё по одной карте.");
                    continue;
                }
                Console.WriteLine($"У Вас {playersCards.Count} карт");
                Console.WriteLine($"У крупье {croupiersCards.Count} карт");
            }
            Console.WriteLine("Конец игры!");

        }

        private void HandOutCards()
        {
            gameDeck.decks = gameDeck.FillDeck(gameDeck.decks, _deckSize);
            gameDeck.decks = gameDeck.ShakeDeck(gameDeck.decks, _deckSize);
            gameDeck.PrintDeck();
            for (int i = 0; i < _deckSize - 1; i += 2)
            {
                playersCards.Enqueue(gameDeck.decks[i]);
            }
            for (int i = 1; i < _deckSize; i += 2)
            {
                croupiersCards.Enqueue(gameDeck.decks[i]);
            }
        }
    }
}
