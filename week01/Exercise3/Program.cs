using System;

class Program
{
    static void Main(string[] args)
    {
        // We'll use this variable to control the outer "play again" loop.
        // Setting it to "yes" right away so the game starts at least once.
        string playAgain = "yes";

        // -------------------------------------------------------
        // Stretch Challenge 2: Play Again Loop
        // Keep the whole game running as long as the player says yes.
        // -------------------------------------------------------
        while (playAgain == "yes")
        {
           
            Random random = new Random();
            int magicNumber = random.Next(1, 101); // Next(1, 101) gives us 1–100 inclusive

            // Stretch Challenge 1: track how many guesses the player makes
            int guessCount = 0;

            Console.WriteLine("\nI'm thinking of a number between 1 and 100...");

            // Start the player's first guess at something that won't accidentally
            // match the magic number before the loop even begins.
            int guess = -1;

            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                // Count every guess the player makes
                guessCount++;

               
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    // guess == magicNumber, so the loop will end after this
                    Console.WriteLine("You guessed it!");
                }
            }

            // ---------------------------------------------------
            // Stretch Challenge 1: Tell the player how many guesses
            // it took them to find the magic number.
            // ---------------------------------------------------
            Console.WriteLine($"It took you {guessCount} guess{(guessCount == 1 ? "" : "es")} to get it right.");

            // ---------------------------------------------------
            // Stretch Challenge 2: Ask if they want to play again.
            // We read their answer and let the outer while loop decide
            // whether to keep going or exit.
            // ---------------------------------------------------
            Console.Write("\nWould you like to play again? (yes / no): ");
            playAgain = Console.ReadLine().Trim().ToLower();
        }

        Console.WriteLine("\nThanks for playing — see you next time!");
    }
}
