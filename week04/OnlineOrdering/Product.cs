using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;


class Product
{
    private string _nameOfProduct;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string nameOfProduct, string productId, double price, int quantity)
    {
        _nameOfProduct = nameOfProduct;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }


    public double TotalCost()
    {
        return _price * _quantity;
    }


    public string GetNameOfProduct()
    {
        return _nameOfProduct;
    }


    public string GetProductId()
    {
        return _productId;
    }
}
