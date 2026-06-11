using System;

class ProgramS
{
    static void Main(string[] args)
    {
        // We're using a List<Shape> here because all three types — Square, Rectangle, Circle —
        // are derived from Shape, so they can all live in the same list without any issues
        List<Shape> shapes = new List<Shape>();

        // Let's throw in a mix of shapes with different colors and measurements to test things out
        shapes.Add(new Square("Red", 4));            // Red square, each side is 4 units long
        shapes.Add(new Rectangle("Blue", 6, 3));     // Blue rectangle, 6 units long and 3 units wide
        shapes.Add(new Circle("Green", 5));          // Green circle with a radius of 5 units
        shapes.Add(new Square("Yellow", 7));         // Yellow square, each side is 7 units long
        shapes.Add(new Rectangle("Purple", 10, 2)); // Purple rectangle, 10 units long and 2 units wide
        shapes.Add(new Circle("Orange", 3.5));       // Orange circle with a radius of 3.5 units

        Console.WriteLine("\n=== Shapes Area Calculator ===\n");

        // This loop is where polymorphism really shows itself.
        // Even though every item in the list is treated as a Shape,
        // calling shape.GetArea() will actually run the right formula
        // for whatever specific type that shape happens to be at runtime.
        // We wrote this loop once and it works for every shape we'll ever add — that's the beauty of it.
        foreach (Shape shape in shapes)
        {
            // Both GetColor() and GetArea() come from the Shape base class,
            // but GetArea() quietly swaps in the correct version — square, rectangle, or circle —
            // based on what the object actually is under the hood
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"Color: {color}, Area: {area:F2}");
        }

        Console.WriteLine("\nAll done! Every shape calculated its own area without us having to ask twice.");
    }
}