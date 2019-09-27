using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class BlackJackGame
    {
        private Player player = null;
        private int bet = 0;
        private Deck52 gameDeck = new Deck52();

        public BlackJackGame(Player player)
        {
            this.player = player;
        }
        internal void StartGame()
        {
            for (int i = 0; i < gameDeck.cards.Length; i++)
            {
                Console.WriteLine(gameDeck.ToString(i));
            }
            
        }
    }
}
