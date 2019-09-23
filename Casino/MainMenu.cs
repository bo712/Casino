using System;
using System.Threading;

namespace Casino
{
    class MainMenu
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
            var choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                default:
                    SlotGame slotGame = new SlotGame(player);
                    slotGame.RunSlot();
                    break;
                case "2":
                    DrunkardGame drunkardGame = new DrunkardGame(player);
                    drunkardGame.RunDrunkard();
                    break;
                case "0":
                    Console.WriteLine("Thank you for your time! Goodbye!");
                    Thread.Sleep(3000);
                    break;
            }
        }
    }
}
