using System;
using System.Threading;

namespace Casino
{
    public class MainMenu
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            var name = Console.ReadLine();
            if (name.Trim() == "") name = "Mister X";

            Player player = new Player(name);
            ChooseGame(player);
        }

        public static void ChooseGame(Player player)
        {
            Console.WriteLine("Choose the game: ");
            Console.WriteLine("1 - Slot (One hand bandit);");
            Console.WriteLine("2 - Drunkard;");
            Console.WriteLine("0 - Exit;");
            var choose = Console.ReadLine().Trim();
            Console.WriteLine();

            switch (choose)
            {
                case "1":
                    SlotGame slotGame = new SlotGame(player);
                    slotGame.StartGame();
                    break;
                case "2":
                    DrunkardGame drunkardGame = new DrunkardGame(player);
                    drunkardGame.StartGame();
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
    }
}
