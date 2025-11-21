using System;

class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Create Addresses
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");

        // Create Customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Sarah Johnson", address2);

        // Create Products
        Product laptop = new Product("Laptop", 999.99, 1001);
        Product tent = new Product("Camping Tent", 149.99, 2001);
        Product goggles = new Product("Swimming Goggles", 29.99, 3001);

        // Create Order #1 (USA)
        Order order1 = new Order(customer1);
        order1.AddProduct(laptop);
        order1.AddProduct(tent);

        // Create Order #2 (Canada)
        Order order2 = new Order(customer2);
        order2.AddProduct(goggles);
        order2.AddProduct(new Product("Keyboard", 79.99, 1002));

        // Empty Line
        Console.WriteLine();

        // Display Order #1
        Console.WriteLine("ORDER 1:");
        order1.DisplayOrder();
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine();

        // Display Order #2
        Console.WriteLine("ORDER 2:");
        order2.DisplayOrder();
        Console.WriteLine();
    }
}
