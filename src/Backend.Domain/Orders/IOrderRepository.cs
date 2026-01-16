namespace Backend.Domain.Orders;

public interface IOrderRepository
{
    Task Add(Order order, CancellationToken cancellationToken = default);
}
