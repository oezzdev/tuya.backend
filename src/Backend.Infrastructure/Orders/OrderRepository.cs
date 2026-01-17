using Backend.Domain.Orders;
using Backend.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Orders;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(BackendContext context) : base(context)
    {
    }

    public Task<Order?> GetDetailed(Guid id, CancellationToken cancellationToken)
    {
        return Context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
}
