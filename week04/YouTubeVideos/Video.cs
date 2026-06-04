// Video.cs
// This class is responsible for storing everything we need to know about
// a single YouTube video: its title, who made it, how long it is, and the
// comments people have left on it.
//
// Importantly, Video doesn't expose the raw comment list directly — outside
// code adds comments through AddComment() and asks for the count through
// GetNumberOfComments(). That keeps the internal storage detail hidden,
// which is exactly what abstraction is about.

public class Video
{
  // The title of the video as it appears on YouTube
  public string Title { get; set; }

  // The name of the YouTube channel or creator who uploaded it
  public string Author { get; set; }

  // How long the video runs, measured in seconds
  // (e.g., 183 means 3 minutes and 3 seconds)
  public int LengthInSeconds { get; set; }

  // Internal list of comments — private so outside code can't
  // directly manipulate the list; it has to go through our methods
  private List<Comment> _comments;

  // Constructor — sets up the video with its core info and
  // initializes an empty comment list ready to accept comments
  public Video(string title, string author, int lengthInSeconds)
  {
    Title = title;
    Author = author;
    LengthInSeconds = lengthInSeconds;
    _comments = new List<Comment>();
  }

  // Adds a single Comment object to this video's comment list
  public void AddComment(Comment comment)
  {
    _comments.Add(comment);
  }

  // Returns how many comments this video currently has.
  // Callers get a number — they don't need to see the list itself.
  public int GetNumberOfComments()
  {
    return _comments.Count;
  }

  // Returns a read-only view of the comment list so Program.cs can
  // iterate and display comments without being able to modify the list
  public IEnumerable<Comment> GetComments()
  {
    return _comments;
  }

  // Formats the video length from raw seconds into a readable MM:SS string
  // so the display output is friendlier than just printing "245 seconds"
  public string GetFormattedLength()
  {
    int minutes = LengthInSeconds / 60;
    int seconds = LengthInSeconds % 60;
    return $"{minutes}:{seconds:D2}"; // D2 pads seconds to always be two digits
  }
}