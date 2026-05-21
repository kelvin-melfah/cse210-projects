public class Fraction
{
  // Private attributes (encapsulation)
  private int _numerator;
  private int _denominator;

  // Constructor 1: No parameters — defaults to 1/1
  public Fraction()
  {
    _numerator = 1;
    _denominator = 1;
  }

  // Constructor 2: One parameter — denominator defaults to 1
  public Fraction(int numerator)
  {
    _numerator = numerator;
    _denominator = 1;
  }

  // Constructor 3: Two parameters — numerator and denominator
  public Fraction(int numerator, int denominator)
  {
    _numerator = numerator;
    _denominator = denominator;
  }

  // Getter for numerator (top)
  public int GetNumerator()
  {
    return _numerator;
  }

  // Setter for numerator (top)
  public void SetNumerator(int numerator)
  {
    _numerator = numerator;
  }

  // Getter for denominator (bottom)
  public int GetDenominator()
  {
    return _denominator;
  }

  // Setter for denominator (bottom)
  public void SetDenominator(int denominator)
  {
    _denominator = denominator;
  }

  // Returns fraction as a string, e.g. "3/4"
  public string GetFractionString()
  {
    return $"{_numerator}/{_denominator}";
  }

  // Returns fraction as a decimal, e.g. 0.75
  public double GetDecimalValue()
  {
    return (double)_numerator / _denominator;
  }
}
