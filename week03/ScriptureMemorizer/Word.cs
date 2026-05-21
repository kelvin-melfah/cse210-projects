// Word.cs
// Represents a single word in a scripture. Tracks whether it is hidden.
public class Word
{
  private string _text;
  private bool _isHidden;

  public Word(string text)
  {
    _text = text;
    _isHidden = false;
  }

  public void Hide()
  {
    _isHidden = true;
  }

  public bool IsHidden()
  {
    return _isHidden;
  }

  // Returns underscores matching the word length when hidden, or the word itself when visible.
  public string GetDisplayText()
  {
    if (_isHidden)
      return new string('_', _text.Length);
    return _text;
  }
}
