public class Product
{
    // Private members
    protected string _name;
    protected double _price;
    protected int _productId;

    // Constructor
    public Product(string name, double price, int productId)
    {
        // Initialize members
        _name = name;
        _price = price;
        _productId = productId;
    }

    // Get Price Method - Returns price
    public double GetPrice()
    {
        // Returns price
        return _price;
    }

    // GetPackingLabel - Returns formatted packing label
    public virtual string GetPackingLabel()
    {
        return $"{_name} - {_productId}";
    }
}
