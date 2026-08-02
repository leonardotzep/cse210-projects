using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;


class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Cell Phone", "DL100", 1000, 1));
        order1.AddProduct(new Product("Laptop", "DS500", 2000, 1));

        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine("Total: $" + order1.CalculateCost() + "\n");

        

        Address address2 = new Address("456 Central Ave", "Guatemala", "Guatemala", "GT");
        Customer customer2 = new Customer("Juan Perez", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Tennis shoes", "XL222", 150, 1));
        order2.AddProduct(new Product("Soccer ball", "SS100", 100, 1));

        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine("Total: $" + order2.CalculateCost());
    }
}
