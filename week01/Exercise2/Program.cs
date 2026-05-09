using System;

class Program
{
    static void Main(string[] args)
    {
        // -------------------------------------------------------
        // Ask the user for their grade percentage
        // -------------------------------------------------------
        Console.Write("Enter your grade percentage (0-100): ");
        int grade = int.Parse(Console.ReadLine());
 
        
        string letter;
 
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
 
        // -------------------------------------------------------
        // Stretch Challenge 1:
        // Determine the "+" or "-" sign based on the last digit.
        //   last digit >= 7  →  "+"
        //   last digit <  3  →  "-"
        //   otherwise        →  "" (no sign)
        //
        // The remainder operator (%) gives us the last digit:
        //   e.g. 84 % 10 = 4,  91 % 10 = 1,  77 % 10 = 7
        // -------------------------------------------------------
        int lastDigit = grade % 10;
        string sign;
 
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }
 
        // -------------------------------------------------------
        // Stretch Challenge 2:
        // There is no "A+" grade — only A or A-.
        // If the letter is A and the sign is "+", remove the sign.
        // -------------------------------------------------------
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
 
        // -------------------------------------------------------
        // Stretch Challenge 3:
        // There is no "F+" or "F-" grade — only F.
        // If the letter is F, always remove the sign.
        // -------------------------------------------------------
        if (letter == "F")
        {
            sign = "";
        }
 
        
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
 
        
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("You did not pass this time. Keep working hard — you'll get it next time!");
        }
    }
}