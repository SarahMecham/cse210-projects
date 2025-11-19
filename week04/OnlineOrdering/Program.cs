using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("100 South State St", "Salt Lake City", "Utah", "USA");
        Address address2 = new Address("290 Kensington Ave.", "Jasper", "British Colombia", "Canada");
        Address address3 = new Address("193 Mendell Rd.", "Rochester", "Massachusetts", "United States");

      
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Betsy Roland", address2);
        Customer customer3 = new Customer("Sarah Mecham", address3);

        Product product1 = new Product("Bread", "B8943", 3.50, 2);
        Product product2 = new Product("Milk", "M985", 2.00, 3);
        Product product3 = new Product("Cheese", "C243", 5.00, 1);
        Product product4 = new Product("Eggs", "E7832", 3.78, 2);
        Product product5 = new Product("Crackers", "C643", 4.35, 1);

        Product product6 = new Product("Laptop", "L875", 1200.00, 1);
        Product product7 = new Product("Mouse", "M876", 25.00, 2);

        List<Product> order1Products = new List<Product> { product1, product5, product3, product2 };
        List<Product> order2Products = new List<Product> { product4, product5, product1 };
        List<Product> order3Products = new List<Product> { product6, product7 };

        Order order1 = new Order(customer1, order1Products);
        Order order2 = new Order(customer2, order2Products);
        Order order3 = new Order(customer3, order3Products);

        List<Order> orders = new List<Order> { order1, order2, order3 };

        foreach(Order order in orders)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingAddress());
            Console.WriteLine($"Total Price: ${order.GetTotalCost()}");
            Console.WriteLine();
        }
    }
}