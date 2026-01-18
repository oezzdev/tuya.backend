using Backend.Domain.Products;

namespace Backend.Domain.Orders;

public class OrderItem
{
    public OrderItem(Guid orderId, Guid productId, int quantity = 1)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public OrderItem(Order order, Product product, int quantity = 1) : this(order.Id, product.Id, quantity)
    {
        Order = order;
        Product = product;
    }

    public Guid OrderId { get; init; }
    public virtual Order? Order { get; init; }
    public Guid ProductId { get; init; }
    public virtual Product? Product { get; init; }
    public int Quantity { get; init; }
    public decimal TotalPrice => Product?.Price * Quantity ?? 0;
}
