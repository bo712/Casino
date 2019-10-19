using System;
using System.Threading;
using Casino.Common;

namespace Casino.Slot
{
    public class SlotGame
    {
        private const int Bet = 10;
        private const int Prize = 1000;
        private readonly Player _player;
        private readonly Slot _slot;

        public SlotGame(Player player)
        {
            this._player = player;
            this._slot = new Slot();
        }

        public void StartGame()
        {
            while (true)
            {
                if (_player.Amount < Bet)
                {
                    PrintNoMoney();
                    break;
                }

                _player.Amount -= Bet;
                _slot.RunSlot();

                if (_slot.isWin())
                {
                    _player.Amount += Prize + Bet;
                    PrintWin();
                }
                else
                {
                    PrintLose();
                }

                Console.WriteLine("Press SPACE button to continue or any other key to finish the game.");
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    MainMenu.ChooseGame(_player);
                }
            }

            MainMenu.ChooseGame(_player);
        }

        private void PrintWin()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"------------------You WON ${Prize}!!!------------------\n");
            Console.WriteLine($"Your new amount is ${_player.Amount}\n");
            Console.WriteLine("------------------Let's play more!------------------\n");
            Thread.Sleep(2000);
            Console.ResetColor();
        }

        private void PrintLose()
        {
            Console.WriteLine("You LOSE!!!");
            Console.WriteLine($"Your new amount is ${_player.Amount}");
        }

        private static void PrintNoMoney()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have no money for one more bet!");
            Console.ResetColor();
        }
    }
}