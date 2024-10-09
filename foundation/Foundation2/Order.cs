using System;
using System.Collections.Generic;
using System.Linq;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public float GetTotalCost() {
        return GetProductCost() + GetShippingCost();
    }

    public string GetPackagingLabel() {
        return string.Join(", ", _products.Select(product => $"Product Name: {product.Name} (ID: {product.Id})"));
    }

    public string GetShippingLabel() {
        return $"Name: {_customer.Name}, Address: {_customer.Address}";
    }

    private float GetProductCost() {
        return _products.Sum(product => product.GetTotalCost());
    }

    private float GetShippingCost() {
        if (_customer.IsInUSA()) {
            return 5.0f;
        } else {
            return 35.0f;
        }
    }
}
