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

    public async Task Add(T entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public Task<T?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return DbSet.FindAsync(new object[] { id }, cancellationToken).AsTask();
    }

    public async Task Update(T entity, CancellationToken cancellationToken = default)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }
}