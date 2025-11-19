using System;
using System.Collections.Generic;

public class Order
{
    // Private members
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        // Initialize members
        _customer = customer;
        _products = new List<Product>();
    }

    // Add Product Method - Adds product to Order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // CalculateTotalCost Method - Returns subtotal + shippingCost
    public double CalculateTotalCost()
    {
        double subtotal = 0;
        foreach (Product product in _products)
        {
            subtotal += product.GetPrice();
        }

        double shippingCost = _customer.GetAddress().IsInUSA() ? 5 : 35;
        return subtotal + shippingCost;
    }

    // GetPackingLabel Method - Returns Label
    public string GetPackingLabel()
    {
        // Packing Label
        string label = "Packing Label:\n";

        // Iterates through Products
        foreach (Product product in _products)
        {
            // Appends Label information
            label += product.GetPackingLabel() + "\n";
        }
        
        // Returns Label
        return label;
    }

    // GetShippingLabel Method - Returns formatted Shipping Label
    public string GetShippingLabel()
    {
        // Returns formatted Label
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetDisplayText()}";
    }

    // DisplayOrder Method - Outputs formatted order to screen
    public void DisplayOrder()
    {
        Console.WriteLine(GetPackingLabel());
        Console.WriteLine(GetShippingLabel());
        Console.WriteLine($"Total Cost: ${CalculateTotalCost():F2}");
    }
}
