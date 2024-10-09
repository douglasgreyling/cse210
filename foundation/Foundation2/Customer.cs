using System;

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA() {
        return _address.IsInUSA();
    }

    public string Name
    {
        get { return _name; }
    }

    public string Address
    {
        get { return _address.GetDisplayText(); }
    }
}
