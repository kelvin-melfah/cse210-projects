using System;

class Program
{
    static void Main(string[] args)
    {
        // Greet the user first
        DisplayWelcome();

        // Ask for the user's name and hang onto it
        string name = PromptUserName();

        // Ask for their favorite number and hang onto it
        int number = PromptUserNumber();

        // Square that number
        int squared = SquareNumber(number);

        // Show the final result using both pieces of info we collected
        DisplayResult(name, squared);
    }

    // -------------------------------------------------------
    // Prints a simple welcome message to the console.
    // It doesn't need any input and doesn't return anything.
    // -------------------------------------------------------
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // -------------------------------------------------------
    // Asks the user to type their name, then hands it back
    // to whoever called this function as a string.
    // -------------------------------------------------------
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // -------------------------------------------------------
    // Asks the user to type their favorite number, converts
    // the text they typed into an integer, and returns it.
    // -------------------------------------------------------
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // -------------------------------------------------------
    // Takes a number, multiplies it by itself, and returns
    // the result. It doesn't talk to the user at all —
    // it just does the math and hands the answer back.
    // -------------------------------------------------------
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // -------------------------------------------------------
    // Takes the user's name and their squared number and
    // prints a friendly summary message. No return value needed
    // because its only job is to display something.
    // -------------------------------------------------------
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
