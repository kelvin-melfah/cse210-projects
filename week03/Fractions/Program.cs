using System;

class Program
{
    static void Main(string[] args)
    {// Program.cs — Entry point for the Fractions project

        // --- Constructor 1: No parameters → 1/1 ---
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        // --- Constructor 2: One parameter → 6/1 ---
        Fraction fraction2 = new Fraction(6);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        // --- Constructor 3: Two parameters → 3/4 ---
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
        // --- Constructor 3: Two parameters → 1/3 ---
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        // --- Demonstrating Getters and Setters ---
        Fraction fraction5 = new Fraction(2, 5);
        Console.WriteLine($"\nBefore change: {fraction5.GetFractionString()}");

        fraction5.SetNumerator(7);
        fraction5.SetDenominator(8);
        Console.WriteLine($"After change:  {fraction5.GetFractionString()}");
        Console.WriteLine($"Numerator: {fraction5.GetNumerator()}");
        Console.WriteLine($"Denominator: {fraction5.GetDenominator()}");
    }
}
