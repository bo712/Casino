using System;
using System.Collections.Generic;

namespace Casino.BlackJack
{
    class BlackJackGame
    {
        private readonly Player _player;
        private int _bet;
        private readonly Deck52 _gameDeck = new Deck52();
        private readonly List<int> _playersHand = new List<int>();
        private readonly List<int> _croupiersHand = new List<int>();

        public BlackJackGame(Player player)
        {
            this._player = player;
        }

        internal void StartGame()
        {
            CasinoUtils.GetBet(_player, ref _bet);
            DealCardsToPlayer();
            DealCardsToCroupier();
            PrintPlayersHand();
            PrintCroupiersHand();
            ChooseWinner();
            MainMenu.ChooseGame(_player);
        }

        private void ChooseWinner()
        {
            var playersHandPoints = _gameDeck.CalculatePoints(_playersHand);
            var croupiersHandPoints = _gameDeck.CalculatePoints(_croupiersHand);
            Console.WriteLine($"You have {playersHandPoints}, croupier has {croupiersHandPoints}.");

            if ((playersHandPoints > 21) ||
                ((playersHandPoints <= croupiersHandPoints) && (croupiersHandPoints <= 21)))
            {
                _player.Amount -= _bet;
                Console.WriteLine($"\nYou LOSE! Your new amount ${_player.Amount}.\n");
                return;
            }
            _player.Amount += _bet;
            Console.WriteLine($"\nYou WON! Your new amount ${_player.Amount}.\n");
        }

        private void DealCardsToCroupier()
        {
            while (_gameDeck.CalculatePoints(_croupiersHand) < 17)
            {
                _croupiersHand.Add(_gameDeck.GetCard(_gameDeck));
            }
            Console.WriteLine(_gameDeck.CalculatePoints(_croupiersHand));
        }

        private void DealCardsToPlayer()
        {
            _playersHand.Add(_gameDeck.GetCard(_gameDeck));
            _playersHand.Add(_gameDeck.GetCard(_gameDeck));
            PrintPlayersHand();
            for (var i = 0; i < 11; i++) //maximum number of cards in player's hand can be 11. If more - it's more than 21 point
            {
                Console.WriteLine("Do you need more cards? Press ENTER if yes, or ESC if no.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
                DealOneCardToPlayer();
            }

        }

        private void DealOneCardToPlayer()
        {
            _playersHand.Add(_gameDeck.GetCard(_gameDeck));
            PrintPlayersHand();
        }

        private void PrintPlayersHand()
        {
            Console.WriteLine("\nYour cards:");
            foreach (var card in _playersHand)
            {
                Console.WriteLine(_gameDeck.ToString(card));
            }
        }

        private void PrintCroupiersHand()
        {
            Console.WriteLine("\nCroupier's cards:");
            foreach (var card in _croupiersHand)
            {
                Console.WriteLine(_gameDeck.ToString(card));
            }
        }
    }
}
