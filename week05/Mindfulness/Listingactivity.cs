using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
  private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are things that bring you joy?",
        "What are blessings you have received recently?"
    };

  private List<string> _promptPool;
  private Random _random = new Random();

  public ListingActivity()
      : base(
          "Listing Activity",
          "This activity will help you reflect on the good things in your life\n" +
          "  by having you list as many things as you can in a certain area.")
  {
    _promptPool = new List<string>(_prompts);
  }

  private string GetRandomPrompt()
  {
    if (_promptPool.Count == 0) _promptPool = new List<string>(_prompts);
    int idx = _random.Next(_promptPool.Count);
    string prompt = _promptPool[idx];
    _promptPool.RemoveAt(idx);
    return prompt;
  }

  public void Run()
  {
    DisplayStartingMessage();

    Console.WriteLine($"\n  List as many responses as you can to the following prompt:\n");
    Console.WriteLine($"  --- {GetRandomPrompt()} ---\n");

    Console.Write("  You may begin in: ");
    ShowCountdown(5);
    Console.WriteLine();

    int count = 0;
    DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

    while (DateTime.Now < endTime)
    {
      Console.Write("  > ");
      string item = Console.ReadLine();
      if (!string.IsNullOrWhiteSpace(item))
        count++;
    }

    Console.WriteLine($"\n  You listed {count} items!");
    DisplayEndingMessage();
  }
}