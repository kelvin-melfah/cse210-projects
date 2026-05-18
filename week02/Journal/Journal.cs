using System.IO;

public class Journal
{
  private List<Entry> _entries;

  public Journal()
  {
    _entries = new List<Entry>();
  }

  
  public void AddEntry(Entry entry)
  {
    _entries.Add(entry);
  }

  /// <summary>
  /// Displays all entries in the journal to the console.
  /// </summary>
  public void DisplayAll()
  {
    if (_entries.Count == 0)
    {
      Console.WriteLine("No entries yet. Start writing!");
      return;
    }

    Console.WriteLine(new string('=', 50));
    Console.WriteLine("  YOUR JOURNAL");
    Console.WriteLine(new string('=', 50));

    foreach (Entry entry in _entries)
    {
      entry.Display();
    }
  }

  /// <summary>
  /// Saves all journal entries to the given filename using '|' as a field separator.
  /// </summary>
  public void SaveToFile(string filename)
  {
    using (StreamWriter outputFile = new StreamWriter(filename))
    {
      foreach (Entry entry in _entries)
      {
        outputFile.WriteLine(entry.ToFileLine());
      }
    }

    Console.WriteLine($"Journal saved to '{filename}' ({_entries.Count} entries).");
  }

  /// <summary>
  /// Loads journal entries from the given filename, replacing any existing entries.
  /// </summary>
  public void LoadFromFile(string filename)
  {
    if (!File.Exists(filename))
    {
      Console.WriteLine($"Error: File '{filename}' not found.");
      return;
    }

    _entries.Clear();

    string[] lines = File.ReadAllLines(filename);
    int loaded = 0;

    foreach (string line in lines)
    {
      if (string.IsNullOrWhiteSpace(line)) continue;

      try
      {
        Entry entry = Entry.FromFileLine(line);
        _entries.Add(entry);
        loaded++;
      }
      catch (FormatException ex)
      {
        Console.WriteLine($"Skipping malformed line: {ex.Message}");
      }
    }

    Console.WriteLine($"Loaded {loaded} entries from '{filename}'.");
  }
}