using Backend.Domain.Customers;
using Backend.Domain.Orders;
using Backend.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Shared;

public class BackendContext : DbContext
{
    public BackendContext(DbContextOptions<BackendContext> options) : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; } = default!;
    public virtual DbSet<OrderItem> OrderItems { get; set; } = default!;
    public virtual DbSet<Customer> Customers { get; set; } = default!;
    public virtual DbSet<Product> Products { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder
            .Properties<Guid>()
            .HaveConversion<string>();
    }
}
