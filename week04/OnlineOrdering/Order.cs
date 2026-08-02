using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Collections.Generic;


class Order
{
    List <Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }


    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    
    
    public double CalculateCost()
    {
        double total = 0;
        foreach(Product product in _products)
        {
            total += product.TotalCost();
        }

        if (_customer.IsInUS())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }
        return total;
    }


    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        foreach(Product product in _products)
        {
            label += $"{product.GetProductId()} - {product.GetNameOfProduct()}\n";
        }
        return label;
    }


    public string ShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += _customer.GetNameOfCustomer() + "\n";
        label += _customer.GetAddress() + "\n";
        return label;
    }
}
