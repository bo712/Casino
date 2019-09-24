using System;
namespace Casino
{
    public class Slot
    {
        public static int numberOfReels = 3;
        public Reel[] reels = new Reel[numberOfReels];

        public Slot()
        {
            for (int i = 0; i < numberOfReels; i++)
            {
                reels[i] = new Reel();
            }
        }

        public void RunSlot()
        {
            int getEffort = new Random().Next(293, 4500);

            foreach (var item in this.reels)
            {
                item.CurrentPosition = (item.CurrentPosition + (getEffort / item.RotationSpeed)) % Reel.numberOfPositions;
            }

            PrintReels();
        }

        private void PrintReels()
        {
            Console.Write("Result: ");
            for (int i = 0; i < numberOfReels; i++)
            {
                Console.Write($"{this.reels[i].CurrentPosition} ");
            }
            Console.WriteLine();
        }

        public bool isWin()
        {
            bool isReelsEqual = true;
            for (int i = 1; i < numberOfReels; i++)
            {
                if (this.reels[i].CurrentPosition != this.reels[i - 1].CurrentPosition)
                {
                    isReelsEqual = false;
                    break;
                }
            }
            return isReelsEqual;
        }
    }
}
