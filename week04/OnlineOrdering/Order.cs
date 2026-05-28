using System.Collections.Generic;
using System.Text;

public class Order
{
  private List<Product> _products;
  private Customer _customer;

  private const double _domesticShipping = 5.0;
  private const double _internationalShipping = 35.0;

  public Order(Customer customer)
  {
    _customer = customer;
    _products = new List<Product>();
  }

  public void AddProduct(Product product)
  {
    _products.Add(product);
  }

  public double GetTotalCost()
  {
    double total = 0;

    foreach (Product product in _products)
    {
      total += product.GetTotalCost();
    }

    total += _customer.LivesInUSA() ? _domesticShipping : _internationalShipping;

    return total;
  }

  public string GetPackingLabel()
  {
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("---- Packing Label ----");

    foreach (Product product in _products)
    {
      sb.AppendLine($"Name: {product.GetName()}  |  Product ID: {product.GetProductId()}");
    }

    return sb.ToString();
  }

  public string GetShippingLabel()
  {
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("---- Shipping Label ----");
    sb.AppendLine(_customer.GetName());
    sb.AppendLine(_customer.GetAddress().GetFullAddress());

    return sb.ToString();
  }
}