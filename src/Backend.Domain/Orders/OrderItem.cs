using Backend.Domain.Products;

namespace Backend.Domain.Orders;

public class OrderItem(Guid orderId, Guid itemId)
{
    public Guid OrderId { get; init; } = orderId;
    public virtual Order? Order { get; init; }
    public Guid ItemId { get; init; } = itemId;
    public virtual Product? Item { get; init; }
    public int Quantity { get; init; }
    public decimal TotalPrice => Item?.Price * Quantity ?? 0;

    public OrderItem(Order order, Product item) : this(order.Id, item.Id)
    {
        Order = order;
        Item = item;
    }
}
