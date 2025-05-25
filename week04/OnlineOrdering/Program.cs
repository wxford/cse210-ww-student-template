class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        var usaAddress = new Address("12 Wilberfoce", "Freetown", "SL", "Sierra Leone");
        var nonUsaAddress = new Address("456 Hill Station", "Freeetown", "SL", "Sierra Leone");

        // Create customers
        var customer1 = new Customer("Bockarie Junior Mansaray", usaAddress);
        var customer2 = new Customer("Josep Kamara", nonUsaAddress);

        // Create products
        var product1 = new Product("Laptop", "P1001", 999.99, 1);
        var product2 = new Product("Mouse", "P1002", 19.99, 2);
        var product3 = new Product("Keyboard", "P1003", 49.99, 1);
        var product4 = new Product("Monitor", "P1004", 199.99, 2);

        // Create orders
        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display order details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():0.00}\n");
    }
}