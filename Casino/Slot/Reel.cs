﻿using System;
namespace Casino
{
    public class Reel
    {
        public int RotationSpeed { get; private set; }
        public int CurrentPosition { get; set; }
        public const int numberOfPositions = 7;

        public Reel()
        {
            Random random = new Random();
            RotationSpeed = random.Next(13, 67); //how easy reel rotates
            CurrentPosition = random.Next(0, numberOfPositions);
        }
    }
}
