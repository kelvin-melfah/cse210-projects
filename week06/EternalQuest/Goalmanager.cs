using System;
using System.Collections.Generic;
using System.IO;

// This class is the "brain" of the program. It keeps track of all the
// goals, the user's score, and handles saving/loading everything to
// a file. It also runs the menu loop that the user interacts with.
public class GoalManager
{
  private List<Goal> _goals;
  private int _score;

  // Extra feature for exceeding requirements: tracking a "level"
  // based on the user's total score. Every 1000 points earns a
  // new level, kind of like an RPG.
  private int _level;

  public GoalManager()
  {
    _goals = new List<Goal>();
    _score = 0;
    _level = 1;
  }

  // Main menu loop. Keeps showing options until the user chooses to quit.
  public void Start()
  {
    bool quit = false;

    while (!quit)
    {
      Console.WriteLine();
      Console.WriteLine($"You have {_score} points. You are Level {_level}!");
      Console.WriteLine();
      Console.WriteLine("Menu Options:");
      Console.WriteLine("  1. Create New Goal");
      Console.WriteLine("  2. List Goals");
      Console.WriteLine("  3. Save Goals");
      Console.WriteLine("  4. Load Goals");
      Console.WriteLine("  5. Record Event");
      Console.WriteLine("  6. Quit");
      Console.Write("Select a choice from the menu: ");

      string choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          CreateGoal();
          break;
        case "2":
          ListGoalDetails();
          break;
        case "3":
          SaveGoals();
          break;
        case "4":
          LoadGoals();
          break;
        case "5":
          RecordEvent();
          break;
        case "6":
          quit = true;
          break;
        default:
          Console.WriteLine("That's not one of the options. Try again.");
          break;
      }
    }
  }

  // Walks the user through creating a new goal of whatever type they pick.
  private void CreateGoal()
  {
    Console.WriteLine("The types of goals are:");
    Console.WriteLine("  1. Simple Goal");
    Console.WriteLine("  2. Eternal Goal");
    Console.WriteLine("  3. Checklist Goal");
    Console.WriteLine("  4. Negative Goal (bad habit)");
    Console.Write("Which type of goal would you like to create? ");
    string typeChoice = Console.ReadLine();

    Console.Write("What is the name of your goal? ");
    string name = Console.ReadLine();

    Console.Write("What is a short description of it? ");
    string description = Console.ReadLine();

    Console.Write("What is the amount of points associated with this goal? ");
    int points = int.Parse(Console.ReadLine());

    switch (typeChoice)
    {
      case "1":
        _goals.Add(new SimpleGoal(name, description, points));
        break;
      case "2":
        _goals.Add(new EternalGoal(name, description, points));
        break;
      case "3":
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int target = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int bonus = int.Parse(Console.ReadLine());
        _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        break;
      case "4":
        _goals.Add(new NegativeGoal(name, description, points));
        break;
      default:
        Console.WriteLine("That's not a valid goal type.");
        return;
    }

    Console.WriteLine("Goal created!");
  }

  // Prints out every goal with its checkbox / progress info.
  private void ListGoalDetails()
  {
    Console.WriteLine("The goals are:");

    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }
  }

  // Lets the user pick a goal and records that they did it,
  // updating the score (and level) based on what that goal returns.
  private void RecordEvent()
  {
    if (_goals.Count == 0)
    {
      Console.WriteLine("You don't have any goals yet. Go create one!");
      return;
    }

    ListGoalDetails();
    Console.Write("Which goal did you accomplish? ");
    int choice = int.Parse(Console.ReadLine());

    // Make sure the user picked a real goal before going further.
    if (choice < 1 || choice > _goals.Count)
    {
      Console.WriteLine("That's not a valid goal number.");
      return;
    }

    Goal selectedGoal = _goals[choice - 1];
    int pointsEarned = selectedGoal.RecordEvent();

    _score += pointsEarned;

    // Let the user know what happened. A negative number means
    // they lost points from a bad habit.
    if (pointsEarned >= 0)
    {
      Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
    }
    else
    {
      Console.WriteLine($"Oof. You lost {Math.Abs(pointsEarned)} points for that one. Better luck next time!");
    }

    UpdateLevel();

    // If a checklist goal just hit its target, give a little extra
    // celebration since that's a big milestone.
    if (selectedGoal is ChecklistGoal && selectedGoal.IsComplete())
    {
      Console.WriteLine("Congratulations! You have completed this goal and earned a bonus!");
    }
  }

  // Checks the score against the level thresholds and lets the
  // user know if they've leveled up. Every 1000 points = 1 level.
  private void UpdateLevel()
  {
    int newLevel = (_score / 1000) + 1;

    if (newLevel > _level)
    {
      _level = newLevel;
      Console.WriteLine($"*** Level up! You are now Level {_level}! ***");
    }
  }

  // Saves the score, level, and every goal's string representation
  // to a text file, one item per line.
  private void SaveGoals()
  {
    Console.Write("What is the file name for the goal file? ");
    string filename = Console.ReadLine();

    using (StreamWriter outputFile = new StreamWriter(filename))
    {
      outputFile.WriteLine(_score);
      outputFile.WriteLine(_level);

      foreach (Goal goal in _goals)
      {
        outputFile.WriteLine(goal.GetStringRepresentation());
      }
    }

    Console.WriteLine("Goals saved!");
  }

  // Loads everything back from a file. Clears out whatever is
  // currently in memory first so we don't end up with duplicates.
  private void LoadGoals()
  {
    Console.Write("What is the file name for the goal file? ");
    string filename = Console.ReadLine();

    if (!File.Exists(filename))
    {
      Console.WriteLine("That file doesn't exist.");
      return;
    }

    string[] lines = File.ReadAllLines(filename);

    _score = int.Parse(lines[0]);
    _level = int.Parse(lines[1]);

    _goals.Clear();

    // Start at index 2 since the first two lines were the score and level.
    for (int i = 2; i < lines.Length; i++)
    {
      string[] parts = lines[i].Split(":");
      string goalType = parts[0];
      string[] details = parts[1].Split(",");

      switch (goalType)
      {
        case "SimpleGoal":
          _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2]), bool.Parse(details[3])));
          break;
        case "EternalGoal":
          _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
          break;
        case "ChecklistGoal":
          _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5])));
          break;
        case "NegativeGoal":
          _goals.Add(new NegativeGoal(details[0], details[1], int.Parse(details[2])));
          break;
        default:
          Console.WriteLine($"Unknown goal type in file: {goalType}");
          break;
      }
    }

    Console.WriteLine("Goals loaded!");
  }
}