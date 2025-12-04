using System;

class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Create Square
        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        // Create Rectangle
        Rectangle s2 = new Rectangle("Blue", 4, 5);
        shapes.Add(s2);

        // Create Circle
        Circle s3 = new Circle("Green", 6);
        shapes.Add(s3);

        // Iterate through the list and display area of each shape
        foreach (Shape s in shapes)
        {
            // Get the color of the shape
            string color = s.GetColor();

            // Get the area of the shape
            double area = s.GetArea();

            // Get the perimeter of the shape
            double perimeter = s.GetPerimeter();

            // Display the color and area
            Console.WriteLine($"The {color} shape has an area of {area} and a parimeter of {perimeter}.");
        }
    }
}