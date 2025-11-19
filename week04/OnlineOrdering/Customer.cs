// Customer Class
public class Customer
{
    // Private Members
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        // Initialize members
        _name = name;
        _address = address;
    }

    // GetName Method - Returns Name
    public string GetName()
    {
        return _name;
    }

    // GetAddress Method - Returns Address
    public Address GetAddress()
    {
        return _address;
    }
}
