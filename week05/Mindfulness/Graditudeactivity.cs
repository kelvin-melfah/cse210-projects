using System;
using System.Collections.Generic;


// A Gratitude Journaling activity that guides the user through writing a short
// gratitude entry. It prompts with a category (people, experiences, simple things)
// and then asks targeted follow-up questions to deepen their reflection before
// concluding with an affirmation.

public class GratitudeActivity : Activity
{
  private List<string> _categories = new List<string>
    {
        "someone who made your day better recently",
        "a simple pleasure you enjoyed today",
        "a past experience that shaped who you are",
        "something about your health or body you are grateful for",
        "a skill or talent you are glad you have",
        "a place that brings you peace or happiness"
    };

  private List<string> _followUps = new List<string>
    {
        "What specifically about this makes you grateful?",
        "How has this positively changed your life?",
        "How would life be different without this?",
        "Who else benefits because of this gratitude?",
        "How can you express this gratitude to others today?"
    };

  private List<string> _categoryPool;
  private List<string> _followUpPool;
  private Random _random = new Random();

  public GratitudeActivity()
      : base(
          "Gratitude Activity",
          "This activity will help you cultivate a spirit of gratitude by guiding\n" +
          "  you to write a focused gratitude entry. Gratitude has been shown to\n" +
          "  reduce stress and improve overall well-being.")
  {
    _categoryPool = new List<string>(_categories);
    _followUpPool = new List<string>(_followUps);
  }

  private string GetCategory()
  {
    if (_categoryPool.Count == 0) _categoryPool = new List<string>(_categories);
    int idx = _random.Next(_categoryPool.Count);
    string cat = _categoryPool[idx];
    _categoryPool.RemoveAt(idx);
    return cat;
  }

  private string GetFollowUp()
  {
    if (_followUpPool.Count == 0) _followUpPool = new List<string>(_followUps);
    int idx = _random.Next(_followUpPool.Count);
    string fu = _followUpPool[idx];
    _followUpPool.RemoveAt(idx);
    return fu;
  }

  public void Run()
  {
    DisplayStartingMessage();

    string category = GetCategory();
    Console.WriteLine($"\n  Today, focus your gratitude on:\n");
    Console.WriteLine($"  --- {category} ---\n");

    Console.Write("  Take a moment to think, then write what comes to mind: ");
    Console.ReadLine();

    Console.WriteLine("\n  Now go deeper with these follow-up questions:\n");
    DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

    while (DateTime.Now < endTime)
    {
      Console.WriteLine($"\n  * {GetFollowUp()}");
      Console.Write("  Your thoughts: ");
      if (DateTime.Now < endTime)
        Console.ReadLine();
      ShowSpinner(2);
    }

    Console.WriteLine("\n  \"Gratitude turns what we have into enough.\" — Aesop\n");
    DisplayEndingMessage();
  }
}