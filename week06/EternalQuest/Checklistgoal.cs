using System;

// A goal that needs to be done a set number of times before it's
// considered complete, like going to the temple 10 times. Each
// time it's recorded the user gets some points, and once they hit
// the target count they get a bonus on top.
public class ChecklistGoal : Goal
{
  // How many times the goal has been completed so far.
  private int _amountCompleted;

  // How many times it needs to be done in total.
  private int _target;

  // Extra points awarded once the target is reached.
  private int _bonus;

  public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted = 0)
      : base(shortName, description, points)
  {
    _target = target;
    _bonus = bonus;
    _amountCompleted = amountCompleted;
  }

  public override int RecordEvent()
  {
    // No use racking up extra counts past the target.
    if (_amountCompleted >= _target)
    {
      return 0;
    }

    _amountCompleted++;

    // If this event pushed us over the finish line, add the bonus
    // on top of the regular points for this event.
    if (_amountCompleted == _target)
    {
      return Points + _bonus;
    }

    return Points;
  }

  public override bool IsComplete()
  {
    return _amountCompleted >= _target;
  }

  public override string GetDetailsString()
  {
    // Adds the "Completed x/y times" part on top of the base
    // checkbox display so the user can see their progress.
    string check = IsComplete() ? "X" : " ";
    return $"[{check}] {ShortName} ({Description}) -- Completed {_amountCompleted}/{_target} times";
  }

  public override string GetStringRepresentation()
  {
    // Format: ChecklistGoal:ShortName,Description,Points,Target,Bonus,AmountCompleted
    return $"ChecklistGoal:{ShortName},{Description},{Points},{_target},{_bonus},{_amountCompleted}";
  }
}