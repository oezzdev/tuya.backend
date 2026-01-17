using Backend.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Shared;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected readonly BackendContext Context;
    protected DbSet<T> DbSet => Context.Set<T>();

    protected Repository(BackendContext context)
    {
        Context = context;
    }

    public Task Add(T entity, CancellationToken cancellationToken = default)
    {
        return DbSet.AddAsync(entity, cancellationToken).AsTask();
    }

    public Task<T?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return DbSet.FindAsync(new object[] { id }, cancellationToken).AsTask();
    }
}