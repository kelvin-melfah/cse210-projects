using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
  // Exceeds requirements: shuffle prompts & questions so none repeat until all used
  private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you overcame a fear.",
        "Think of a time when you supported a friend through hardship."
    };

  private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "Who else was positively affected by your actions?"
    };

  private List<string> _promptPool;
  private List<string> _questionPool;
  private Random _random = new Random();

  public ReflectionActivity()
      : base(
          "Reflection Activity",
          "This activity will help you reflect on times in your life when you have\n" +
          "  shown strength and resilience. This will help you recognize the power\n" +
          "  you have and how you can use it in other aspects of your life.")
  {
    _promptPool = new List<string>(_prompts);
    _questionPool = new List<string>(_questions);
  }

  private string GetRandomPrompt()
  {
    if (_promptPool.Count == 0) _promptPool = new List<string>(_prompts);
    int idx = _random.Next(_promptPool.Count);
    string prompt = _promptPool[idx];
    _promptPool.RemoveAt(idx);
    return prompt;
  }

  private string GetRandomQuestion()
  {
    if (_questionPool.Count == 0) _questionPool = new List<string>(_questions);
    int idx = _random.Next(_questionPool.Count);
    string question = _questionPool[idx];
    _questionPool.RemoveAt(idx);
    return question;
  }

  public void Run()
  {
    DisplayStartingMessage();

    Console.WriteLine($"\n  Consider the following prompt:\n");
    Console.WriteLine($"  --- {GetRandomPrompt()} ---\n");
    Console.WriteLine("  When you have an experience in mind, press Enter to continue...");
    Console.ReadLine();

    Console.WriteLine("\n  Now ponder each of the following questions as they are");
    Console.WriteLine("  displayed. There is no right answer — just reflect.\n");

    DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

    while (DateTime.Now < endTime)
    {
      Console.WriteLine($"\n  > {GetRandomQuestion()}");
      ShowSpinner(5);
    }

    DisplayEndingMessage();
  }
}