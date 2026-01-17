using Backend.Domain.Shared;

namespace Backend.Domain.Orders;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order?> GetDetailed(Guid id, CancellationToken cancellationToken);
}
