using System;
namespace Casino
{
    public class Slot
    {
        private const int numberOfReels = 3;
        public Reel[] reels = new Reel[numberOfReels];
        public Slot()
        {
            for (int i = 0; i < numberOfReels; i++)
            {
                reels[i] = new Reel();
            }
        }
    }
}
