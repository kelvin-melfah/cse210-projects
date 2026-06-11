// A Rectangle is like a Square but with two different side lengths (length and width).
// It still inherits color and basic shape behavior from the base Shape class.
public class Rectangle : Shape
{
  // Rectangles have two distinct measurements — length and width
  private double _length;
  private double _width;

  // You need a color plus both side lengths to build a rectangle
  public Rectangle(string color, double length, double width) : base(color)
  {
    _length = length;
    _width = width;
  }

  // Area of a rectangle = length × width
  // This overrides the base version so the right math runs for rectangles
  public override double GetArea()
  {
    return _length * _width;
  }
}