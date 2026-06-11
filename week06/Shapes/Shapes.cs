// This is the base class that all shapes will inherit from.
// It holds the things every shape has in common — a color and the ability to calculate its area.
public abstract class Shape
{
    // Every shape has a color, so we store it here in the base class
    private string _color;

    // When you create a shape, you have to give it a color right away
    public Shape(string color)
    {
        _color = color;
    }

    // Simple getter so other parts of the program can read the color
    public string GetColor()
    {
        return _color;
    }

    // Simple setter in case you ever want to change the color later
    public void SetColor(string color)
    {
        _color = color;
    }

    // Every shape must know how to compute its own area, but the formula
    // is different for each shape — so we leave the actual math to each child class.
    // Marking it virtual means child classes are allowed (and expected) to override it.
    public virtual double GetArea()
    {
        // The base class has no sensible area formula, so we just return 0 here.
        // In practice, only the overridden versions in Square, Rectangle, and Circle will be called.
        return 0;
    }
}