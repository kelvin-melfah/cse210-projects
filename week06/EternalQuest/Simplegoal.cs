using System;

// A goal that can be completed one time, like running a marathon.
// Once it's done, it's done — recording it again doesn't give more points.
public class SimpleGoal : Goal
{
  // Tracks whether the goal has already been completed.
  private bool _isComplete;

  public SimpleGoal(string shortName, string description, int points, bool isComplete = false)
      : base(shortName, description, points)
  {
    _isComplete = isComplete;
  }

  public override int RecordEvent()
  {
    // If it's already done, no extra points — just let the user know.
    if (_isComplete)
    {
      return 0;
    }

    _isComplete = true;
    return Points;
  }

  public override bool IsComplete()
  {
    return _isComplete;
  }

  public override string GetStringRepresentation()
  {
    // Format: SimpleGoal:ShortName,Description,Points,IsComplete
    return $"SimpleGoal:{ShortName},{Description},{Points},{_isComplete}";
  }
}