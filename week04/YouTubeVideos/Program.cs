// Program.cs
// This is the entry point for the YouTube Video tracker program.
// Its only job here is to:
//   1. Create a handful of videos with realistic-looking data
//   2. Attach several comments to each one
//   3. Loop through the full video list and print everything out
//
// There's no user interaction by design — the assignment is focused
// on demonstrating class relationships and abstraction, not UI.

// ----------------------------------------------------------------
// BUILD THE VIDEO LIST
// Each video is created with a title, author name, and length in
// seconds. Comments are then added through Video's AddComment()
// method so the list stays encapsulated inside the Video class.
// ----------------------------------------------------------------

List<Video> videos = new List<Video>();

// --- Video 1 ---
// A product-placement-friendly cooking channel — exactly the kind
// of content our fictional monitoring company would track
Video video1 = new Video("5 Budget Meals Under $10", "QuickBitesKitchen", 742);
video1.AddComment(new Comment("FoodieForever", "The pasta dish at 4:30 changed my life. Making it every week now!"));
video1.AddComment(new Comment("BrokeCollegeKid", "Finally a video that actually shows realistic grocery prices. Subscribed!"));
video1.AddComment(new Comment("MealPrepMike", "Love the tip about bulk buying spices — saved me so much money already."));
video1.AddComment(new Comment("CuriousCook_22", "Do these work with an air fryer? Would love a follow-up on that."));
videos.Add(video1);

// --- Video 2 ---
// A tech review — another common category for product placement tracking
Video video2 = new Video("Honest Review: Budget Wireless Earbuds 2024", "TechTruthReviews", 1083);
video2.AddComment(new Comment("AudiophileAnna", "Best honest review I've found on these. Every other channel just hypes them up."));
video2.AddComment(new Comment("JustBoughtThese", "Watching this AFTER buying them. The battery life issue is real, can confirm."));
video2.AddComment(new Comment("SoundGeek99", "The frequency response comparison at 8:45 was super helpful — nice production quality."));
videos.Add(video2);

// --- Video 3 ---
// A fitness channel — high engagement, lots of product mentions
Video video3 = new Video("30-Minute Full Body Workout — No Equipment Needed", "FitWithFiona", 1847);
video3.AddComment(new Comment("LazyToActive", "I've tried so many of these and this is honestly the first one I actually finished."));
video3.AddComment(new Comment("GymRatGareth", "The form tips throughout are what separate this from every other home workout video."));
video3.AddComment(new Comment("MorningRoutineMeg", "Day 14 of doing this every morning. Down 6 lbs. Thank you!"));
video3.AddComment(new Comment("SkepticalSteve", "Paused halfway through to leave this comment. My legs already feel like jelly."));
videos.Add(video3);

// --- Video 4 ---
// Personal finance — highly relevant to the Financial Literacy Hub context
Video video4 = new Video("How I Paid Off $40K in Debt in 18 Months", "DebtFreeByDave", 2214);
video4.AddComment(new Comment("InDebtInDallas", "I've watched this three times. Starting my spreadsheet tonight. Thank you."));
video4.AddComment(new Comment("FinanceProfessor", "Solid advice. The avalanche vs. snowball breakdown at 12:00 is especially well explained."));
video4.AddComment(new Comment("SkepticalSusan", "Would love a follow-up on what happened after — did any debt come back?"));
videos.Add(video4);

// ----------------------------------------------------------------
// DISPLAY ALL VIDEOS
// Loop through each video and print its details, then loop through
// that video's comments. The separator line between videos makes
// the output much easier to read in the console.
// ----------------------------------------------------------------

Console.WriteLine("=================================================");
Console.WriteLine("       YOUTUBE VIDEO TRACKER — REPORT");
Console.WriteLine("=================================================\n");

foreach (Video video in videos)
{
    // Print the core video info — title, author, length, comment count
    Console.WriteLine($"Title:     {video.Title}");
    Console.WriteLine($"Author:    {video.Author}");
    Console.WriteLine($"Length:    {video.GetFormattedLength()} ({video.LengthInSeconds} seconds)");
    Console.WriteLine($"Comments:  {video.GetNumberOfComments()}");

    // Print each comment under the video it belongs to
    Console.WriteLine("\n  --- Comments ---");
    foreach (Comment comment in video.GetComments())
    {
        Console.WriteLine($"  [{comment.CommenterName}]: {comment.Text}");
    }

    // Visual divider between videos so the output is easy to scan
    Console.WriteLine("\n-------------------------------------------------\n");
}