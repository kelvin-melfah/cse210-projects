public class PromptGenerator
{
  private List<string> _prompts;
  private Random _random;

  public PromptGenerator()
  {
    _random = new Random();

    _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something I learned today that surprised me?",
            "What am I most grateful for today?",
            "What challenged me today, and how did I respond?",
            "Describe a moment today where I felt most like myself.",
            "What is one thing I want to remember about today?",
            "How did I take care of myself (or others) today?"
        };
  }

  /// <summary>
  /// Returns a random prompt from the list.
  /// </summary>
  public string GetRandomPrompt()
  {
    int index = _random.Next(_prompts.Count);
    return _prompts[index];
  }
}
