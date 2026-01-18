using Backend.Domain.Customers;
using Backend.Domain.Products;

namespace Backend.Domain.Orders;

public class Order
{
    public Order(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        Date = DateTimeOffset.UtcNow;
        Items = new List<OrderItem>();
        Status = OrderStatus.Pending;
    }

    public Order(Customer customer) : this(customer.Id)
    {
        Customer = customer;
    }

    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public virtual Customer? Customer { get; init; }
    public DateTimeOffset Date { get; init; }
    public ICollection<OrderItem> Items { get; init; }
    public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
    public OrderStatus Status { get; set; }

    public void AddItem(Product item, int quantity)
    {
        OrderItem itemItem = new(this, item, quantity);
        Items.Add(itemItem);
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Delivered)
        {
            throw new InvalidOperationException("Delivered orders cannot be cancelled.");
        }

        Status = OrderStatus.Cancelled;
    }
}
