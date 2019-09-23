using System;

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

            Console.WriteLine("Choose the game: ");
            Console.WriteLine("1 - Slot (One hand bandit);");
            Console.WriteLine("2 - Drunkard;");
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
            }
        }
    }
}
