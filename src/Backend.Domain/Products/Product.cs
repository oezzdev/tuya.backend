namespace Backend.Domain.Products;

public class Product(string name, decimal price)
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public string Name { get; init; } = name;
    public decimal Price { get; init; } = price;
}
