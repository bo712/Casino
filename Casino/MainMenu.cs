using System;
using System.Threading;
using Casino.BlackJack;
using Casino.Common;
using Casino.Drunkard;
using Casino.Slot;

namespace Casino
{
    public static class MainMenu
    {
        public static void Main(string[] args)
        {
            var player = new Player();
            ChooseGame(player);
        }

        public static void ChooseGame(Player player)
        {
            if (player.Amount == 0)
            {
                NoMoney();
            }

            Console.WriteLine("Choose the game: ");
            Console.WriteLine("1 - Slot (One hand bandit);");
            Console.WriteLine("2 - Drunkard;");
            Console.WriteLine("3 - BlackJack;");
            Console.WriteLine("0 - Exit;");
            var choose = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choose)
            {
                case "1":
                    var slotGame = new SlotGame(player);
                    slotGame.StartGame();
                    break;
                case "2":
                    var drunkardGame = new DrunkardGame(player);
                    drunkardGame.StartGame();
                    break;
                case "3":
                    var bj = new BlackJackGame(player);
                    bj.StartGame();
                    break;
                case "0":
                    Console.WriteLine("Thank you for your time! Goodbye!");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You  entered wrong value, so you will play in Slot");
                    goto case "1";
            }
        }

        private static void NoMoney()
        {
            Console.WriteLine("You totally gambled away your money. Goodbye!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}