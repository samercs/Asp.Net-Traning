using Lesson9.Models;

namespace Lesson9.Service;

public class ProductService
{
    
    private List<Product> _products { get; set; }

    public ProductService(Service1 service1, Service2 service2)
    {
        _products = new List<Product>();
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public void AddProduct(int id, string name, decimal price)
    {
        _products.Add(new Product()
        {
            Id = id,
            Name = name,
            Price = price
        });
    }

    public void Update(int id, string newName, decimal newPrice)
    {
        var updatedProduct = _products.First(i => i.Id == id);
        /*updatedProduct.Name = newName;
        updatedProduct.Price = newPrice;*/
        _products.Remove(updatedProduct);
        _products.Add(new Product()
        {
            Id = id,
            Name = newName,
            Price = newPrice
        });
    }

}

public class Service1
{
    public string Print()
    {
        return "Service1";
    }
}

public class Service2
{

}