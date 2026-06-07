using System;

public class BreathingActivity : Activity
{
  public BreathingActivity()
      : base(
          "Breathing Activity",
          "This activity will help you relax by walking you through breathing in\n" +
          "  and out slowly. Clear your mind and focus on your breathing.")
  {
  }

  public void Run()
  {
    DisplayStartingMessage();

    DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
    bool breathingIn = true;

    while (DateTime.Now < endTime)
    {
      if (breathingIn)
      {
        Console.Write("\n  Breathe in...");
        ShowBreathAnimation(4, breathingIn: true);
      }
      else
      {
        Console.Write("\n  Breathe out...");
        ShowBreathAnimation(6, breathingIn: false);
      }
      breathingIn = !breathingIn;
    }

    DisplayEndingMessage();
  }
}