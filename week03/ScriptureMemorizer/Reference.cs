// Represents a scripture reference (e.g., "Mark 10:27" or "Proverbs 3:5-6").
public class Reference
{
  private string _book;
  private int _chapter;
  private int _startVerse;
  private int _endVerse;

  // Constructor for a single verse, e.g., "Mark 10:27"
  public Reference(string book, int chapter, int verse)
  {
    _book = book;
    _chapter = chapter;
    _startVerse = verse;
    _endVerse = verse;
  }

  // Constructor for a verse range, e.g., "Proverbs 3:5-6"
  public Reference(string book, int chapter, int startVerse, int endVerse)
  {
    _book = book;
    _chapter = chapter;
    _startVerse = startVerse;
    _endVerse = endVerse;
  }

  // Returns a formatted reference string such as "Mark 10:27" or "Proverbs 3:5-6".
  public string GetDisplayText()
  {
    if (_startVerse == _endVerse)
      return $"{_book} {_chapter}:{_startVerse}";
    return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
  }
}
