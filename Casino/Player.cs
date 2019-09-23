using System;
namespace Casino
{
    public class Player
    {
        public string Name { get; private set; }
        public int Amount { get; set; }

        public Player(string name)
        {
            Name = name;
            Amount = new Random().Next(100, 950);
            Console.WriteLine($"\nSo, {Name}, you have ${Amount} for game!\n");
        }
    }
}
