using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        Console.WriteLine("Welcome to your Personal Journal!");

        bool running = true;

        while (running)
        {
            DisplayMenu(journal);
            string choice = Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, generator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye! Keep journaling.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter 1–5.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    static void DisplayMenu(Journal journal)
    {
        Console.WriteLine(new string('=', 40));
        Console.WriteLine("         JOURNAL MENU");
        Console.WriteLine(new string('=', 40));
        Console.WriteLine("  1. Write a new entry");
        Console.WriteLine("  2. Display journal");
        Console.WriteLine("  3. Save journal to file");
        Console.WriteLine("  4. Load journal from file");
        Console.WriteLine("  5. Quit");
        Console.WriteLine(new string('=', 40));
        Console.Write("What would you like to do? ");
    }

    static void WriteNewEntry(Journal journal, PromptGenerator generator)
    {
        string prompt = generator.GetRandomPrompt();
        string date = DateTime.Now.ToShortDateString();

        Console.WriteLine($"\nDate: {date}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("> ");

        string response = Console.ReadLine() ?? "";

        // --- Mood tracking ---
        Console.Write("How would you rate your mood today? (1 = rough, 5 = great): ");
        string moodInput = Console.ReadLine()?.Trim() ?? "";
        if (int.TryParse(moodInput, out int mood) && mood >= 1 && mood <= 5)
        {
            response = $"{response} [Mood: {mood}/5]";
        }
        // --------------------------------------------

        Entry entry = new Entry(date, prompt, response);
        journal.AddEntry(entry);

        Console.WriteLine("Entry saved!");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save (e.g., myjournal.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "journal.txt";

        if (string.IsNullOrEmpty(filename))
            filename = "journal.txt";

        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load (e.g., myjournal.txt): ");
        string filename = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrEmpty(filename))
        {
            Console.WriteLine("No filename entered. Load cancelled.");
            return;
        }

        journal.LoadFromFile(filename);
    }
}
