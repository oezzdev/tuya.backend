using Backend.Domain.Shared;

namespace Backend.Domain.Products;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
}