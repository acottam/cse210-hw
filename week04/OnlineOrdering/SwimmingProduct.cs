// SwimProduct Class - Extends Product
public class SwimmingProduct : Product
{
    // Constructor
    public SwimmingProduct(string name, double price, int productId) : base(name, price, productId)
    {
    }

    // GetPackingLabel Method - Returns product info
    public override string GetPackingLabel()
    {
        // Returns Packing Label along with special instructions
        return base.GetPackingLabel() + " - **Pool/Water Safety Instructions Included**";
    }
}
