using System;
namespace Casino
{
    public class Player
    {
        public int Amount { get; set; }

        public Player()
        {
            Amount = new Random().Next(100, 950);
            Console.WriteLine($"You have ${Amount} for game!\n");
        }
    }
}
