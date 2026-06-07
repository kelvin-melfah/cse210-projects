/*
 * ============================================================
 *  Mindfulness Program  –  Week 05 Assignment
 *  Author : Kelvin
 *  Course : WDD131 / CSE 210
 * ============================================================
 *
 *  
 *  1. FOURTH ACTIVITY — GratitudeActivity guides the user
 *     through a focused gratitude journaling session with
 *     category prompts and follow-up questions.
 *
 *  2. NO REPEATED PROMPTS / QUESTIONS — Both ReflectionActivity
 *     and ListingActivity use a shuffle-pool technique: each
 *     prompt/question is removed from the pool once used, so
 *     no item repeats until all have been shown at least once
 *     in that session.
 *
 *  3. PERSISTENT LOG FILE — ActivityLog records every completed
 *     session (date, name, duration) to "mindfulness_log.txt"
 *     and reloads it on startup, so history survives between
 *     program runs. Users can view the full log from the menu.
 *
 *  4. MEANINGFUL BREATHING ANIMATION — BreathingActivity uses
 *     an expanding/contracting ASCII balloon that grows slowly
 *     during "Breathe in" and shrinks during "Breathe out",
 *     giving a visual pacing cue beyond a plain countdown.
 *
 *  5. POLISHED UI — Console is cleared between screens, a box-
 *     drawing banner frames each activity name, and the spinner
 *     uses classic UNIX "|/-\" frames for a clean feel.
 * ============================================================
 */

using System;

class Program
{
    static ActivityLog _log = new ActivityLog();

    static void Main(string[] args)
    {
        bool quit = false;

        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("\n  ╔══════════════════════════════════╗");
            Console.WriteLine("  ║       Mindfulness Program        ║");
            Console.WriteLine("  ╚══════════════════════════════════╝\n");
            Console.WriteLine("  Menu Options:");
            Console.WriteLine("    1. Breathing Activity");
            Console.WriteLine("    2. Reflection Activity");
            Console.WriteLine("    3. Listing Activity");
            Console.WriteLine("    4. Gratitude Activity  [bonus]");
            Console.WriteLine("    5. View Activity Log   [bonus]");
            Console.WriteLine("    6. Quit\n");
            Console.Write("  Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var breathing = new BreathingActivity();
                    breathing.Run();
                    _log.RecordActivity(breathing.GetName(), breathing.GetDuration());
                    break;

                case "2":
                    var reflection = new ReflectionActivity();
                    reflection.Run();
                    _log.RecordActivity(reflection.GetName(), reflection.GetDuration());
                    break;

                case "3":
                    var listing = new ListingActivity();
                    listing.Run();
                    _log.RecordActivity(listing.GetName(), listing.GetDuration());
                    break;

                case "4":
                    var gratitude = new GratitudeActivity();
                    gratitude.Run();
                    _log.RecordActivity(gratitude.GetName(), gratitude.GetDuration());
                    break;

                case "5":
                    _log.Display();
                    break;

                case "6":
                    quit = true;
                    Console.WriteLine("\n  Goodbye — keep taking time for yourself!\n");
                    break;

                default:
                    Console.WriteLine("\n  Invalid option. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}