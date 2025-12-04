public class Rectangle : Shape
{
    // Member attributes
    private double _width;
    private double _height;

    // Constructor
    public Rectangle(string color, double width, double height) : base(color)
    {
        _width = width;
        _height = height;
    }

    // GetWidth Method: Returns the width of the rectangle
    public double GetWidth()
    {
        return _width;
    }

    // SetWidth Method: Sets the width of the rectangle
    public void SetWidth(double width)
    {
        _width = width;
    }

    // GetHeight Method: Returns the height of the rectangle
    public double GetHeight()
    {
        return _height;
    }

    // SetHeight Method: Sets the height of the rectangle
    public void SetHeight(double height)
    {
        _height = height;
    }

    // Override GetArea Method: Calculates and returns the area of the rectangle
    public override double GetArea()
    {
        return _width * _height;
    }
    
    // Override GetPerimeter Method: Calculates and returns the perimeter of the rectangle
    public override double GetPerimeter()
    {
        return 2 * (_width + _height);
    }
}