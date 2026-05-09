using System;

class Program
{
    static void Main(string[] args)
    {
        // This list will hold every number the user enters (except 0).
        List<double> numbers = new List<double>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Keep asking for numbers until the user types 0.
        // We use a while(true) loop and break out of it manually
        // once we see the sentinel value 0.
        while (true)
        {
            Console.Write("Enter number: ");
            double input = double.Parse(Console.ReadLine());

            // 0 is our stop signal — don't add it to the list
            if (input == 0)
            {
                break; // exit the loop, we're done collecting numbers
            }

            numbers.Add(input);
        }

        // Safety check: if no numbers were entered, there's nothing to compute
        if (numbers.Count == 0)
        {
            Console.WriteLine("You didn't enter any numbers. Goodbye!");
            return;
        }

       
        double sum = 0;
        foreach (double number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

       
        double average = sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

       
        double largest = numbers[0]; // start by assuming the first number is the biggest
        foreach (double number in numbers)
        {
            if (number > largest)
            {
                largest = number; // found something bigger, update our record
            }
        }
        Console.WriteLine($"The largest number is: {largest}");

        // -------------------------------------------------------
        // Stretch Challenge 1: Smallest positive number
        // A "positive number" is anything greater than zero.
        // We want the one that is closest to zero (but still above it).
        // -------------------------------------------------------

        // Filter the list down to only positive numbers
        List<double> positiveNumbers = new List<double>();
        foreach (double number in numbers)
        {
            if (number > 0)
            {
                positiveNumbers.Add(number);
            }
        }

        if (positiveNumbers.Count > 0)
        {
            // Start by assuming the first positive number is the smallest positive
            double smallestPositive = positiveNumbers[0];
            foreach (double number in positiveNumbers)
            {
                if (number < smallestPositive)
                {
                    smallestPositive = number; // found a smaller one, update
                }
            }
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            // It's possible the user entered only negative numbers
            Console.WriteLine("There were no positive numbers in the list.");
        }

        // -------------------------------------------------------
        // Stretch Challenge 2: Sort the list and display it
        // The built-in List.Sort() method arranges numbers from
        // smallest to largest (ascending order) in place.
        // -------------------------------------------------------
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (double number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
