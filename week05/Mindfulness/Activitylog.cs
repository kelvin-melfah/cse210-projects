using System;
using System.Collections.Generic;
using System.IO;


// Tracks every completed activity with date, name, and duration.
// Saves to "mindfulness_log.txt" and loads it on startup.

public class ActivityLog
{
  private const string LogFile = "mindfulness_log.txt";
  private List<string> _entries = new List<string>();

  public ActivityLog()
  {
    Load();
  }

  public void RecordActivity(string activityName, int durationSeconds)
  {
    string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm}  |  {activityName,-22}  |  {durationSeconds,3}s";
    _entries.Add(entry);
    Save();
  }

  public void Display()
  {
    Console.Clear();
    Console.WriteLine("\n  ╔══════════════════════════════════════════════════╗");
    Console.WriteLine("  ║              Activity Log                        ║");
    Console.WriteLine("  ╚══════════════════════════════════════════════════╝\n");

    if (_entries.Count == 0)
    {
      Console.WriteLine("  No activities recorded yet.\n");
    }
    else
    {
      Console.WriteLine("  Date & Time          Activity                  Duration");
      Console.WriteLine("  " + new string('─', 58));
      foreach (var entry in _entries)
        Console.WriteLine($"  {entry}");
      Console.WriteLine($"\n  Total sessions: {_entries.Count}");
    }

    Console.WriteLine("\n  Press Enter to return to the menu...");
    Console.ReadLine();
  }

  private void Save()
  {
    try { File.WriteAllLines(LogFile, _entries); }
    catch { /* silently fail if file system unavailable */ }
  }

  private void Load()
  {
    if (File.Exists(LogFile))
    {
      try { _entries.AddRange(File.ReadAllLines(LogFile)); }
      catch { }
    }
  }
}