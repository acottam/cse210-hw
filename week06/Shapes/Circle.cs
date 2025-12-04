public class Circle : Shape
{
    // Member attributes    
    private double _radius;

    // Constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // GetRadius Method: Returns the radius of the circle
    public double GetRadius()
    {
        return _radius;
    }

    // SetRadius Method: Sets the radius of the circle
    public void SetRadius(double radius)
    {
        _radius = radius;
    }

    // Override GetArea Method: Calculates and returns the area of the circle
    public override double GetArea()
    {
        return System.Math.PI * _radius * _radius;
    }

    // Override GetPerimeter Method: Calculates and returns the perimeter of the circle
    public override double GetPerimeter()
    {
        return 2 * System.Math.PI * _radius;
    }
}