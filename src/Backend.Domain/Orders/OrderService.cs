using Backend.Domain.Customers;
using Backend.Domain.Products;

namespace Backend.Domain.Orders;

public class OrderService
{
    public Order ProcessOrder(Customer customer, IEnumerable<(Product, int)> items)
    {
        if (items == null || !items.Any())
        {
            throw new ArgumentException("Order must contain at least one item.");
        }

        Order order = new(customer);
        foreach (var item in items)
        {
            if (item.Item2 <= 0)
            {
                throw new ArgumentException("Item quantity must be greater than zero.");
            }

            order.AddItem(item.Item1, item.Item2);
        }

        return order;
    }
}
