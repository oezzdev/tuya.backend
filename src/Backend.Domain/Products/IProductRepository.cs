namespace Backend.Domain.Products;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
}