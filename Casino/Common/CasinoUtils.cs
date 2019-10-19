using System;

namespace Casino.Common
{
    public static class CasinoUtils
    {
        public static void GetBet(Player plr, ref int bet)
        {
            Console.WriteLine($"You have ${plr.Amount}. Please, input your bet:");
            while (bet == 0)
            {
                try
                {
                    bet = int.Parse(Console.ReadLine());
                    if (bet > plr.Amount)
                    {
                        Console.WriteLine("You don't have enough money for that bet. Please enter another amount:");
                        bet = 0;
                    }
                    else if (bet <= 0)
                    {
                        Console.WriteLine("Bet must have positive value. Please enter another amount:");
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Your input is incorrect. Please, input your bet using the numbers:");
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Your bet is too large. Please, input correct bet.");
                }
            }
        }
    }
}