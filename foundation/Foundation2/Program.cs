using System;

class Program
{
    static void Main(string[] args)
    {
        var orders = new Order[] {
            new Order(new List<Product> { new Product("Order 1 Product 1", "1", 5, 1), new Product("Order 1 Product 2", "2", 5, 2), new Product("Order 1 Product 3", "3", 5, 3) }, new Customer("Customer 1", new Address("123 Main St", "Springfield", "IL", "USA"))),
            new Order(new List<Product> { new Product("Order 2 Product 1", "4", 10, 1), new Product("Order 2 Product 2", "5", 10, 2), new Product("Order 2 Product 3", "6", 10, 3) }, new Customer("Customer 2", new Address("123 Main St", "Johannesburg", "GP", "South Africa"))),
            new Order(new List<Product> { new Product("Order 3 Product 1", "7", 15, 1), new Product("Order 3 Product 2", "8", 15, 2), new Product("Order 3 Product 3", "9", 15, 3) }, new Customer("Customer 3", new Address("123 Main St", "Durban", "KZN", "South Africa"))),
        };

        foreach (var order in orders)
        {
            Console.WriteLine("Packaging Label:");
            Console.WriteLine(order.GetPackagingLabel());
            Console.WriteLine($"Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost:");
            Console.WriteLine($"${order.GetTotalCost():F2}");
            Console.WriteLine();
        }
    }
}
