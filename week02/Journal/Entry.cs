public class Entry
{
  private string _date;
  private string _promptText;
  private string _entryText;

  public Entry(string date, string promptText, string entryText)
  {
    _date = date;
    _promptText = promptText;
    _entryText = entryText;
  }

  // Getters for use when saving to file
  public string GetDate() => _date;
  public string GetPromptText() => _promptText;
  public string GetEntryText() => _entryText;

  /// <summary>
  /// Displays the entry in a formatted way to the console.
  /// </summary>
  public void Display()
  {
    Console.WriteLine($"Date: {_date}");
    Console.WriteLine($"Prompt: {_promptText}");
    Console.WriteLine($"Entry: {_entryText}");
    Console.WriteLine(new string('-', 50));
  }

  /// <summary>
  /// Serializes the entry to a single line using '|' as a separator.
  /// Replaces any '|' characters in content to avoid corruption.
  /// </summary>
  public string ToFileLine()
  {
    string safeDate = _date.Replace("|", "[pipe]");
    string safePrompt = _promptText.Replace("|", "[pipe]");
    string safeEntry = _entryText.Replace("|", "[pipe]");
    return $"{safeDate}|{safePrompt}|{safeEntry}";
  }

  /// <summary>
  /// Creates an Entry object from a line read from the journal file.
  /// </summary>
  public static Entry FromFileLine(string line)
  {
    string[] parts = line.Split('|');
    if (parts.Length < 3)
      throw new FormatException($"Invalid entry line: {line}");

    string date = parts[0].Replace("[pipe]", "|");
    string prompt = parts[1].Replace("[pipe]", "|");
    string entryText = parts[2].Replace("[pipe]", "|");

    return new Entry(date, prompt, entryText);
  }
}
