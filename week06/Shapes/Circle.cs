// A Circle is defined by its radius — the distance from the center to the edge.
// It inherits the color and shared behavior from the base Shape class.
public class Circle : Shape
{
  // The only measurement a circle needs is its radius
  private double _radius;

  // To create a circle, pass a color (sent up to Shape) and the radius
  public Circle(string color, double radius) : base(color)
  {
    _radius = radius;
  }

  // Area of a circle = π × radius²
  // Math.PI gives us a precise value of pi so we don't have to hardcode it
  public override double GetArea()
  {
    return Math.PI * _radius * _radius;
  }
}