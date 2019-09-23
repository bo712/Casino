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

        public void RunSlot()
        {
            while (player.Amount >= bet)
            {
                Thread.Sleep(200);
                player.Amount -= bet;
                int getEffort = new Random().Next(40, 4500);
                foreach (var item in slot.reels)
                {
                    item.CurrentPosition = (item.CurrentPosition + (getEffort / item.RotationSpeed)) % Reel.numberOfPositions;
                }

                Console.WriteLine($"Result: {slot.reels[0].CurrentPosition} - {slot.reels[1].CurrentPosition} - {slot.reels[2].CurrentPosition}");

                if (slot.reels[0].CurrentPosition == slot.reels[1].CurrentPosition && slot.reels[0].CurrentPosition == slot.reels[2].CurrentPosition)
                {
                    WinEvent();
                }
                else
                {
                    Console.WriteLine("You LOSE!!!");
                    Console.WriteLine($"Your new amount is ${player.Amount}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nHey, {player.Name}! You have no money for one more bet! GAME OVER!");

        }

        private void WinEvent()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("------------------You WON!!!------------------\n");
            Thread.Sleep(3000);
            player.Amount += prize;
            Console.WriteLine($"Your new amount is ${player.Amount}\n");
            Thread.Sleep(2000);
            Console.WriteLine("Let's play more!\n");
            Thread.Sleep(2000);
            Console.ResetColor();
        }
    }
}
