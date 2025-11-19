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

    public double GetPrice()
    {
        return _price;
    }

    public virtual string GetPackingLabel()
    {
        return $"{_name} - {_productId}";
    }
}
