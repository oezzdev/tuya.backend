using Backend.Domain.Products;

namespace Backend.Domain.Orders;

public class OrderItem
{
    public OrderItem(Guid orderId, Guid productId)
    {
        OrderId = orderId;
        ProductId = productId;
    }

    public OrderItem(Order order, Product product) : this(order.Id, product.Id)
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
