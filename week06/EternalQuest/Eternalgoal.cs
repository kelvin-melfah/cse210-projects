using System;

// A goal that never finishes, like reading scriptures every day.
// Every time the user records it, they get points, but it's never
// marked as "complete" since it's meant to go on forever.
public class EternalGoal : Goal
{
  public EternalGoal(string shortName, string description, int points)
      : base(shortName, description, points)
  {
  }

  public override int RecordEvent()
  {
    // Eternal goals always give points — there's no end state.
    return Points;
  }

  public override bool IsComplete()
  {
    // By definition, eternal goals are never "complete".
    return false;
  }

  public override string GetStringRepresentation()
  {
    // Format: EternalGoal:ShortName,Description,Points
    return $"EternalGoal:{ShortName},{Description},{Points}";
  }
}