using System;

class Program
{
    static void Main(string[] args)
    {
        // Scripture Memorizer
        // ─────────────────────────────────────────────────────────────────────────────
        // Description:
        //   Displays a scripture and progressively hides words so the user can practice
        //   memorization. The user presses Enter to hide more words or types "quit" to exit.


        // Build a small scripture library
        List<Scripture> library = new List<Scripture>
{
    new Scripture(
        new Reference("Mark", 10, 27),
        "With man this is impossible but not with God for all things are possible with God"
    ),
    new Scripture(
        new Reference("Proverbs", 3, 5, 6),
        "Trust in the Lord with all your heart and lean not on your own understanding in all your ways acknowledge him and he will make your paths straight"
    ),
    new Scripture(
        new Reference("John", 3, 16),
        "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life"
    ),
    new Scripture(
        new Reference("Philippians", 4, 13),
        "I can do all this through him who gives me strength"
    ),
};

        // Pick a random scripture from the library
        Random rng = new Random();
        Scripture scripture = library[rng.Next(library.Count)];

        // Main loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Progress indicator (stretch feature)
            // Count visible words by checking display text — if it starts with '_' it is hidden
            int totalWords = scripture.GetDisplayText()
                                      .Split('\n')[1]
                                      .Split(' ')
                                      .Length;

            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words hidden — great work! Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            Console.Write("Press Enter to hide more words, or type 'quit' to exit: ");
            string input = Console.ReadLine() ?? "";

            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }

    }
}