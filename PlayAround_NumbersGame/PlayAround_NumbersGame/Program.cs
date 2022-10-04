using System;

namespace PlayAround_NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
            EndOfGame();
        }
        private static void StartGame()
        {
            Console.Clear();
            Random rand = new Random();
            Console.WriteLine("Välkommen, låt oss spela ett spel. Välj svårighetsgrad mellan 1-5:");
            while (true)
            {
                int userDifficulty = CheckIfInt();
                switch (userDifficulty)
                {
                    case 1:
                        Difficulty(1, 20, 5);
                        break;
                    case 2:
                        Difficulty(1, 30, 6);
                        break;
                    case 3:
                        Difficulty(1, 55, 7);
                        break;
                    case 4:
                        Difficulty(1, 75, 8);
                        break;
                    case 5:
                        Difficulty(1, 100, 10);
                        break;
                    default:
                        Console.WriteLine("Du måste skriva ett heltal mellan 1-5");
                        break;
                }
            }
        }
        private static void Difficulty(int low, int high, int timesGuess)
        {
            Console.Clear();
            Random rand = new Random();
            int number = rand.Next(low, high);
            Console.WriteLine("Jag tänker på ett nummer mellan {0} och {1}. Kan du gissa vilket? Du får {2} försök.", low, high, timesGuess);
            CheckGuess(number, timesGuess);
        }
        private static void CheckGuess(int number, int timesGuess)
        {
            for (int i = 1; i <= timesGuess; i++)
            {
                int userGuess = CheckIfInt();
                if (userGuess == number)
                {
                    ResposeWin();
                    EndOfGame();
                }
                else if (userGuess < number)
                {
                    ResponseLow();
                }
                else if (userGuess > number)
                {
                    ResponseHigh();
                }
            }
            Console.WriteLine("Tyvärr du lyckades inte gissa talet på fem försök!");
            EndOfGame();
        }
        private static void EndOfGame()
        {
            Console.WriteLine("Vill du spela igen? (ja/nej)");
            string restart = Console.ReadLine();
            while (true)
            {
                if (restart == "ja")
                {
                    StartGame();
                }
                else if (restart == "nej")
                {
                    Console.WriteLine("Spelet avslutas");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Du måste skriva ja eller nej, försök igen");
                }
            }
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
        private static void ResposeWin()
        {
            Random randResponse = new Random();
            string[] responseWin = new string[5];
            responseWin[0] = "Grattis du gissade rätt!";
            responseWin[1] = "Whooho du vann!";
            responseWin[2] = "Bra jobbat! Du gissade rätt!";
            responseWin[3] = "Awesome, rätt nummer!";
            responseWin[4] = "YES! Helt rätt!";
            int indexWin = randResponse.Next(responseWin.Length);
            Console.WriteLine(responseWin[indexWin]);
        }
        private static void ResponseLow()
        {
            Random randResponse = new Random();
            string[] responseLow = new string[5];
            responseLow[0] = "Nope, det var för lågt";
            responseLow[1] = "Du måste gissa högre";
            responseLow[2] = "Bra gissat men det var för lågt";
            responseLow[3] = "Nej nej, högre";
            responseLow[4] = "Nope, du behöver gissa högre än så";
            int indexLow = randResponse.Next(responseLow.Length);
            Console.WriteLine(responseLow[indexLow]);
        }
        private static void ResponseHigh()
        {
            Random randResponse = new Random();
            string[] responseHigh = new string[5];
            responseHigh[0] = "Nope, det var för högt!";
            responseHigh[1] = "Du måste gissa lägre";
            responseHigh[2] = "Bra gissat men det var för högt";
            responseHigh[3] = "Haha, nej nej lägre";
            responseHigh[4] = "Kunde ha varit, men det är lägre än så";
            int indexHigh = randResponse.Next(responseHigh.Length);
            Console.WriteLine(responseHigh[indexHigh]);
        }
    }
}
