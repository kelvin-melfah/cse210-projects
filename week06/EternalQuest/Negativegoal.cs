using System;

// This is one of my "exceeding requirements" additions. A negative
// goal represents a bad habit, like skipping a workout or staying
// up too late. Recording it SUBTRACTS points instead of adding them,
// which gives the user a reason to avoid doing it.
public class NegativeGoal : Goal
{
  public NegativeGoal(string shortName, string description, int points)
      : base(shortName, description, points)
  {
  }

  public override int RecordEvent()
  {
    // Return a negative number so the score goes down when this
    // is recorded. The points value is stored as a positive
    // number, but we flip the sign here.
    return -Points;
  }

  public override bool IsComplete()
  {
    // Bad habits don't really get "completed" — you just try to
    // avoid them. So this always returns false.
    return false;
  }

  public override string GetDetailsString()
  {
    // Show a different marker so it's clear this is a habit to avoid,
    // not a normal goal to check off.
    return $"[!] {ShortName} ({Description}) -- Avoid this one!";
  }

  public override string GetStringRepresentation()
  {
    // Format: NegativeGoal:ShortName,Description,Points
    return $"NegativeGoal:{ShortName},{Description},{Points}";
  }
}