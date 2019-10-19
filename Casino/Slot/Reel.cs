using System;

namespace Casino.Slot
{
    public class Reel
    {
        public int RotationSpeed { get; private set; }
        public int CurrentPosition { get; set; }
        public const int NumberOfPositions = 7;

        public Reel()
        {
            Random random = new Random();
            RotationSpeed = random.Next(17, 127); //how easy reel rotates
            CurrentPosition = random.Next(0, NumberOfPositions - 1);
        }
    }
}
