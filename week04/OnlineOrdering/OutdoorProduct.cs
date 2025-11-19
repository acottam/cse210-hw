// OutdoorProduct Class - Extends Product 
public class OutdoorProduct : Product
{
    // Constructor
    public OutdoorProduct(string name, double price, int productId) : base(name, price, productId)
    {
    }

    // GetPackagingLable - Returns formatted packaging details
    public override string GetPackingLabel()
    {
        // Returns a formatted packaging label + additional requirements
        return base.GetPackingLabel() + " - **Requires Outdoor Activity Waiver**";
    }
}
