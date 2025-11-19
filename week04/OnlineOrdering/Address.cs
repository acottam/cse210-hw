// Address class - Manages Addresses
public class Address
{
    // Private Members
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Constructor
    public Address(string street, string city, string state, string country)
    {
        // Initialize members
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // IsInUSA Member - Returns TRUE if in USA
    public bool IsInUSA()
    {
        // Returns TRUE IF in USA
        return _country.ToLower() == "usa" || _country.ToLower() == "united states";
    }

    // GetDisplayText Method - Returns Formatted Address
    public string GetDisplayText()
    {
        // Returns formatted Address
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}
