using System;
using System.Collections.Generic;
using System.Threading;
using Casino.Common;

namespace Casino.Drunkard
{
    public class DrunkardGame
    {
        private readonly Player _player;
        private int _bet;
        private readonly Deck36 _gameDeck = new Deck36();
        private readonly Queue<int> _playersCards = new Queue<int>();
        private readonly Queue<int> _croupiersCards = new Queue<int>();

        public DrunkardGame(Player player)
        {
            _player = player;
        }

        internal void StartGame()
        {
            CasinoUtils.GetBet(_player, ref _bet);
            var decksOnDesk = new List<int>();
            DealingCards();

            while (_playersCards.Count != 0 && _croupiersCards.Count != 0)
            {
                ShowDown(decksOnDesk, out var playersCard, out var croupiersCard);

                if (playersCard % (_gameDeck.DeckSize / 4) > croupiersCard % (_gameDeck.DeckSize / 4))
                {
                    CroupierTakes(decksOnDesk);
                }
                else if (playersCard % (_gameDeck.DeckSize / 4) < croupiersCard % (_gameDeck.DeckSize / 4))
                {
                    PlayerTakes(decksOnDesk);
                }
                else
                {
                    Console.WriteLine("\nDispute! Everybody puts one more card on the table.\n");
                    continue;
                }

                Console.WriteLine($"You have {_playersCards.Count} cards");
                Console.WriteLine($"Croupier has {_croupiersCards.Count} cards");
            }

            EndGame();
            MainMenu.ChooseGame(_player);
        }

        private void PlayerTakes(IList<int> decksOnDesk)
        {
            Console.WriteLine("You take the cards.\n");
            for (var i = decksOnDesk.Count - 1; i >= 0; i--)
            {
                _playersCards.Enqueue(decksOnDesk[i]);
            }

            decksOnDesk.Clear();
        }

        private void CroupierTakes(IList<int> decksOnDesk)
        {
            Console.WriteLine("Croupier takes the cards.\n");
            foreach (var t in decksOnDesk)
            {
                _croupiersCards.Enqueue(t);
            }

            decksOnDesk.Clear();
        }

        private void ShowDown(List<int> decksOnDesk, out int playersCard, out int croupiersCard)
        {
            playersCard = _playersCards.Dequeue();
            croupiersCard = _croupiersCards.Dequeue();
            decksOnDesk.Add(playersCard);
            decksOnDesk.Add(croupiersCard);
            Console.WriteLine($"Your card - {_gameDeck.ToString(playersCard)}");
            Console.WriteLine($"Croupier's card - {_gameDeck.ToString(croupiersCard)}");
            Thread.Sleep(100);
        }

        private void DealingCards()
        {
            for (var i = 0; i < _gameDeck.DeckSize - 1; i += 2)
            {
                _playersCards.Enqueue(_gameDeck.Cards[i]);
            }

            for (var i = 1; i < _gameDeck.DeckSize; i += 2)
            {
                _croupiersCards.Enqueue(_gameDeck.Cards[i]);
            }
        }

        private void EndGame()
        {
            if (_playersCards.Count < _croupiersCards.Count)
            {
                _player.Amount += _bet;
                Console.WriteLine($"\nYou WON! Your new amount ${_player.Amount}.\n");
            }
            else
            {
                _player.Amount -= _bet;
                Console.WriteLine($"\nYou LOSE! Your new amount ${_player.Amount}.\n");
            }
        }
    }
}