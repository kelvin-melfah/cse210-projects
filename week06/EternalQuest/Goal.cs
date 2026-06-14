using System;

// This is our base class for all goal types. It holds the stuff every
// goal needs (name, description, points) and a couple of methods that
// the child classes will customize for their own behavior.
public abstract class Goal
{
  // Keeping these private so nothing outside the class can mess with
  // them directly. We expose what we need through properties below.
  private string _shortName;
  private string _description;
  private int _points;

  public string ShortName
  {
    get { return _shortName; }
    set { _shortName = value; }
  }

  public string Description
  {
    get { return _description; }
    set { _description = value; }
  }

  public int Points
  {
    get { return _points; }
    set { _points = value; }
  }

  public Goal(string shortName, string description, int points)
  {
    _shortName = shortName;
    _description = description;
    _points = points;
  }

  // Every goal type needs to know how many points to hand out
  // when the user records progress on it. Each subclass figures
  // this out differently, so we make it abstract.
  public abstract int RecordEvent();

  // Lets us check whether a goal is finished. Simple goals can be
  // completed, eternal goals never are, and checklist goals are
  // done once they hit their target count.
  public abstract bool IsComplete();

  // Used when printing out the goal list, e.g. "[X] Run a Marathon"
  // or "[ ] Run a Marathon". Subclasses override this if they need
  // to show extra info, like progress on a checklist goal.
  public virtual string GetDetailsString()
  {
    string check = IsComplete() ? "X" : " ";
    return $"[{check}] {_shortName} ({_description})";
  }

  // Turns the goal into a single line of text so we can save it
  // to a file. Each subclass adds whatever extra info it needs
  // (like its current count) to this base string.
  public abstract string GetStringRepresentation();
}