namespace Backend.Domain.Shared;

public interface IRepository<T> where T : class
{
    Task Add(T entity, CancellationToken cancellationToken = default);
    Task<T?> GetById(Guid id, CancellationToken cancellationToken = default);
}