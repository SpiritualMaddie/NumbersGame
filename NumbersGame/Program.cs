// Madde Lundström NET22
using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();                                                                                // Method for starting the game
            EndOfGame();                                                                                // Method for the end of the game
        }
        private static void StartGame()                                                                 // Method for starting the game
        {
            Console.Clear();                                                                            // Clears screen for cleaner look
            Console.WriteLine("Välkommen, låt oss spela ett spel. Välj svårighetsgrad mellan 1-5:");
            while (true)
            {
                int userDifficulty = CheckIfInt();                                                      // Method for error handling
                switch (userDifficulty)                                                                 // Checks what difficulty user choses
                {
                    case 1:
                        Difficulty(1, 20, 5);                                                           // Difficulty 1
                        break;
                    case 2:
                        Difficulty(1, 30, 6);                                                           // Difficulty 2
                        break;
                    case 3:
                        Difficulty(1, 55, 7);                                                           // Difficulty 3
                        break;
                    case 4:
                        Difficulty(1, 75, 8);                                                           // Difficulty 4
                        break;
                    case 5:
                        Difficulty(1, 100, 10);                                                         // Difficulty 5
                        break;
                    default:
                        Console.WriteLine("Du måste skriva ett heltal mellan 1-5");                     // If user inputs anything besides integers 1-5
                        break;
                }
            }
        }
        private static void Difficulty(int low, int high, int timesGuess)                               // Method for choosing difficulty
        {
            Console.Clear();
            Random rand = new Random();                                                                 // Creating a instance of Random class
            int number = rand.Next(low, high);                                                          // Chooses a random number betwwen low and high w. random method
            Console.WriteLine("Jag tänker på ett nummer mellan {0} och {1}. ", low, high);
            Console.WriteLine("Kan du gissa vilket? Du får {0} försök.", timesGuess);
            CheckGuess(number, timesGuess);                                                             // Method checking if the user has guessed correctly
        }                                                                                               // based on chosen difficulty
        private static void CheckGuess(int number, int timesGuess)                                      // Method checking if the user has guessed correctly
        {
            for (int i = 1; i <= timesGuess; i++)                                                       // Loops the amount of guesses based on difficulty
            {
                int userGuess = CheckIfInt();                                                           // Method for error handling        
                if (userGuess == number)                                                                // Checks if user guessed right
                {
                    ResposeWin();                                                                       // Method for responses when winning
                    EndOfGame();                                                                        // Method for the end of the game
                }
                else if (userGuess < number)                                                            // Checks if user guessed too low
                {
                    ResponseLow();                                                                      // Method for responses when guess was too low
                }
                else if (userGuess > number)                                                            // Checks if user guessed too high
                {
                    ResponseHigh();                                                                     // Method for responses when guess was too high
                }
            }
            Console.WriteLine("Tyvärr du lyckades inte gissa talet på {0} försök!", timesGuess);        // Writes if the user didnt guess after (TimesGuess) tries
            EndOfGame();                                                                                // Method for the end of the game
        }
        private static void EndOfGame()                                                                 // Method for the end of the game
        {
            Console.WriteLine("Vill du spela igen? (ja/nej)");
            while (true)
            {
                string restart = Console.ReadLine();                                                    // Checks if the user wants to play again
                if (restart == "ja")
                {
                    StartGame();                                                                        // If yes then restart game
                }
                else if (restart == "nej")
                {
                    Console.WriteLine("Spelet avslutas");
                    Environment.Exit(0);                                                                // If no the program ends
                }
                else
                {
                    Console.WriteLine("Du måste skriva ja eller nej, försök igen");                     // If anything else the user has to try again
                }
            }
        }
        private static int CheckIfInt()                                                                 // Method for error handling
        {
            int userInt;
            while (!Int32.TryParse(Console.ReadLine(), out userInt))                                    // Checks if user input is an integer
            {
                Console.WriteLine("Du måste skriva in ett heltal, försök igen.");                       // If not the user has to try again
            }
            return userInt;                                                                             // Returns user input if an integer
        }
        private static void ResposeWin()                                                                // Method for responses when winning
        {
            Random randResponse = new Random();                                                         // Creating a instance of Random class
            string[] responseWin = new string[5];                                                       // String array of responses
            responseWin[0] = "Grattis du gissade rätt!";
            responseWin[1] = "Whooho du vann!";
            responseWin[2] = "Bra jobbat! Du gissade rätt!";
            responseWin[3] = "Awesome, rätt nummer!";
            responseWin[4] = "YES! Helt rätt!";
            int indexWin = randResponse.Next(responseWin.Length);                                       // Chooses a random index in the array w. random method
            Console.WriteLine(responseWin[indexWin]);                                                   // to write out a random response message
        }
        private static void ResponseLow()                                                               // Method for responses when guess was too low
        {
            Random randResponse = new Random();                                                         // Creating a instance of Random class
            string[] responseLow = new string[5];                                                       // String array of responses
            responseLow[0] = "Nope, det var för lågt";
            responseLow[1] = "Du måste gissa högre";
            responseLow[2] = "Bra gissat men det var för lågt";
            responseLow[3] = "Nej nej, högre";
            responseLow[4] = "Nope, du behöver gissa högre än så";
            int indexLow = randResponse.Next(responseLow.Length);                                       // Chooses a random index in the array w. random method
            Console.WriteLine(responseLow[indexLow]);                                                   // to write out a random response message
        }
        private static void ResponseHigh()                                                              // Method for responses when guess was too high
        {
            Random randResponse = new Random();                                                         // Creating a instance of Random class
            string[] responseHigh = new string[5];                                                      // String array of responses
            responseHigh[0] = "Nope, det var för högt";
            responseHigh[1] = "Du måste gissa lägre";
            responseHigh[2] = "Bra gissat men det var för högt";
            responseHigh[3] = "Haha, nej nej lägre";
            responseHigh[4] = "Kunde ha varit, men det är lägre än så";
            int indexHigh = randResponse.Next(responseHigh.Length);                                     // Chooses a random index in the array w. random method
            Console.WriteLine(responseHigh[indexHigh]);                                                 // to write out a random response message
        }
    }
}
