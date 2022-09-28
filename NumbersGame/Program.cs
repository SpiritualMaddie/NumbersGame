using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int x = 1;
            int y = 20;
            int timesGuess = 5;
            int number = rand.Next(x, y);
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan {0} och {1}. Kan du gissa vilket? Du får {2} försök.", x, y, timesGuess);
            CheckGuess(number, timesGuess);
        }
        private static void CheckGuess(int number, int timesGuess)
        {
            for (int i = 1; i <= timesGuess; i++)
            {
                int userGuess = CheckIfInt();
                if (userGuess == number)
                {
                    Console.WriteLine("Woho! Du gjorde! \nTryck Enter för att avsluta");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else if (userGuess < number)
                {
                    Console.WriteLine("Tyvärr du gissade för lågt!");
                }
                else if (userGuess > number)
                {
                    Console.WriteLine("Tyvärr du gissade för högt!");
                }
            }
            Console.WriteLine("Tyvärr du lyckades inte gissa talet på fem försök!");
            Console.WriteLine("Programmet kommer att avslutas när du trycker på Enter");
            Console.ReadKey();
            Environment.Exit(0);
        }
        private static int CheckIfInt()
        {
            int userInt;
            while (!Int32.TryParse(Console.ReadLine(), out userInt))
            {
                Console.WriteLine("Du måste skriva in ett heltal, försök igen.");
            }
            return userInt;
        }
    }
}
