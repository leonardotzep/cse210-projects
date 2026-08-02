using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;


class Customer
{
    private string _name;
    private Address _address;

    public bool IsInUS()
    {
        return _address.IsInUSA();
    }


    public string GetNameOfCustomer()
    {
        return _name;
    }


    public string GetAddress()
    {
        return _address.GetFullAddress();
    }


    public Customer (string name, Address address)
    {
     _name = name;
     _address = address;   
    }
}
