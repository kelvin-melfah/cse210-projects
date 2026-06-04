// Comment.cs
// This class is responsible for storing a single comment left on a video.
// It tracks two things: who made the comment and what they actually said.
// Keeping this in its own class means Video doesn't have to worry about
// the internal details of what a comment looks like — that's abstraction
// doing its job.

public class Comment
{
  // The name of the person who left the comment
  public string CommenterName { get; set; }

  // The actual text content of the comment
  public string Text { get; set; }

  // Constructor — lets us create a comment in one clean line
  // instead of setting each property separately after construction
  public Comment(string commenterName, string text)
  {
    CommenterName = commenterName;
    Text = text;
  }
}