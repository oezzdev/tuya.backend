using Backend.Domain.Orders;

namespace Backend.Domain.Products;

public class Product
{
    public Product(string name, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public virtual ICollection<OrderItem>? OrderItems { get; set; }
}
