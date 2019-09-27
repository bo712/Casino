using System;
using System.Threading;

namespace Casino
{
    public class SlotGame
    {
        private const int bet = 10;
        private const int prize = 1000;
        Player player;
        Slot slot;

        public SlotGame(Player player)
        {
            this.player = player;
            this.slot = new Slot();
        }

        public void StartGame()
        {
            while (true)
            {
                if (player.Amount < bet)
                {
                    PrintNoMoney();
                    break;
                }
                player.Amount -= bet;
                slot.RunSlot();

                if (slot.isWin())
                {
                    player.Amount += prize + bet;
                    PrintWin();
                }
                else
                {
                    PrintLose();
                }

                Console.WriteLine("Press SPACE button to continue or any other key to finish the game.");
                ConsoleKeyInfo choose = Console.ReadKey();
                Console.WriteLine();
                if (choose.KeyChar == ' ') continue;
                MainMenu.ChooseGame(player);
            }
            MainMenu.ChooseGame(player);

        }

        private void PrintWin()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"------------------You WON ${prize}!!!------------------\n");
            Console.WriteLine($"Your new amount is ${player.Amount}\n");
            Console.WriteLine("------------------Let's play more!------------------\n");
            Thread.Sleep(2000);
            Console.ResetColor();
        }

        private void PrintLose()
        {
            Console.WriteLine("You LOSE!!!");
            Console.WriteLine($"Your new amount is ${player.Amount}");
        }

        private void PrintNoMoney()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have no money for one more bet!");
            Console.ResetColor();
        }
    }
}
