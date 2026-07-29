using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA Customer)
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop Stand", "P101", 29.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "P102", 15.50, 2));

        // Order 2 (International Customer - Tanzania)
        Address address2 = new Address("Bagamoyo Road", "Dar es Salaam", "DSM", "Tanzania");
        Customer customer2 = new Customer("Amani Juma", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Mechanical Keyboard", "P201", 89.99, 1));
        order2.AddProduct(new Product("USB-C Cable", "P202", 8.00, 3));
        order2.AddProduct(new Product("Screen Cleaner", "P203", 5.00, 1));

        // Display Order 1
        Console.WriteLine("==========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalCost():F2}");

        // Display Order 2
        Console.WriteLine("\n==========================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine("==========================================");
    }
}
