using Backend.Domain.Products;
using Backend.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Products;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(BackendContext context) : base(context)
    {
    }

    public Task<List<Product>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken)
    {
        return Context.Products
            .Where(p => ids.Contains(p.Id))
            .ToListAsync(cancellationToken);
    }
}
