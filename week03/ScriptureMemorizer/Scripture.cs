// Represents a complete scripture: a reference and its word list.
public class Scripture
{
  private Reference _reference;
  private List<Word> _words;
  private Random _random = new Random();

  public Scripture(Reference reference, string text)
  {
    _reference = reference;
    _words = text.Split(' ')
                 .Select(w => new Word(w))
                 .ToList();
  }

  // Returns true when every word is hidden.
  public bool IsCompletelyHidden()
  {
    return _words.All(w => w.IsHidden());
  }

  // Hides a set number of words chosen randomly from those still visible.
  // Stretch requirement: only selects from words that are NOT already hidden.
  public void HideRandomWords(int count = 3)
  {
    List<Word> visible = _words.Where(w => !w.IsHidden()).ToList();
    if (visible.Count == 0) return;

    int toHide = Math.Min(count, visible.Count);
    for (int i = 0; i < toHide; i++)
    {
      int index = _random.Next(visible.Count);
      visible[index].Hide();
      visible.RemoveAt(index); // Avoid hiding the same word twice in one round
    }
  }

  // Assembles the full display string: reference on its own line, then the words.
  public string GetDisplayText()
  {
    string words = string.Join(" ", _words.Select(w => w.GetDisplayText()));
    return $"{_reference.GetDisplayText()}\n{words}";
  }
}
