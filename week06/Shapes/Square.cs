public class Square : Shape
{
    // Member attributes
    private double _sideLength;

    // Constructor
    public Square(string color, double sideLength) : base(color)
    {
        _sideLength = sideLength;
    }

    // GetSideLength Method: Returns the side length of the square
    public double GetSideLength()
    {
        return _sideLength;
    }

    // SetSideLength Method: Sets the side length of the square
    public void SetSideLength(double sideLength)
    {
        _sideLength = sideLength;
    }

    // Override GetArea Method: Calculates and returns the area of the square
    public override double GetArea()
    {
        return _sideLength * _sideLength;
    }

    // Override GetPerimeter Method: Calculates and returns the perimeter of the square
    public override double GetPerimeter()
    {
        return 4 * _sideLength;
    }
}   
