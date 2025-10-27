using System;

class Program
{
    static void Main(string[] args)
    {
        // Radom Generator
        Random randomGenerator = new Random();
        
        // Vars
        int number = 0;
        int guess = 0;
        bool continueLoop = true; 

        while (continueLoop)
        {
            // Generate Random Number 1-100
            number = randomGenerator.Next(1, 101);

            // Welcome Intro
            Console.WriteLine("I'm thinking of a number between 1 and 100");

            // Allow User to guess
            do
            {
                // Guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                // Higher
                if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                // Lower
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                // Correct
                else
                {
                    Console.WriteLine("You guessed it!");
                }

            } while (guess != number);

            // Do you want to play again?
            Console.Write("Do you want to play again? (y/n) ");
            string playAgain = Console.ReadLine();

            // Set to lowercase
            playAgain = playAgain.Substring(0, 1).ToLower();

            // Quit
            if (playAgain == "n")
            {
                // End outer loop
                continueLoop = false;
            }
        
        }
    
    }
}