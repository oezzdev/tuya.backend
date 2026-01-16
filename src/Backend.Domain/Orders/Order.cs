using Backend.Domain.Customers;
using Backend.Domain.Products;

namespace Backend.Domain.Orders;

public class Order(Guid customerId)
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public Guid CustomerId { get; init; } = customerId;
    public virtual Customer? Customer { get; init; }
    public ICollection<OrderItem> Items { get; init; } = [];
    public decimal TotalAmount => Items.Sum(item => item.TotalPrice);

    public Order(Customer customer) : this(customer.Id)
    {
        Customer = customer;
    }

    public void AddItem(Product item)
    {
        OrderItem itemItem = new(this, item);
        Items.Add(itemItem);
    }
}
