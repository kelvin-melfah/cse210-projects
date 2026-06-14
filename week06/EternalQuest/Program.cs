using System;

/*
 * ETERNAL QUEST PROGRAM
 *
 * 1. Leveling system - The user's score isn't just a number sitting
 *    there. Every 1000 points earns a new "Level", and the program
 *    announces it with a little celebration message when it happens.
 *    This was inspired by the "level 13 Ninja Unicorn" idea from the
 *    assignment description - it gives the score some extra meaning.
 *
 * 2. Negative Goals - I added a whole new goal type for tracking bad
 *    habits. Recording one of these SUBTRACTS points from the score
 *    instead of adding them, which gives the user a reason to avoid
 *    doing it. These show up in the list with a "[!]" marker instead
 *    of a checkbox, since they're never really "completed".
 *
 * 3. Checklist progress bonus celebration - When a checklist goal is
 *    completed (hits its target count), the program gives an extra
 *    congratulations message on top of the normal points message,
 *    calling out that a bonus was earned.
 *
 * 4. Clean save/load - Score and level are both saved/loaded along
 *    with every goal, so the user's progress (including their level)
 *    picks back up exactly where they left off.
 */
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}