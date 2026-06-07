using System;
using System.Threading;

public class Activity
{
  private string _name;
  private string _description;
  private int _duration;

  public Activity(string name, string description)
  {
    _name = name;
    _description = description;
  }

  // ── Getters ────────────────────────────────────────────────────────────────
  public string GetName() => _name;
  public int GetDuration() => _duration;

  // ── Common start / end messages ────────────────────────────────────────────
  public void DisplayStartingMessage()
  {
    Console.Clear();
    Console.WriteLine($"\n  ╔══════════════════════════════════════╗");
    Console.WriteLine($"  ║  Welcome to the {_name,-20}║");
    Console.WriteLine($"  ╚══════════════════════════════════════╝\n");
    Console.WriteLine($"  {_description}\n");

    Console.Write("  How many seconds would you like for the session? ");
    _duration = int.Parse(Console.ReadLine());

    Console.WriteLine("\n  Get ready to begin...");
    ShowSpinner(3);
    Console.Clear();
  }

  public void DisplayEndingMessage()
  {
    Console.WriteLine("\n  Well done!!");
    ShowSpinner(3);
    Console.WriteLine($"\n  You have completed {_duration} seconds of the {_name}.");
    ShowSpinner(3);
  }

  // ── Shared animation helpers ───────────────────────────────────────────────
  public void ShowSpinner(int seconds)
  {
    string[] frames = { "|", "/", "-", "\\" };
    int totalFrames = seconds * 6; // ~6 frames per second
    Console.Write("  ");
    for (int i = 0; i < totalFrames; i++)
    {
      Console.Write(frames[i % frames.Length]);
      Thread.Sleep(160);
      Console.Write("\b");
    }
    Console.Write(" \b");
  }

  public void ShowCountdown(int seconds)
  {
    for (int i = seconds; i > 0; i--)
    {
      Console.Write($"  {i} ");
      Thread.Sleep(1000);
      // Erase the digits we wrote
      Console.Write($"\b\b\b\b    \b\b\b\b");
    }
  }

  // Expanding/contracting text animation used by breathing
  public void ShowBreathAnimation(int seconds, bool breathingIn)
  {
    string[] inFrames = { "o", "O", "( )", "( O )", "(  O  )", "(   O   )", "(    O    )" };
    string[] outFrames = { "(    O    )", "(   O   )", "(  O  )", "( O )", "( )", "O", "o" };
    string[] frames = breathingIn ? inFrames : outFrames;

    int pausePerFrame = (seconds * 1000) / frames.Length;

    foreach (var frame in frames)
    {
      // Clear current line
      Console.Write("\r" + new string(' ', 30) + "\r");
      Console.Write($"  {frame}");
      Thread.Sleep(pausePerFrame);
    }
    Console.WriteLine();
  }
}