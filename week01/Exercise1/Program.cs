public static class Program
{
    public static void Main()
    {
        // Plan for testing:
        // 1. Part 1: call MultiplesOf with the example from the instructions (3, 5)
        //    and one more of my own (7, 5), then print them to compare with what I expect.
        // 2. Part 2: call RotateListRight on a fresh 1-9 list for each case: the two
        //    examples from the instructions (amount 5 and amount 3) plus the edge case
        //    where amount equals data.Count.
        // 3. Each rotation test gets its own new list. RotateListRight changes the list
        //    in place, so reusing one list would make each test start from the
        //    previous test's result and the output would be confusing.

        // ----- Part 1: MultiplesOf -----

        // Expected: 3, 6, 9, 12, 15 (the example straight from the instructions)
        double[] multiples1 = Arrays.MultiplesOf(3, 5);
        Console.WriteLine(string.Join(", ", multiples1));

        // Expected: 7, 14, 21, 28, 35
        double[] multiples2 = Arrays.MultiplesOf(7, 5);
        Console.WriteLine(string.Join(", ", multiples2));

        // ----- Part 2: RotateListRight -----

        // Expected: 5, 6, 7, 8, 9, 1, 2, 3, 4
        List<int> rotateBy5 = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(rotateBy5, 5);
        Console.WriteLine(string.Join(", ", rotateBy5));

        // Expected: 7, 8, 9, 1, 2, 3, 4, 5, 6
        List<int> rotateBy3 = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(rotateBy3, 3);
        Console.WriteLine(string.Join(", ", rotateBy3));

        // Edge case: amount equals the list size, so it's a full rotation and the
        // list should come out unchanged. Expected: 1, 2, 3, 4, 5, 6, 7, 8, 9
        List<int> rotateBy9 = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(rotateBy9, 9);
        Console.WriteLine(string.Join(", ", rotateBy9));
    }
}

public static class Arrays
{
    public static double[] MultiplesOf(double number, int count)
    {
        double[] multiples = new double[count];
        for (int i = 0; i < count; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        if (data.Count == 0)
        {
            return;
        }

        amount = ((amount % data.Count) + data.Count) % data.Count;
        if (amount == 0)
        {
            return;
        }

        data.Reverse();
        data.Reverse(0, amount);
        data.Reverse(amount, data.Count - amount);
    }
}