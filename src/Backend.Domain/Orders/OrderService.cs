using Backend.Domain.Customers;
using Backend.Domain.Products;

namespace Backend.Domain.Orders;

public class OrderService
{
    public Order ProcessOrder(Customer customer, IEnumerable<(Product, int)> items)
    {
        Order order = new(customer);
        foreach (var item in items)
        {
            if (item.Item2 <= 0)
            {
                throw new ArgumentException("Item quantity must be greater than zero.");
            }

            order.AddItem(item.Item1);
        }

        return order;
    }
}
