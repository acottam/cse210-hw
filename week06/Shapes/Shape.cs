public abstract class Shape
{
    // Member attributes
    private string _color;
    
    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // GetColor Method: Returns the color of the shape
    public string GetColor()
    {
        return _color;
    }

    // SetColor Method: Sets the color of the shape
    public void SetColor(string color)
    {
        _color = color;
    }

    // GetArea Method: Abstract method to be implemented by derived classes
    public abstract double GetArea();
    
    // GetPerimeter Method: Abstract method to be implemented by derived classes
    public abstract double GetPerimeter();
}