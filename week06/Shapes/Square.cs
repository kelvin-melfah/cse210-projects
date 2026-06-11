// A Square is a shape where all four sides are the same length.
// It inherits everything a Shape has (color, GetColor, etc.) and just adds its own side length.
public class Square : Shape
{
  // A square only needs one measurement — any single side will do
  private double _side;

  // To create a square, you need a color (passed up to Shape) and the length of one side
  public Square(string color, double side) : base(color)
  {
    _side = side;
  }

  // Area of a square = side × side
  // The "override" keyword means this replaces the base class version for Square objects
  public override double GetArea()
  {
    return _side * _side;
  }
}